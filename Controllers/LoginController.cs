using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MontrealDatingApp.Data;
using MontrealDatingApp.DTO;
using MontrealDatingApp.Entities;
using MontrealDatingApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MontrealDatingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public LoginController(DataContext context,
            ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("signin")]
        public async Task<ActionResult<UserPrivateDto>> Login(UserPrivateDto userDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync (
                x => x.UserName == userDto.Username
            );
            if (user == null)
            {
                // Use enum instead of string
                userDto.Errors = "Error.UsernameInvalid";
            } else {
                if (string.IsNullOrEmpty(userDto.Password)) {
                    userDto.Errors = "Error.PasswordInvalid";
                } else {

                    var passwordHashed = new HMACSHA512(
                        user.PasswordSalt
                    );

                    var cHash = passwordHashed.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password));
                    
                    for(int i = 0; i < cHash.Length; i++)
                    {
                        if(cHash[i] != user.PasswordHash[i])
                        {

                            userDto.Errors = "Error.PasswordInvalid";
                        }
                    }
                }
            }

            // In real world application, we could have tens if not hundred of fields in the user object. We return the user 
            // as empty in case of invalid password.
            //if (!string.IsNullOrEmpty(userDto.Errors))
            //{
            //    user = ResetPasswordField(user);
            //}
            if(user != null)
            {
                userDto.Token = _tokenService.GenerateToken(user);
                userDto.Password = null;
            }
            
            return userDto;
        }

        public User ResetPasswordField(User user)
        {
            user.PasswordHash = null;
            user.PasswordSalt = null;
            return user;
        }
    }

}

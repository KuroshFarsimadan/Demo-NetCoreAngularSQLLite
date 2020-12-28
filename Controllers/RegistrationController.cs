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
    public class RegistrationController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public RegistrationController(DataContext context, 
            ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserPrivateDto>> Register(UserPrivateDto userDto)
        {
            var user = new User();
            if (await UserAlreadyExists(userDto.Username))
            {
                // Later, we might use enums and specific classes for request and return.
                // Never return a hard coded string. Use localization in the frontend.
                // We don't use the annotation based validation as we want a simple and systematic
                // structure of the returned error. 
                userDto.Errors = "Error.UserAlreadyTaken";
            } else {
                // Use enums instead of string for returning error messages
                if (string.IsNullOrEmpty(userDto.Password))
                {
                    userDto.Errors = "Error.PasswordMissing";
                } else if (string.IsNullOrEmpty(userDto.Username)) {
                    userDto.Errors = "Error.UsernameInvalid";
                } else {
                    // Hash-based Message Authentication Code (HMAC) initialization with randomly generated key
                    var passwordHash = new HMACSHA512();
                    user = new User
                    {
                        UserName = userDto.Username,
                        PasswordHash = passwordHash.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password)),
                        PasswordSalt = passwordHash.Key
                    };
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                }
            }
            if(user != null)
            {
                userDto.Token = _tokenService.GenerateToken(user);
            }
            
            return userDto;
        }

        // Instead of using below, make a general method to check all the passed user parameters with the user data validation
        private async Task<bool> UserAlreadyExists(string userName)
        {
            return await _context.Users.AnyAsync (
                x => x.UserName == userName.ToLower()
            );
        }

    }
}

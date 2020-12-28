using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MontrealDatingApp.Data;
using MontrealDatingApp.DTO;
using MontrealDatingApp.Entities;
using MontrealDatingApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MontrealDatingApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseApiController
    {
        // private readonly IUserRepository userRepository;
        // private readonly IMapper mapper;
        private readonly DataContext context;
        public UsersController(DataContext context)
        {
            this.context = context;
            // Try to automap instead of using data context
            // this.mapper = mapper;
            // this.userRepository = userRepository;
        }

        // Asynchronous HTTP GET api/users
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

    
        // Asynchronous HTTP GET api/users/{id}
        [Authorize]
        [HttpGet("{username}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return await context.Users.FindAsync(id);
        } 

        /*
        // Asynchronous HTTP GET api/users
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPublicDto>>> GetUsers()
        {
            var returnable = await userRepository.GetUsersPublic();
            return Ok(returnable);
        }

        // Asynchronous HTTP GET api/users/{id}
        [Authorize]
        [HttpGet("{username}")]
        public async Task<ActionResult<UserPublicDto>> GetUser(string username)
        {
            return await userRepository.GetUserPublicByUsername(username);
        }
         */

        //// BAD PRACTISE Synchronous HTTP GET api/users
        //[HttpGet]
        //public ActionResult<IEnumerable<User>> GetUsers()
        //{
        //    // Blocking thread
        //    var users = _context.Users.ToList();
        //    return users;
        //}

        //// BAD PRACTISE Synchronous HTTP GET api/users/{id}
        //[HttpGet("{id}")]
        //public ActionResult<User> GetUser(int id)
        //{
        //    // Blocking thread
        //    return _context.Users.Find(id);
        //}
    }
}

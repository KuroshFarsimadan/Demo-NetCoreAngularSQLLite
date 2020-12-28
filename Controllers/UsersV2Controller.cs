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
    [Route("api/v2/[controller]")]
    public class UsersV2Controller : BaseApiController
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersV2Controller(IUserRepository userRepository, IMapper mapper)
        {

            // Try to automap instead of using data context
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPublicDto>>> GetUsers()
        {
            var users = await userRepository.GetUsersPublic();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{username}")]
        public async Task<ActionResult<UserPublicDto>> GetUser(string username)
        {
            return await userRepository.GetUserPublicByUsername(username);
        }


    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MontrealDatingApp.DTO;
using MontrealDatingApp.Entities;
using MontrealDatingApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MontrealDatingApp.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<User> GetUserById(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await context.Users
                .Include(p => p.Images)
                .SingleOrDefaultAsync(
                x => x.UserName == username
            );
        }

        public async Task<UserPublicDto> GetUserPublicByUsername(string username)
        {
            return await context.Users.Where(
                x => x.UserName == username
                ).ProjectTo<UserPublicDto>(
                    mapper.ConfigurationProvider
                ).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<IEnumerable<UserPublicDto>> GetUsersPublic()
        {
            return await context.Users.ProjectTo<UserPublicDto>(
                mapper.ConfigurationProvider
                ).ToListAsync();
        }

        public async Task<bool> PostAll()
        {
            // If changed, we will return a larger value than 0
            return await context.SaveChangesAsync() > 0;
        }

        public void Update(User user)
        {
            context.Entry(user).State = EntityState.Modified;
        }
    }
}

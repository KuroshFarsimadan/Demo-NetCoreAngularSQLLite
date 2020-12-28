using MontrealDatingApp.DTO;
using MontrealDatingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MontrealDatingApp.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByUsername(string username);
        Task<UserPublicDto> GetUserPublicByUsername(string username);
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<UserPublicDto>> GetUsersPublic();
        Task<bool> PostAll();
        void Update(User user);
    }
}

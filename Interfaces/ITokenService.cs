using MontrealDatingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MontrealDatingApp.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}

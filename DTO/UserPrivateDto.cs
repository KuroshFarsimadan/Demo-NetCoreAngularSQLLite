using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MontrealDatingApp.DTO
{
    // Class is used for login. We inherit from Public class
    public class UserPrivateDto : UserPublicDto
    {
        public string Password { get; set; }
        public string Token { get; set; }
        public string Errors { get; set; }
    }
}

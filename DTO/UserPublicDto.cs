using MontrealDatingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MontrealDatingApp.DTO
{
    // Class is used for retrieving users that are not the user that has logged in
    public class UserPublicDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Sex { get; set; }
        public string DetailedProfile { get; set; }
        public string PreferredCompany { get; set; }
        public string Hobbies { get; set; }
        public string LocationCity { get; set; }
        public string LocationCountry { get; set; }
        public int Age { get; set; }
        public ICollection<ImageDto> Images { get; set; }
        public DateTime CreationDate { get; set; } 
        public DateTime LastActiveDate { get; set; } 

    }
}

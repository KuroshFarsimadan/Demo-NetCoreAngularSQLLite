using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MontrealDatingApp.DTO;
using MontrealDatingApp.Entities;

namespace MontrealDatingApp.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Map from User to UserPublicDto
            /*
             * You will see the following in real world applications
             * where you have a legacy application using a completely different
             * data structure than what you are building on top of it for example
             * in Angular 8. 
             */
            CreateMap<User, UserPublicDto>();
            CreateMap<Image, ImageDto>();

   
        }
    }
}

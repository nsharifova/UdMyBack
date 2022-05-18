using AutoMapper;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.MyProfilers
{
    public class LoginUserProfile:Profile
    {
        public LoginUserProfile()
        {
            CreateMap<LoginUserDTO, User>();
        }
    }
}

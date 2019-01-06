using System;
using AutoMapper;
using OpenFlat.API.Models.Dtos;
using OpenFlat.API.Models.Entities;

namespace OpenFlat.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();    
        }
    }
}

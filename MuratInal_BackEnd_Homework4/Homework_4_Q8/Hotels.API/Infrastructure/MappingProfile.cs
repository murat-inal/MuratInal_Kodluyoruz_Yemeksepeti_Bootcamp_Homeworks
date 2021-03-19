using AutoMapper;
using Hotels.API.Entities;
using Hotels.API.Models;
using Hotels.API.Models.Derived;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels.API.Infrastructure
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<RoomEntity, Room>()
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate / 100));
            CreateMap<UserEntity, UserInfo>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => string.Concat(src.Name, src.LastName)));
        }
    }
}

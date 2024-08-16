using AutoMapper;
using Application.DTOs;
using Core.Entities;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Activity, ActivityDto>().ReverseMap();
            CreateMap<Core.Entities.Task, TaskDto>().ReverseMap();
        }
    }
}

using Application.Activities.Commands.CreateActivity;
using Application.Activities.Commands.UpdateActivity;
using Application.Common.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Activity, CreateActivityCommand>().ReverseMap();
            CreateMap<Activity, UpdateActivityCommand>().ReverseMap();
            CreateMap<Activity, ActivityDto>().ReverseMap();
        }
    }
}

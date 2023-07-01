using AutoMapper;
using CQRS.Practico.Application.DTOs;
using CQRS.Practico.Domain;

namespace CQRS.Practico.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskItem, TaskItemDto>().ReverseMap();            
        }

    }
}

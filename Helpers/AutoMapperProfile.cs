using AutoMapper;
using QuizGenerator.Dtos;
using QuizGenerator.Entities;

namespace QuizGenerator.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, UserDto>();
            CreateMap<UserDto, Users>();
        }
    }
}
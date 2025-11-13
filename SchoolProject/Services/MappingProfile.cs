using AutoMapper;
using SchoolApi.SchoolProject.Dtos;

namespace SchoolApi.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SchoolProject.Models.School, ReadSchoolDto>().ReverseMap();
            CreateMap<CreateSchoolDto, SchoolProject.Models.School>();
            CreateMap<UpdateSchoolDto, SchoolProject.Models.School>();
        }
    }
}

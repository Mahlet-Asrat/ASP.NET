using AutoMapper;
using SchoolApi.Dtos;

namespace SchoolApi.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SchoolApi.Models.School, ReadSchoolDto>().ReverseMap();
            CreateMap<CreateSchoolDto, SchoolApi.Models.School>();
            CreateMap<UpdateSchoolDto, SchoolApi.Models.School>();
        }
    }
}

using AutoMapper;
using Training__DAL_.Models;
using TrainingApp.BLL.DTO;

namespace TrainingApp.Web.Configuration.MappingConfig
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile() 
        {
            CreateMap<SubjectTariff, SubjectTariffDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.subjectName.Name))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.subjectType.Type)).ReverseMap();
            CreateMap<WorkedHours, WorkedHoursDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Qualification, QualificationDTO>().ReverseMap();
            CreateMap<Salary, SalaryDTO>().ReverseMap();
            CreateMap<TeacherInfo, TeacherInfoDTO>().ReverseMap();
            CreateMap<SubjectType, SubjectTypeDTO>().ReverseMap();
            CreateMap<SubjectName, SubjectNameDTO>().ReverseMap();
        }
    }
}

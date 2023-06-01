using AutoMapper;
using DAL.Entities;
using BLL.DTO;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<UserEntity, UserDTO>().ReverseMap();
            CreateMap<StudentEntity, StudentDTO>().ReverseMap();
            CreateMap<StudentEntity, UpdateStudentUserDTO>().ReverseMap();
            CreateMap<UserEntity, UpdateStudentUserDTO>().ReverseMap();
            CreateMap<SubjectEntity, SubjectDTO>().ReverseMap();
            CreateMap<TeacherEntity, TeacherDTO>().ReverseMap();
            CreateMap<UserEntity, TeacherDTO>().ReverseMap();
            CreateMap<SubjectEntity, SubjectDTO>()
                .ForMember(dto => dto.Students, opt => opt.MapFrom(x => x.StudentSubjects.Select(y => y.Student).ToList()))
                .ForMember(dto => dto.Teachers, opt => opt.MapFrom(x => x.TeacherSubjects.Select(y => y.Teacher).ToList()));
        }

    }
}

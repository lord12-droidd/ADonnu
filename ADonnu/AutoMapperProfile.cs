using AutoMapper;
using BLL.DTO;
using ADonnu.Models;
using System.Collections.Generic;

namespace ADonnu
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AuthenticationResponseModel, AuthenticationResponseDTO>().ReverseMap();
            CreateMap<UserModel, UserDTO>().ReverseMap();
            CreateMap<UpdateStudentUserModel, UpdateStudentUserDTO>().ReverseMap();
            CreateMap<StudentModel, StudentDTO>().ReverseMap();
            CreateMap<IndScheduleRequestModel, IndScheduleRequestDTO>().ReverseMap();
            CreateMap<TeacherSubjectModel, TeacherSubjectDTO>().ReverseMap();
            CreateMap<ApproveIndScheduleRequestModel, ApproveIndScheduleRequestDTO>().ReverseMap();
            CreateMap<UpdateStudentUserModel, UpdateStudentUserDTO>().ForMember(dest => dest.Roles, opt => opt.MapFrom(src => CollectRoles(src.AdminRole, src.TeacherRole, src.StudentRole)));
        }

        private IList<string> CollectRoles(bool isAdmin, bool isTeacher, bool isStudent)
        {
            Dictionary<string, bool> roles = new Dictionary<string, bool>
            {
                { "Admin", isAdmin },
                { "Teacher", isTeacher },
                { "Student", isStudent }
            };
            List<string> collectedRoles = new List<string>();
            foreach(var pair in roles)
            {
                if (pair.Value)
                {
                    collectedRoles.Add(pair.Key);
                }
            }
            return collectedRoles;
        }
    }
}

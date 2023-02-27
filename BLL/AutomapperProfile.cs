using AutoMapper;
using DAL.Entities;
using BLL.DTO;

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
        }
    }
}

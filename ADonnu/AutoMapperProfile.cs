using AutoMapper;
using BLL.DTO;
using ADonnu.Models;

namespace ADonnu
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AuthenticationResponseModel, AuthenticationResponseDTO>().ReverseMap();
            CreateMap<UserModel, UserDTO>().ReverseMap();
            CreateMap<StudentModel, StudentDTO>().ReverseMap();
            CreateMap<IndScheduleRequestModel, IndScheduleRequestDTO>().ReverseMap();
        }
    }
}

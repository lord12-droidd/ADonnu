using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AdminService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<UserDTO> CreateUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> DeleteUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var userEntities = _unitOfWork.UserRepository.FindAll();
            var userDTOs = _mapper.Map<List<UserDTO>>(userEntities);
            foreach (var user in userDTOs)
            {
                var roles = await _unitOfWork.UserRepository.GetUserRolesByEmailAsync(user.Email);
                user.Roles = roles;
            }
            
            return userDTOs;
        }

        public Task<UserDTO> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> UpdateUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}

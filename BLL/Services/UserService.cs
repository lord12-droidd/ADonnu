using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IdentityResult> AddAsync(UserDTO userDTO)
        {
            var res = await _unitOfWork.UserRepository.AddAsync(_mapper.Map<UserEntity>(userDTO), userDTO.Password);
            return res;
        }

        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            var userEntity = await _unitOfWork.UserRepository.GetUserByEmailAsync(email);
            var userDTO = _mapper.Map<UserDTO>(userEntity);
            userDTO.Roles = await _unitOfWork.UserRepository.GetUserRolesByEmailAsync(email);
            return userDTO;
        }

        public async Task<bool> CheckPasswordAsync(string email, string password)
        {
            var userEntity = await _unitOfWork.UserRepository.GetUserByEmailAsync(email);
            var res = await _unitOfWork.UserRepository.CheckUserPasswordAsync(userEntity, password);
            return res;
        }
    }
}
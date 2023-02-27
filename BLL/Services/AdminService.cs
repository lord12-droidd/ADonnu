using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
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

        public async Task<bool> DeleteUserByEmailAsync(string email)
        {
            var deletedUserEntity = await _unitOfWork.UserRepository.DeleteUserByEmail(email);
            return deletedUserEntity.Succeeded;
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

        public async Task<UpdateStudentUserDTO> UpdateUserByEmailAsync(string email, UpdateStudentUserDTO updateUserStudentData)
        {
            var userEntity = await _unitOfWork.UserRepository.GetUserByEmailAsync(email);
            var currentUserRoles = await _unitOfWork.UserRepository.GetUserRolesByEmailAsync(email);
            var studentEntityToUpdate = await _unitOfWork.StudentRepository.GetStudentByIdAsync(userEntity.Id);
            var newStudentEntity = _mapper.Map<StudentEntity>(updateUserStudentData);
            newStudentEntity.Id = studentEntityToUpdate.Id;

            if (currentUserRoles.Contains("Student") && !updateUserStudentData.Roles.Contains("Student"))
            {
                var deletedStudent = await _unitOfWork.StudentRepository.DeleteStudentByIdAsync(studentEntityToUpdate.Id);
                await _unitOfWork.UserRepository.UpdateUserRolesAsync(email, updateUserStudentData.Roles);
                return _mapper.Map<UpdateStudentUserDTO>(deletedStudent);
            }
            if (!currentUserRoles.Contains("Student") && updateUserStudentData.Roles.Contains("Student"))
            {
                var addedStudent = await _unitOfWork.StudentRepository.AddStudentByIdAsync(userEntity.Id);
                await _unitOfWork.UserRepository.UpdateUserRolesAsync(email, updateUserStudentData.Roles);
                return _mapper.Map<UpdateStudentUserDTO>(addedStudent);
            }

            var updatedStudent = await _unitOfWork.StudentRepository.UpdateStudentAsync(newStudentEntity);
            await _unitOfWork.UserRepository.UpdateUserRolesAsync(email, updateUserStudentData.Roles);
            return _mapper.Map<UpdateStudentUserDTO>(updatedStudent);


        }
    }
}

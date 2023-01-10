using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<StudentDTO> GetUserByEmailAsync(string email)
        {
            var userEntity = await _unitOfWork.UserRepository.GetUserByEmailAsync(email);
            if (userEntity == null)
            {
                return null;
            }
            var studentEntity = await _unitOfWork.StudentRepository.GetUserByIdAsync(userEntity.Id);
            return _mapper.Map<StudentDTO>(studentEntity);
        }

        public async Task<StudentDTO> UpdateStudentAsync(StudentDTO studentDTO, string email)
        {
            var userEntity = await _unitOfWork.UserRepository.GetUserByEmailAsync(email);
            if (userEntity == null)
            {
                return null;
            }
            var studentEntity = await _unitOfWork.StudentRepository.FindAll().AsNoTracking().FirstOrDefaultAsync(student => student.Id == userEntity.Id);
            var newStudentEntity = _mapper.Map<StudentEntity>(studentDTO);
            newStudentEntity.Id = studentEntity.Id;
            newStudentEntity.UserEntity = studentEntity.UserEntity;
            var updatedStudent = await _unitOfWork.StudentRepository.UpdateStudentAsync(newStudentEntity);
            return _mapper.Map<StudentDTO>(updatedStudent);
        }
    }
}

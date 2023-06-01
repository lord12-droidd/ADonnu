using AutoMapper;
using Azure.Storage.Blobs;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<TeachersStudentIndScheduleRequestDTO>> GetStudentsWithRequests(string teacherEmail)
        {
            var teacherUserEntity = await _unitOfWork.UserRepository.GetUserByEmailAsync(teacherEmail);
            var teacherEntity = await _unitOfWork.TeacherRepository.GetTeacherByIdAsync(teacherUserEntity.Id);
            var studentsRequestsIds = teacherEntity.TeacherIndScheduleRequests.Where(ti => ti.TeacherId == teacherEntity.Id).Select(cti => cti.IndScheduleRequestId).ToList();
            var teacherStudentsInfo = new List<TeachersStudentIndScheduleRequestDTO>();
            for (int i = 0; i < studentsRequestsIds.Count; i++)
            {
                var studentEntity = await _unitOfWork.StudentRepository.GetStudentByIdAsync(studentsRequestsIds[i]);
                var studentEmail = _unitOfWork.UserRepository.FindAll().FirstOrDefault(u => u.Id == studentEntity.Id).Email;
                teacherStudentsInfo.Add(new TeachersStudentIndScheduleRequestDTO { StudentName = $"{studentEntity.Surname} {studentEntity.Name} {studentEntity.MiddleName}", StudentEmail = studentEmail });
            }
            return teacherStudentsInfo;
        }
    }
}

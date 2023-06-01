using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SubjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<SubjectDTO>> GetAllSubjects()
        {
            return _mapper.Map<List<SubjectDTO>>(await _unitOfWork.SubjectRepository.GetAllSubjects());
        }

        public async Task<List<SubjectDTO>> GetStudentSubjectsByEmail(string email)
        {
            var subjectEntities = await _unitOfWork.SubjectRepository.GetStudentSubjects(email);
            var subjectDtos = _mapper.Map<List<SubjectDTO>>(subjectEntities);
            for (int i = 0; i < subjectEntities.Count; i++)
            {
                for (int j = 0; j < subjectEntities[i].TeacherSubjects.Count; j++)
                {
                    subjectDtos[i].Teachers[j].Email = subjectEntities[i].TeacherSubjects[j].Teacher.UserEntity.Email;
                }
            }

            //subjectEntities[0].TeacherSubjects[0].Teacher.UserEntity.Email;
            //return _mapper.Map<List<SubjectDTO>>(await _unitOfWork.SubjectRepository.GetStudentSubjects(email));
            return subjectDtos;
        }
    }
}

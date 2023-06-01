using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISubjectService
    {
        Task<List<SubjectDTO>> GetAllSubjects();
        Task<List<SubjectDTO>> GetStudentSubjectsByEmail(string email);
    }
}

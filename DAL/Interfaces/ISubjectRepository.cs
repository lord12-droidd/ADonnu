using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISubjectRepository : IRepository<SubjectEntity>
    {
        Task<IList<SubjectEntity>> GetAllSubjects();
        Task<IList<SubjectEntity>> GetStudentSubjects(string email);
    }
}

using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStudentRepository : IRepository<StudentEntity>
    {
        Task<StudentEntity> GetUserByIdAsync(string id);
        Task<StudentEntity> UpdateStudentAsync(StudentEntity newStudentEntity);
    }
}

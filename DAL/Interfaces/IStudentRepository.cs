using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStudentRepository : IRepository<StudentEntity>
    {
        Task<StudentEntity> GetStudentByIdAsync(string id);
        Task<StudentEntity> UpdateStudentAsync(StudentEntity newStudentEntity);
        Task<StudentEntity> DeleteStudentByIdAsync(string id);
        Task<StudentEntity> AddStudentByIdAsync(string id);
    }
}

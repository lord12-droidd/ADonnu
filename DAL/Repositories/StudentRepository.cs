using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class StudentRepository : Repository<StudentEntity>, IStudentRepository
    {

        public StudentRepository(AppDBContext context) : base(context)
        {

        }

        public async Task<StudentEntity> GetUserByIdAsync(string id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<StudentEntity> UpdateStudentAsync(StudentEntity newStudentEntity)
        {
            var updatedStudent = _context.Students.Update(newStudentEntity).Entity;
            await _context.SaveChangesAsync();
            return updatedStudent;
        }
    }
}

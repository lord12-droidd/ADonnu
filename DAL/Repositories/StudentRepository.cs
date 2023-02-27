using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<StudentEntity> AddStudentByIdAsync(string id)
        {
            var addedStudent = _context.Students.Add(new StudentEntity { Id = id }).Entity;
            await _context.SaveChangesAsync();
            return addedStudent;
        }

        public async Task<StudentEntity> DeleteStudentByIdAsync(string id)
        {
            var deletedStudent = _context.Students.Remove(await GetStudentByIdAsync(id)).Entity;
            await _context.SaveChangesAsync();
            return deletedStudent;
        }

        public async Task<StudentEntity> GetStudentByIdAsync(string id)
        {
            return await _context.Students.AsNoTracking().FirstOrDefaultAsync(student => student.Id == id);
        }

        public async Task<StudentEntity> UpdateStudentAsync(StudentEntity newStudentEntity)
        {
            var updatedStudent = _context.Students.Update(newStudentEntity).Entity;
            await _context.SaveChangesAsync();
            return updatedStudent;
        }
    }
}

using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SubjectRepository : Repository<SubjectEntity>, ISubjectRepository
    {
        public SubjectRepository(AppDBContext context) : base(context)
        {

        }
        public async Task<IList<SubjectEntity>> GetAllSubjects()
        {
            return await _context.Subjects.AsNoTracking()
                .Include(subject => subject.StudentSubjects).ThenInclude(s => s.Student)
                .Include(subject => subject.TeacherSubjects).ThenInclude(s => s.Teacher)
                .ToListAsync();
        }

        public async Task<IList<SubjectEntity>> GetStudentSubjects(string email)
        {
            var student = await _context.ApplicationUsers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Email == email);

            return await _context.StudentSubjects
                .AsNoTracking()
                .Include(b => b.Subject)
                .ThenInclude(n => n.TeacherSubjects)
                .ThenInclude(n => n.Teacher)
                .ThenInclude(n => n.UserEntity) // 
                .Where(v => v.Student.Id == student.Id)
                .Select(c => c.Subject)
                .ToListAsync();
        }
    }
}

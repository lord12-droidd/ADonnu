using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TeacherRepository : Repository<TeacherEntity>, ITeacherRepository
    {
        public TeacherRepository(AppDBContext context) : base(context)
        {

        }

        public async Task<TeacherEntity> GetTeacherByIdAsync(string id)
        {
            return await _context.Teachers.AsNoTracking()
                .Include(t => t.TeacherIndScheduleRequests)
                .FirstOrDefaultAsync(teacher => teacher.Id == id);
        }
    }
}

using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class IndScheduleRequestRepository : Repository<IndScheduleRequestEntity>, IIndScheduleRequestRepository
    {
        public IndScheduleRequestRepository(AppDBContext context) : base(context)
        {

        }

        public async Task<IndScheduleRequestEntity> CreateIndScheduleRequestRecord(string studentRecordId, string azureAccessPath)
        {
            var addedRecord = new IndScheduleRequestEntity() { Id = studentRecordId, AzureAccessPath = azureAccessPath };
            await _context.IndScheduleRequests.AddAsync(addedRecord);
            await _context.SaveChangesAsync();
            return addedRecord;
        }

        public async Task<IndScheduleRequestTeacherEntity> CreateIndScheduleRequestTeacherEntityRecord(string studentRecordId, string teacherId, int teacherPosition)
        {
            var newRecord = new IndScheduleRequestTeacherEntity() { IndScheduleRequestId = studentRecordId, TeacherId = teacherId, TeacherPosition = teacherPosition };
            await _context.AddAsync(newRecord);
            await _context.SaveChangesAsync();
            return newRecord;
        }

        public async Task<IndScheduleRequestTeacherEntity> DeleteIndScheduleRequestTeacherEntityRecord(string studentRecordId, string teacherId)
        {
            var recordToDelete = await _context.IndScheduleRequestTeachers.FindAsync(studentRecordId, teacherId);
             _context.Remove(recordToDelete);
            await _context.SaveChangesAsync();
            return recordToDelete;
        }

        public async Task<IList<IndScheduleRequestEntity>> GetApprovedIndScheduleRequestRecords()
        {
            var indScheduleRequests = await _context.IndScheduleRequests.AsNoTracking().ToListAsync();
            var indScheduleRequestTeacherEntities = await _context.IndScheduleRequestTeachers.AsNoTracking().ToListAsync();
            var res = new List<IndScheduleRequestEntity>();
            for (int i = 0; i < indScheduleRequests.Count; i++)
            {
                for (int j = 0; j < indScheduleRequestTeacherEntities.Count; j++)
                {
                    if (indScheduleRequests[i].Id == indScheduleRequestTeacherEntities[j].IndScheduleRequestId)
                    {
                        break;
                    }
                }
                res.Add(indScheduleRequests[i]);
            }
            return res;
        }

        public async Task<IndScheduleRequestTeacherEntity> GetIndScheduleRequestTeacherEntityById(string studentRecordId, string teacherId)
        {
            return await _context.IndScheduleRequestTeachers.AsNoTracking().FirstOrDefaultAsync(record => record.IndScheduleRequestId == studentRecordId && record.TeacherId == teacherId);
        }
    }
}

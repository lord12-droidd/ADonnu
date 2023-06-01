using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IIndScheduleRequestRepository
    {
        Task<IndScheduleRequestEntity> CreateIndScheduleRequestRecord(string studentRecordId, string azureAccessPath);
        Task<IndScheduleRequestTeacherEntity> CreateIndScheduleRequestTeacherEntityRecord(string studentRecordId, string teacherId, int teacherPosition);
        Task<IndScheduleRequestTeacherEntity> DeleteIndScheduleRequestTeacherEntityRecord(string studentRecordId, string teacherId);
        Task<IndScheduleRequestTeacherEntity> GetIndScheduleRequestTeacherEntityById(string studentRecordId, string teacherId);
        Task<IList<IndScheduleRequestEntity>> GetApprovedIndScheduleRequestRecords();
    }
}

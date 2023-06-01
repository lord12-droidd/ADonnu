using BLL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IIndScheduleRequestService
    {
        public Task<byte[]> CreateIndScheduleRequestFile(IndScheduleRequestDTO studentRequestInfo, string email);
        Task<bool> ApproveIndScheduleRequest(ApproveIndScheduleRequestDTO approveIndScheduleRequestDTO, string teacherEmail, string studentEmail);
        Task<IList<ApprovedIndScheduleRequestDTO>> GetApprovedIndScheduleRequest();
    }
}

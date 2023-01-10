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
        public Task<string> CreateIndScheduleRequestFile(IndScheduleRequestDTO studentRequestInfo);
        Task<MemoryStream> GetFileFromStorage(string filePath);
    }
}

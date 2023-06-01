using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ApprovedIndScheduleRequestDTO
    {
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string FilledRequestDownloadPath { get; set; }
        public string AddsDownloadPath { get; set; }
    }
}

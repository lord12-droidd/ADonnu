using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDTO> GetUserByEmailAsync(string email);
        Task<StudentDTO> UpdateStudentAsync(StudentDTO studentDTO, string email);
    }
}

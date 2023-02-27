using BLL.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAdminService
    {
        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserByEmailAsync(string email);
        Task<bool> DeleteUserByEmailAsync(string email);
        Task<UpdateStudentUserDTO> UpdateUserByEmailAsync(string email, UpdateStudentUserDTO updateUserStudentData);
        Task<UserDTO> CreateUserByEmailAsync(string email);
    }
}

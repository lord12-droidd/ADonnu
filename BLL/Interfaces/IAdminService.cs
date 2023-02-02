using BLL.DTO;
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
        Task<UserDTO> DeleteUserByEmailAsync(string email);
        Task<UserDTO> UpdateUserByEmailAsync(string email);
        Task<UserDTO> CreateUserByEmailAsync(string email);
    }
}

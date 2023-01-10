using BLL.DTO;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> AddAsync(UserDTO userDTO);
        Task<UserDTO> GetUserByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(string email, string password);
    }
}

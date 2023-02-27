using BLL.DTO;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IJwtService
    {
        public Task<AuthenticationResponseDTO> CreateToken(UserDTO user, IList<string> roles);

    }
}

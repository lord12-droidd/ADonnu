using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<IdentityResult> AddAsync(UserEntity entity, string password);

        Task<UserEntity> GetUserByEmailAsync(string email);

        Task<IList<string>> GetUserRolesByEmailAsync(string email);
        Task<bool> CheckUserPasswordAsync(UserEntity entity, string password);

    }
}

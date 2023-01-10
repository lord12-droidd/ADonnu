using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{

    public class UserRepository : Repository<UserEntity>, IUserRepository
    {

        public UserRepository(AppDBContext context, UserManager<UserEntity> _userManager) : base(context, _userManager)
        {

        }
        public async Task<IdentityResult> AddAsync(UserEntity entity, string password)
        {
            entity.UserName = entity.Email;
            var result = await _userManager.CreateAsync(entity, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(entity, "Student");
                await _context.Students.AddAsync(new StudentEntity { UserEntity = entity });
                await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            var res = await _userManager.FindByEmailAsync(email);
            return res;
        }

        public async Task<IList<string>> GetUserRolesByEmailAsync(string email)
        {
            var res = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(res);
            return roles;
        }

        public async Task<bool> CheckUserPasswordAsync(UserEntity entity, string password)
        {
            var result = await _userManager.CheckPasswordAsync(entity, password);
            return result;
        }
    }
}

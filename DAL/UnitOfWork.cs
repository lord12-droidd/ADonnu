using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManager<UserEntity> _userManager;

        private readonly AppDBContext _context;

        public IUserRepository UserRepository { get; }
        public IStudentRepository StudentRepository { get; }
        public ISubjectRepository SubjectRepository { get; }

        public UnitOfWork(AppDBContext context, UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
            _context = context;
            UserRepository = new UserRepository(_context, _userManager);
            StudentRepository = new StudentRepository(_context);
        }
    }
}

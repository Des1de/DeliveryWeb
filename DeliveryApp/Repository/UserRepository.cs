using DeliveryApp.Data;
using DeliveryApp.Interfaces;
using DeliveryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(AppUser user)
        {
            _context.Add(user);
            return Save();
        }

        public bool Delete(AppUser user)
        {
            _context.Remove(user);
            return Save();
        }

        public bool Edit(AppUser user)
        {
            _context.Update(user);
            return Save();
        }

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            return await _context.AppUsers.ToListAsync();
        }

        public async Task<IEnumerable<AppUser>> GetAllUsersNoTracking()
        {
            return await _context.AppUsers.AsNoTracking().ToListAsync();
        }

        public async Task<AppUser> GetUserById(string id)
        {
            return await _context.AppUsers.FindAsync(id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

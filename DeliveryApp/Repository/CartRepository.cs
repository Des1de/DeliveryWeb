using DeliveryApp.Data;
using DeliveryApp.Interfaces;
using DeliveryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            return await _context.Carts.ToListAsync();
        }
        public async Task<IEnumerable<Cart>> GetAllNoTracking()
        {
            return await _context.Carts.AsNoTracking().ToListAsync();
        }
        public async Task<Cart> GetByIdAsync(int id)
        {
            return await _context.Carts.FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<Cart> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Carts.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }
        public bool Add(Cart cart)
        {
            _context.Add(cart);
            return Save();
        }
        public bool Edit(Cart cart)
        {
            _context.Update(cart);
            return Save();
        }
        public bool Delete(Cart cart)
        {
            _context.Remove(cart);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Cart cart)
        {
            _context.Update(cart);
            return Save();
        }

        public async Task<Cart> GetByUserIdAsync(string userId)
        {
            AppUser user = await _context.AppUsers.FirstOrDefaultAsync(i => i.Id == userId);
            Cart cart = await _context.Carts.FirstOrDefaultAsync(i => i.Id == user.CartId);
            return cart;
        }
    }
}

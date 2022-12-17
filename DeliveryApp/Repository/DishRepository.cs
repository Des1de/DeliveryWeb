using DeliveryApp.Data;
using DeliveryApp.Interfaces;
using DeliveryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository
{
    public class DishRepository : IDishRepository
    {
        private readonly ApplicationDbContext _context;

        public DishRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dish>> GetAll()
        {
            return await _context.Dishes.ToListAsync();
        }
        public async Task<IEnumerable<Dish>> GetAllNoTracking()
        {
            return await _context.Dishes.AsNoTracking().ToListAsync();
        }
        public async Task<Dish> GetByIdAsync(int id)
        {
            return await _context.Dishes.FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<Dish> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Dishes.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }
        public bool Add(Dish dish)
        {
            _context.Add(dish);
            return Save();
        }
        public bool Edit(Dish dish)
        {
            _context.Update(dish);
            return Save();
        }
        public bool Delete(Dish dish)
        {
            _context.Remove(dish);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

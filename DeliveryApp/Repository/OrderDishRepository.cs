using DeliveryApp.Data;
using DeliveryApp.Interfaces;
using DeliveryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository
{
    public class OrderDishRepository : IOrderDishRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderDishRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderDish>> GetAll()
        {
            return await _context.OrderDishes.ToListAsync();
        }
        public async Task<IEnumerable<OrderDish>> GetAllNoTracking()
        {
            return await _context.OrderDishes.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<OrderDish>> GetAllByOrderId(int id)
        {
            return await _context.OrderDishes.Where(i => i.OrderId == id).ToListAsync();
        }


        public async Task<OrderDish> GetByIdAsync(int id)
        {
            return await _context.OrderDishes.FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<OrderDish> GetByIdAsyncNoTracking(int id)
        {
            return await _context.OrderDishes.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }
        public bool Add(OrderDish orderDish)
        {
            _context.Add(orderDish);
            return Save();
        }
        public bool Edit(OrderDish orderDish)
        {
            _context.Update(orderDish);
            return Save();
        }
        public bool Delete(OrderDish orderDish)
        {
            _context.Remove(orderDish);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(OrderDish orderDish)
        {
            _context.Update(orderDish);
            return Save();
        }

        public async Task<Dish> GetDishByDishId(int dishId)
        {
            return await _context.Dishes.FirstOrDefaultAsync(i => i.Id == dishId);
        }
    }
}

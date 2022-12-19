﻿using DeliveryApp.Data;
using DeliveryApp.Interfaces;
using DeliveryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository
{
    public class CartDishRepository : ICartDishRepository
    {
        private readonly ApplicationDbContext _context;

        public CartDishRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CartDish>> GetAll()
        {
            return await _context.CartDishes.ToListAsync();
        }
        public async Task<IEnumerable<CartDish>> GetAllNoTracking()
        {
            return await _context.CartDishes.AsNoTracking().ToListAsync();
        }
        public async Task<CartDish> GetByIdAsync(int id)
        {
            return await _context.CartDishes.FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<CartDish> GetByIdAsyncNoTracking(int id)
        {
            return await _context.CartDishes.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }
        public bool Add(CartDish cartDish)
        {
            _context.Add(cartDish);
            return Save();
        }
        public bool Edit(CartDish cartDish)
        {
            _context.Update(cartDish);
            return Save();
        }
        public bool Delete(CartDish cartDish)
        {
            _context.Remove(cartDish);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(CartDish cartDish)
        {
            _context.Update(cartDish);
            return Save();
        }
    }
}

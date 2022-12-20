using DeliveryApp.Models;

namespace DeliveryApp.Interfaces
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetAll();
        Task<IEnumerable<Cart>> GetAllNoTracking();
        Task<Cart> GetByIdAsync(int id);
        Task<Cart> GetByIdAsyncNoTracking(int id);

        Task<Cart> GetByUserIdAsync(string userId);

        bool Update(Cart cart);
        bool Add(Cart cart);
        bool Edit(Cart cart);
        bool Delete(Cart cart);
        bool Save();
    }
}

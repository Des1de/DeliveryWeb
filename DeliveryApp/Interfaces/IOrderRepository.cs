using DeliveryApp.Models;

namespace DeliveryApp.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();
        Task<IEnumerable<Order>> GetAllNoTracking();
        Task<Order> GetByIdAsync(int id);
        Task<Order> GetByIdAsyncNoTracking(int id);

        Task<IEnumerable<Order>> GetAllByUserId(string userId);

        bool Update(Order order);
        bool Add(Order order);
        bool Edit(Order order);
        bool Delete(Order order);
        bool Save();
    }
}

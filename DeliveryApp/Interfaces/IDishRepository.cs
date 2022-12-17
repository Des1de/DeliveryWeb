using DeliveryApp.Models;

namespace DeliveryApp.Interfaces
{
    public interface IDishRepository
    {
        Task<IEnumerable<Dish>> GetAll();
        Task<IEnumerable<Dish>> GetAllNoTracking();
        Task<Dish> GetByIdAsync(int id);
        Task<Dish> GetByIdAsyncNoTracking(int id);
        bool Add(Dish dish);
        bool Edit(Dish dish);
        bool Delete(Dish dish);
        bool Save();
    }
}

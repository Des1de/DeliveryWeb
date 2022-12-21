using DeliveryApp.Models;

namespace DeliveryApp.Interfaces
{
    public interface IOrderDishRepository
    {
        Task<IEnumerable<OrderDish>> GetAll();
        Task<IEnumerable<OrderDish>> GetAllNoTracking();
        Task<OrderDish> GetByIdAsync(int id);
        Task<OrderDish> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<OrderDish>> GetAllByOrderId(int id);

        Task<Dish> GetDishByDishId(int dishId);

        bool Update(OrderDish orderDish);
        bool Add(OrderDish orderDish);
        bool Edit(OrderDish ordertDish);
        bool Delete(OrderDish orderDish);
        bool Save();
    }
}

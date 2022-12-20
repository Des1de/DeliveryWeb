using DeliveryApp.Models;

namespace DeliveryApp.Interfaces
{
    public interface ICartDishRepository
    {
        Task<IEnumerable<CartDish>> GetAll();
        Task<IEnumerable<CartDish>> GetAllNoTracking();
        Task<CartDish> GetByIdAsync(int id);
        Task<CartDish> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<CartDish>> GetAllByCartId(int id);

        Task<Dish> GetDishByDishId(int dishId);

        bool Update(CartDish cartDish);
        bool Add(CartDish cartDish);
        bool Edit(CartDish cartDish);
        bool Delete(CartDish cartDish);
        bool Save();
    }
}

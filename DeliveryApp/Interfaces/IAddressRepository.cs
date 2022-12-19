using DeliveryApp.Models;

namespace DeliveryApp.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAll();
        Task<IEnumerable<Address>> GetAllNoTracking();
        Task<Address> GetByIdAsync(int id);
        Task<Address> GetByIdAsyncNoTracking(int id);

        bool Update(Address address);
        bool Add(Address address);
        bool Edit(Address address);
        bool Delete(Address address);
        bool Save();
    }
}

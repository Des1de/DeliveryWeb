using DeliveryApp.Models;

namespace DeliveryApp.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsers();
        Task<IEnumerable<AppUser>> GetAllUsersNoTracking();
        Task<AppUser> GetUserById(string id);
        bool Add(AppUser user);
        bool Edit(AppUser user);
        bool Delete(AppUser user);
        bool Save();
    }
}

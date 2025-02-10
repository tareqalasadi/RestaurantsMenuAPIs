using RestaurantsMenu.Models;

namespace RestaurantsAdmin.Repository
{
    public interface IAdminService
    {
        Task<User?> GetUserByUserNameAsync(string userName);

    }
}

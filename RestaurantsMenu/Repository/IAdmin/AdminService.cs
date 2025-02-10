using Microsoft.EntityFrameworkCore;
using RestaurantsMenu.Models;
using RestaurantsMenu.Repository;

namespace RestaurantsAdmin.Repository
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<User> _repository;

        public AdminService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<User?> GetUserByUserNameAsync(string userName)
        {
            var users = await _repository.GetAllAsync();
            return users.FirstOrDefault(u => u.UserName == userName);
        }
    }
}

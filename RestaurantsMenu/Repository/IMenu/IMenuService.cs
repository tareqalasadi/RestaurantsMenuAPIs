using RestaurantsMenu.Models;

namespace RestaurantsMenu.Repository
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> GetAllMenusAsync();
        Task<Menu?> GetMenuByIdAsync(int id);
        Task<bool> AddMenuAsync(Menu employee);
        Task<bool> UpdateMenuAsync(Menu employee);
        Task<bool> DeleteMenuAsync(int id);
    }
}

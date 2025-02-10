using RestaurantsMenu.Models;

namespace RestaurantsMenu.Repository
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<Menu> _repository;

        public MenuService(IRepository<Menu> repository) 
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Menu>> GetAllMenusAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Menu?> GetMenuByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> AddMenuAsync(Menu employee)
        {
            await _repository.AddAsync(employee);
            return await _repository.SaveAsync();
        }

        public async Task<bool> UpdateMenuAsync(Menu employee)
        {
            await _repository.UpdateAsync(employee);
            return await _repository.SaveAsync();
        }

        public async Task<bool> DeleteMenuAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return await _repository.SaveAsync();
        }
    }
}

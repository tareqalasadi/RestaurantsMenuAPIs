using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantsMenu.General;
using Serilog;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestaurantsMenu.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                int row = await _context.SaveChangesAsync();
                return row >= 0;
            }
            catch (DbUpdateConcurrencyException DbUpdateConcurrencyException)
            {
                Log.Error($"Exception DbUpdateConcurrencyException >> \n  {DbUpdateConcurrencyException.Message.ToString()}", DbUpdateConcurrencyException.Message.Replace(Environment.NewLine, " "), DbUpdateConcurrencyException.StackTrace.Replace(Environment.NewLine, " "));
                return false;
            }
            catch (DbUpdateException DbUpdateException)
            {
                Log.Error($"Exception DbUpdateException >> \n  {DbUpdateException?.InnerException?.InnerException?.Message.ToString()}", DbUpdateException.Message.Replace(Environment.NewLine, " "), DbUpdateException.StackTrace.Replace(Environment.NewLine, " "));
                return false;
            }
            catch (NotSupportedException NotSupportedException)
            {
                Log.Error($"Exception NotSupportedException >> \n  {NotSupportedException.Message.ToString()}", NotSupportedException.Message.Replace(Environment.NewLine, " "), NotSupportedException.StackTrace.Replace(Environment.NewLine, " "));
                return false;
            }
            catch (ObjectDisposedException ObjectDisposedException)
            {
                Log.Error($"Exception ObjectDisposedException >> \n  {ObjectDisposedException.Message.ToString()}", ObjectDisposedException.Message.Replace(Environment.NewLine, " "), ObjectDisposedException.StackTrace.Replace(Environment.NewLine, " "));
                return false;
            }
            catch (InvalidOperationException InvalidOperationException)
            {
                Log.Error($"Exception InvalidOperationException >> \n  {InvalidOperationException.Message.ToString()}", InvalidOperationException.Message.Replace(Environment.NewLine, " "), InvalidOperationException.StackTrace.Replace(Environment.NewLine, " "));
                return false;
            }
        }
    }
}

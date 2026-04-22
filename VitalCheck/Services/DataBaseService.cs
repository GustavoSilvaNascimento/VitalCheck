using VitalCheck.Data.Interfaces;
using VitalCheck.Data.SqLite;

namespace VitalCheck.Services
{
    public class DataBaseService<T> : ICrud<T> where T : new()
    {
        protected readonly SqLiteDataBase _database;

        public DataBaseService(SqLiteDataBase database)
        {
            _database = database;
        }

        public virtual async Task InsertAsync(T item)
        {
            await _database.InsertAsync(item);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _database.GetAllAsync<T>();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _database.GetByIdAsync<T>(id);
        }

        public virtual async Task UpdateAsync(T item)
        {
            await _database.UpdateAsync(item);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var item = await _database.GetByIdAsync<T>(id);

            if (item != null)
                await _database.DeleteAsync(item);
        }
    }
}
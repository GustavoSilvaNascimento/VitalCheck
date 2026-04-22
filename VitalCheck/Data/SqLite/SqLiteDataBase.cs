using SQLite;
using VitalCheck.Model;

namespace VitalCheck.Data.SqLite
{
    public class SqLiteDataBase
    {
        private readonly SQLiteAsyncConnection _database;
        private bool _initialized = false;

        public SqLiteDataBase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
        }

        
        public async Task InitAsync()
        {
            if (_initialized)
                return;

            var tabelas = new Type[]
            {
                typeof(Usuario),
                typeof(CheckIn)
            };

            foreach (var tabela in tabelas)
            {
                await _database.CreateTableAsync(tabela);
            }

            _initialized = true;
        }

        public async Task<int> InsertAsync<T>(T item) where T : new()
        {
            await InitAsync();
            return await _database.InsertAsync(item);
        }

        public async Task<int> UpdateAsync<T>(T item) where T : new()
        {
            await InitAsync();
            return await _database.UpdateAsync(item);
        }

        public async Task<int> DeleteAsync<T>(T item) where T : new()
        {
            await InitAsync();
            return await _database.DeleteAsync(item);
        }

        public async Task<List<T>> GetAllAsync<T>() where T : new()
        {
            await InitAsync();
            return await _database.Table<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : new()
        {
            await InitAsync();
            return await _database.FindAsync<T>(id);
        }
    }
}
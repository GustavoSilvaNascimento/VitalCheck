

using SQLite;
using System.Linq.Expressions;
using VitalCheck.model.DataBases;

namespace VitalCheck.Data.DataBase
{
    public class SQLiteConnection<T> where T : BaseSQLiteModel, new()
    {
        private SQLiteAsyncConnection _connection;
        public SQLiteConnection() 
        {
        }
        public async Task Init()
        {
            if (_connection != null)
                return;

            _connection = new SQLiteAsyncConnection(GlobalSettings.DatabasePath, GlobalSettings.Flags);

            // Criar tabelas
            await VerifyTable();
        }
        public async Task VerifyTable()
        {

            var tableInfo = await _connection.GetTableInfoAsync(typeof(T).Name);
            if (tableInfo.Count == 0)
            {
                await _connection.CreateTableAsync<T>();
            }
        }
        //CRUD
        #region CRUD
        public async Task<List<T>> GetAllAsync()
        {
            await Init();
            return await _connection.Table<T>().ToListAsync();
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predExpre)
        {
            await Init();
            return await _connection.Table<T>().Where(predExpre).FirstOrDefaultAsync();
        }
        public async Task<List<T>> ListAsync(Expression<Func<T, bool>> predExpre)
        {
            await Init();
            return await _connection.Table<T>().Where(predExpre).ToListAsync();
        }
        public async Task<int> AddAsync(T model)
        {
            await Init();
            return await _connection.InsertAsync(model);
        }
        public async Task<int> UpdateAsync(T model)
        {
            await Init();
            return await _connection.UpdateAsync(model);
        }
        public async Task<int> DeleteAsync(T model)
        {
            await Init();
            return await _connection.DeleteAsync(model);
        }
        #endregion
    }
}
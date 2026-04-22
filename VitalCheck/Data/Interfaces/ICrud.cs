using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalCheck.Data.Interfaces
{
    public interface ICrud<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
    }
}

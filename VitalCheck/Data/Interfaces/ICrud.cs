using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalCheck.Data.Interfaces
{
    internal interface ICrud<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T item);
        Task Update(T item);
        Task Delete(int id);
    }
}

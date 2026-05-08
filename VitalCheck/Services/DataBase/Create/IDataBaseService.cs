using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalCheck.Services.DataBase.Create
{
    public interface IDataBaseService
    {
        Task InitAsync();
        Task<int> AddCheckInAsync(Model.CheckIn checkIn);

    }
}

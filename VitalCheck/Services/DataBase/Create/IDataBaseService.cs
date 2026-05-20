using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalCheck.Model;

namespace VitalCheck.Services.DataBase.Create
{
    public interface IDataBaseService
    {
        Task InitAsync();
        Task AddCheckInAsync(CheckIn checkIn);
        Task<CheckIn?> GetUltimoCheckInAsync(int idUsuario);
        Task AddTreinoAsync(Treino treino);
        Task<List<Treino>> GetTodosTreinosAsync(int idUsuario);

    }
}

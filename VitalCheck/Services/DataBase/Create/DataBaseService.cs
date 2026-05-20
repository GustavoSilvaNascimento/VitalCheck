using VitalCheck.Data.DataBase;
using VitalCheck.Model;
using VitalCheck.Model.Response;

namespace VitalCheck.Services.DataBase.Create
{
    public class DataBaseService : IDataBaseService
    {
        public SQLiteConnection<Usuario> UserConection { get; } =
            new SQLiteConnection<Usuario>();
        public SQLiteConnection<CheckIn> CheckInConection { get; } =
            new SQLiteConnection<CheckIn>();
        public SQLiteConnection<UserToken> UserTokenConnection { get; } =
            new SQLiteConnection<UserToken>();
        public SQLiteConnection<Treino> TreinoConection { get; } =
            new SQLiteConnection<Treino>();

        public DataBaseService()
        {
        }

        public async Task InitAsync()
        {
            await UserConection.Init();
            await CheckInConection.Init();
            await UserTokenConnection.Init();
            await TreinoConection.Init();
        }

        public async Task AddCheckInAsync(CheckIn checkIn)
        {
            await CheckInConection.AddAsync(checkIn);
        }

        public async Task<CheckIn?> GetUltimoCheckInAsync(int idUsuario)
        {
            var todosCheckIns = await CheckInConection.GetAllAsync();

            return todosCheckIns
                .Where(x => x.IdUsuario == idUsuario)
                .OrderByDescending(x => x.Data)
                .FirstOrDefault();
        }

        public async Task AddTreinoAsync(Treino treino)
        {
            await TreinoConection.AddAsync(treino);
        }

        public async Task<List<Treino>> GetTodosTreinosAsync(int idUsuario)
        {
            var todosTreinos = await TreinoConection.GetAllAsync();

            return todosTreinos
                .Where(x => x.IdUsuario == idUsuario)
                .ToList();
        }
    }
}
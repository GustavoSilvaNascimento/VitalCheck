
using VitalCheck.Data.DataBase;
using VitalCheck.model.Response;
using VitalCheck.Model;
using VitalCheck.Services.DataBase.Create;


namespace VitalCheck.Services.DataBase.Create
{

    public class DataBaseService : IDataBaseService
    {

        public SQLiteConnection<Usuario> UserConection = new SQLiteConnection<Usuario>();
        public SQLiteConnection<CheckIn> CheckInConection = new SQLiteConnection<CheckIn>();

        public DataBaseService()
        {

            _ = UserConection.Init();
            _ = CheckInConection.Init();    

        }
    }
}

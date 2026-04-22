using SQLite;

namespace VitalCheck.Model.DataBases
{
    public class BaseSQLiteModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}

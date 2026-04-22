using SQLite;

namespace VitalCheck.model.DataBases
{
    public class BaseSQLiteModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}

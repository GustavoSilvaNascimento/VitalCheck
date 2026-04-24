using SQLite;

namespace VitalCheck.Model.DataBases
{
    public class BaseSQLiteModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}

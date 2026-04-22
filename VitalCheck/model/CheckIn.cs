using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalCheck.Model.DataBases;

namespace VitalCheck.Model
{
    public class CheckIn : BaseSQLiteModel
    {
        public CheckIn()
        {
        }
        public int Id { get; set; }
        public int IdUsuario { get; set; }  
        public DateTime Sono { get; set; }
        public DateTime Data { get; set; }
        public double ScoreEnergia { get; set; }
        public double VitalScore { get; set; }
        public string? Humor { get; set; }
        public string? Atividade { get; set; }
        public string? Sintomas { get; set; }
        
    }
}

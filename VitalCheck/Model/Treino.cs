using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalCheck.Model.DataBases;

namespace VitalCheck.Model
{
    [Table("Treino")]
    public class Treino : BaseSQLiteModel
    {
        public Treino(){
        }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Exercicio1 { get; set; }
        public string Exercicio2 { get; set; }
        public string Exercicio3 { get; set; }
        public string Exercicio4 { get; set; }
        public string Exercicio5 { get; set; }
        public string Exercicio6 { get; set; }

    }
}

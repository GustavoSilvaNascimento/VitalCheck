using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalCheck.Model.DataBases;

namespace VitalCheck.Model.Response
{
    [Table("Usuarios")]

    public class Usuario : BaseSQLiteModel
        {
        public Usuario() { }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public string? UserName { get; set; }
        public int Idade
        {
            get
            {
                var hoje = DateTime.Today;
                var idade = hoje.Year - DataNascimento.Year;

                if (DataNascimento.Date > hoje.AddYears(-idade))
                    idade--;

                return idade;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalCheck.Model
{
    internal class Usuario
        {
        public Usuario() { }
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }   
    }
}

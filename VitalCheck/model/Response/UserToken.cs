using System;
using System.Collections.Generic;
using System.Text;

namespace VitalCheck.Model.Response
{
    public class UserToken
    {
        public int Id { get; set; }

        public string? Nome { get; set; }
        public string? UserName { get; set; }

        public string? Email { get; set; } 

        public string? Senha { get; set; } 

        public string? Genero { get; set; } 

        public DateTime DataNascimento { get; set; }

        public double Peso { get; set; }
        public string? Token { get; set; } 

        public int Idade => CalcularIdade();

        private int CalcularIdade()
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - DataNascimento.Year;

            if (DataNascimento.Date > hoje.AddYears(-idade))
                idade--;

            return idade;
        }
    }
}

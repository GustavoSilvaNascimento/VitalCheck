using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalCheck.Model.DataBases;

namespace VitalCheck.Model
{
    [Table("CheckIn")]
    public class CheckIn : BaseSQLiteModel
    {
        public CheckIn()
        {
        }
        public int IdUsuario { get; set; }  
        public double Sono { get; set; }
        public DateTime Data { get; set; }
        public double ScoreEnergia { get; set; }
        public string? Humor { get; set; }
        public bool Atividade { get; set; }
        public string? Sintomas { get; set; }
        public int VitalScore()
        {
            int score = 0;

            //Logica do Sono (Max: 30 pontos)
            if (Sono >= 7 && Sono <= 9) score += 30;
            else if (Sono >= 5 && Sono < 7) score += 15;
            else if (Sono > 9) score += 20;
            else score += 0;

            //Logica da Energia (Max: 30 pontos)
            int energiaValor = (int)Math.Round(ScoreEnergia);
            score += (energiaValor * 3);

            //Logica do Treino (Max: 20 pontos)
            if (Atividade) score += 20;

            //Logica do Humor (Max: 2o pontos)
            string[] humorPositivo = { "Feliz", "Tranquilo", "Animado" };
            string[] humorNeutro = { "Indiferente", "Neutro", "Entediado" };

            if (humorPositivo.Contains(Humor)) score += 20;
            else if (humorNeutro.Contains(Humor)) score += 10;

            return Math.Clamp(score, 0, 100);
        }

    }
}

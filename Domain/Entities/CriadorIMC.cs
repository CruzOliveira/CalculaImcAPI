using Domain.Base;
using System;

namespace Domain.Entities
{
    public class CriadorIMC : BaseEntity
    {
        public int id_user { get; set; }
        public decimal imc { get; set; }
        public decimal peso { get; set; }
        public decimal altura { get; set; }
        public DateTime dt_calculo { get; set; }
        public string classificado { get; set; }
        public string retorno { get; set; }
        
    }
}

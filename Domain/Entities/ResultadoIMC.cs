using Domain.Base;
using System;

namespace Domain.Entities
{
    public class ResultadoIMC : BaseEntity
    {
        public int id { get; set; }
        public int info_user_id { get; set; }
        public decimal imc { get; set; }
        public DateTime dt_calculo { get; set; }
        public string classificado { get; set; }
        
    }
}

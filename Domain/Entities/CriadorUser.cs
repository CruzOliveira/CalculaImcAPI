using Domain.Base;
using System;

namespace Domain.Entities
{
    public class CriadorUser : BaseEntity
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string retorno { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public decimal peso { get; set; }
        public decimal altura { get; set; }
        public DateTime dt_nacimento { get; set; }
    }
}

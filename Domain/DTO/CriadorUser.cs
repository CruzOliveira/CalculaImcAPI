using Domain.Base;
using System;

namespace Domain.DTO
{
    public class CriadorUser 
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public DateTime dt_nacimento { get; set; }
    }
}

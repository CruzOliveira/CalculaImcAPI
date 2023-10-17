using Domain.Base;

namespace Domain.Entities
{
    public class CriadorUser : BaseEntity
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string peso { get; set; }
        public string altura { get; set; }
        public string dt_nacimento { get; set; }
    }
}

using Domain.Base;

namespace Domain.Entities
{
    public class AlterarSenha : BaseEntity
    {
        
        public int id { get; set; }
        public string senhaAtual { get; set; }
        public string senhaNova { get; set; }
        public string retorno { get; set; }

    }
}

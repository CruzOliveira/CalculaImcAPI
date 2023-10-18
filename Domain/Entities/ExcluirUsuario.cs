using Domain.Base;

namespace Domain.Entities
{
    public class ExcluirUsuario : BaseEntity
    {
        public int id { get; set; }
        public string senha { get; set; }
        public string retorno { get; set; }
    }
}

using Domain.Base;

namespace Domain.Entities
{
    public class AlterarPesoAltura : BaseEntity
    {
        public string cpf { get; set; }
        public string retorno { get; set; }
        public decimal peso { get; set; }
        public decimal altura { get; set; }

    }
}

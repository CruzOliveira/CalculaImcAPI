using Domain.Base;

namespace Domain.Entities
{
    public class ExcluirUsuario : BaseEntity
    {
        //Campos de retorno sem exposi��o na API
        public string Param01 { get; set; }
        public string Param02 { get; set; }
    }
}

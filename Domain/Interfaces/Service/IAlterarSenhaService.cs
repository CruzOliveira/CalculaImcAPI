using Domain.Base;
using Domain.Entities;
using Domain.Interfaces.Service.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IAlterarSenhaService : IService<AlterarSenha>
    {
        Task<Resultado<AlterarSenha>> UpdateAlterarSenhaAsync(int id, string senhaAtual, string senhaNova);
    }
}

using Domain.Entities;
using Domain.Interfaces.Repository.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IAlterarSenhaRepository: IRepository<AlterarSenha>
    {
        Task<AlterarSenha> UpdateAlterarSenhaAsync(int id_user, string senhaAtual, string senhaNova);
    }
}

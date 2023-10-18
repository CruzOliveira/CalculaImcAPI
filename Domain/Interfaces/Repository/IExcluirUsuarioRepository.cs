using Domain.Entities;
using Domain.Interfaces.Repository.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IExcluirUsuarioRepository: IRepository<ExcluirUsuario>
    {
        Task<ExcluirUsuario> DeleteUserAsync(int id, string senha);
    }
}

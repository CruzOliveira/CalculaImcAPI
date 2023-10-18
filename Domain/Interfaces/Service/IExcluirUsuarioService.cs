using Domain.Base;
using Domain.Entities;
using Domain.Interfaces.Service.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IExcluirUsuarioService : IService<ExcluirUsuario>
    {
        Task<Resultado<ExcluirUsuario>> DeleteUserAsync(int id, string senha);
    }
}

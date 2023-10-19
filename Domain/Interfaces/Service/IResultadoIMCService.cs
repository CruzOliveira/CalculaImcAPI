using Domain.Base;
using Domain.Entities;
using Domain.Interfaces.Service.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IResultadoIMCService : IService<ResultadoIMC>
    {
        Task<Resultado<ResultadoIMC>> CreateResultadoAsync(int info_user_id);
    }
}

using Domain.Base;
using Domain.Entities;
using Domain.Interfaces.Service.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface ICriadorIMCService : IService<CriadorIMC>
    {
        Task<Resultado<CriadorIMC>> CreateResultadoAsync(int id_user, decimal peso, decimal altura);
    }
}

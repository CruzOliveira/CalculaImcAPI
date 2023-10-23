using Domain.Entities;
using Domain.Interfaces.Repository.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface ICriadorIMCRepository: IRepository<CriadorIMC>
    {
        Task<CriadorIMC> CreateResultadoAsync(int id_user, decimal peso, decimal altura);
    }
}

using Domain.Entities;
using Domain.Interfaces.Repository.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IResultadoIMCRepository: IRepository<ResultadoIMC>
    {
        Task<ResultadoIMC> CreateResultadoAsync(int info_user_id);
    }
}

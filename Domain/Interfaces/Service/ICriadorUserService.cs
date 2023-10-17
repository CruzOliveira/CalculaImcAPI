using Domain.Base;
using Domain.Entities;
using Domain.Interfaces.Service.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface ICriadorUserService : IService<CriadorUser>
    {
        Task<Resultado<CriadorUser>> CreateUserAsync(CriadorUser entity);
    }
}

using Domain.Entities;
using Domain.Interfaces.Repository.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface ICriadorUserRepository: IRepository<CriadorUser>
    {
        Task<CriadorUser> CreateUserAsync(CriadorUser entity);
    }
}

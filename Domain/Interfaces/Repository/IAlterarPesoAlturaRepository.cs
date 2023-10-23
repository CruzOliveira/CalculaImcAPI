using Domain.Entities;
using Domain.Interfaces.Repository.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IAlterarPesoAlturaRepository: IRepository<AlterarPesoAltura>
    {
        Task<AlterarPesoAltura> UpdatePesoAlturaAsync(int id_user, decimal peso, decimal altura);
    }
}

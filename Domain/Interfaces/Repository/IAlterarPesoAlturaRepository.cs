using Domain.Entities;
using Domain.Interfaces.Repository.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IAlterarPesoAlturaRepository: IRepository<AlterarPesoAltura>
    {
        Task<AlterarPesoAltura> UpdatePesoAlturaAsync(string cpf, decimal peso, decimal altura);
    }
}

using Domain.Base;
using Domain.Entities;
using Domain.Interfaces.Service.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IAlterarPesoAlturaService : IService<AlterarPesoAltura>
    {
        Task<Resultado<AlterarPesoAltura>> UpdatePesoAlturaAsync(int id_user, decimal peso, decimal altura);
    }
}

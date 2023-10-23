using Domain.Base;
using Domain.Entities;
using Domain.Interfaces.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IConsultaUserService : IService<ConsultaUser>
    {
        Task<Resultado<ListConsultaUser>> GetConsultaAsync(int id_user);
    }
}

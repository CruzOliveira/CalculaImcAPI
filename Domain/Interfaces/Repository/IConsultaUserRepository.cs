using Domain.Base;
using Domain.Entities;
using Domain.Interfaces.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IConsultaUserRepository: IRepository<ConsultaUser>
    {
        Task<ListConsultaUser> GetConsultaAsync(int id_user);
    }
}

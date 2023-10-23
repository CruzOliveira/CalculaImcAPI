using Dapper;
using Domain.Base;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ConsultaUserRepository : IConsultaUserRepository
    {
        private readonly IDbConnection dbConnection;
        private bool disposedValue;

        public ConsultaUserRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }


        public async Task<IEnumerable<ConsultaUser>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ConsultaUser> GetAsync(int code)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ConsultaUser>> SelectAsync(ConsultaUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ConsultaUser> CreateAsync(ConsultaUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ConsultaUser> UpdateAsync(ConsultaUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ConsultaUser> DeleteAsync(int code, int user)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {                    
                    dbConnection.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async Task<ListConsultaUser> GetConsultaAsync(int id_user)
        {
            var dynamic = new DynamicParameters();
            var resultado = string.Empty;
            ListConsultaUser List = new ListConsultaUser();

            dynamic.Add("ID_USER", id_user);

            var result = await dbConnection.QueryAsync<string>("IMC_SP_CONSULTA_USUARIO", dynamic, commandType: CommandType.StoredProcedure);

            if (result != null)
            {
             resultado = result.FirstOrDefault();
                
             List = JsonConvert.DeserializeObject<ListConsultaUser>(resultado);
            }
            else
            {
                throw new Exception("Não foram encontrados registros!");
            }

            return List;
        }
    }    
}


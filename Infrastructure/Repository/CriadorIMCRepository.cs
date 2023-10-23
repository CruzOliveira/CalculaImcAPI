using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CriadorIMCRepository : ICriadorIMCRepository
    {
        private readonly IDbConnection dbConnection;
        private bool disposedValue;

        public CriadorIMCRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }


        public async Task<IEnumerable<CriadorIMC>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CriadorIMC> GetAsync(int code)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CriadorIMC>> SelectAsync(CriadorIMC entity)
        {
            throw new NotImplementedException();
        }

        public async Task<CriadorIMC> CreateAsync(CriadorIMC entity)
        {
            throw new NotImplementedException();
        }

        public async Task<CriadorIMC> UpdateAsync(CriadorIMC entity)
        {
            throw new NotImplementedException();
        }

        public async Task<CriadorIMC> DeleteAsync(int code, int user)
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

        public async Task<CriadorIMC> CreateResultadoAsync(int id_user, decimal peso, decimal altura)
        {
            var dynamic = new DynamicParameters();
            var result = new CriadorIMC();

            try
            {
                dynamic.Add("ID_USER", id_user);
                dynamic.Add("PESO", peso);
                dynamic.Add("ALTURA", altura);
                dynamic.Add("retorno", dbType: DbType.String, value: string.Empty, direction: ParameterDirection.Output);

                await dbConnection.ExecuteScalarAsync<CriadorIMC>("IMC_SP_CRIACAO_RESULTADO", dynamic, commandType: CommandType.StoredProcedure);

                result.retorno = dynamic.Get<string>("retorno");
                return result;

            }
            finally
            {
                dynamic = null;


            }
            

        }
    }
}

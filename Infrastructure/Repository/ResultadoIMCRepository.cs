using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ResultadoIMCRepository : IResultadoIMCRepository
    {
        private readonly IDbConnection dbConnection;
        private bool disposedValue;

        public ResultadoIMCRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }


        public async Task<IEnumerable<ResultadoIMC>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResultadoIMC> GetAsync(int code)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ResultadoIMC>> SelectAsync(ResultadoIMC entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultadoIMC> CreateAsync(ResultadoIMC entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultadoIMC> UpdateAsync(ResultadoIMC entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultadoIMC> DeleteAsync(int code, int user)
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

        public async Task<ResultadoIMC> CreateResultadoAsync(int info_user_id)
        {
            var dynamic = new DynamicParameters();
            var result = new ResultadoIMC();

            try
            {
                dynamic.Add("INFO_USER_ID", info_user_id);
                dynamic.Add("retorno", dbType: DbType.String, value: string.Empty, direction: ParameterDirection.Output);

                await dbConnection.ExecuteScalarAsync<ResultadoIMC>("IMC_SP_RESULTADO", dynamic, commandType: CommandType.StoredProcedure);

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

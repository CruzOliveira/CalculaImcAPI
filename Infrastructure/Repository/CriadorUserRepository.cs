using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CriadorUserRepository : ICriadorUserRepository
    {
        private readonly IDbConnection dbConnection;
        private bool disposedValue;

        public CriadorUserRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }


        public async Task<IEnumerable<CriadorUser>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CriadorUser> GetAsync(int code)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CriadorUser>> SelectAsync(CriadorUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<CriadorUser> CreateAsync(CriadorUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<CriadorUser> UpdateAsync(CriadorUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<CriadorUser> DeleteAsync(int code, int user)
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

        public async Task<CriadorUser> CreateUserAsync(CriadorUser entity)
        {
            var dynamic = new DynamicParameters();
            var result = new CriadorUser();

            try
            {
                dynamic.Add("USERNAME", entity.username);
                dynamic.Add("PASSWORD", entity.password);
                dynamic.Add("EMAIL", entity.email);
                dynamic.Add("NOME", entity.nome);
                dynamic.Add("CPF", entity.cpf);
                dynamic.Add("DT_NACIMENTO", entity.dt_nacimento.ToString().Equals("01/01/0001 00:00:00") ? Convert.ToDateTime("1900-01-01") : entity.dt_nacimento);
                dynamic.Add("retorno", dbType: DbType.String, value: string.Empty, direction: ParameterDirection.Output);

                await dbConnection.ExecuteScalarAsync<CriadorUser>("IMC_SP_CRIACAO_USUARIO", dynamic, commandType: CommandType.StoredProcedure);

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

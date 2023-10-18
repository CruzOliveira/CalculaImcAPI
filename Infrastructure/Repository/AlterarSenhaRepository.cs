using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class AlterarSenhaRepository : IAlterarSenhaRepository
    {
        private readonly IDbConnection dbConnection;
        private bool disposedValue;

        public AlterarSenhaRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }


        public async Task<IEnumerable<AlterarSenha>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AlterarSenha> GetAsync(int code)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AlterarSenha>> SelectAsync(AlterarSenha entity)
        {
            throw new NotImplementedException();
        }

        public async Task<AlterarSenha> CreateAsync(AlterarSenha entity)
        {
            throw new NotImplementedException();
        }

        public async Task<AlterarSenha> UpdateAsync(AlterarSenha entity)
        {
            throw new NotImplementedException();
        }

        public async Task<AlterarSenha> DeleteAsync(int code, int user)
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
        public async Task<AlterarSenha> UpdateAlterarSenhaAsync(int id, string senhaAtual, string senhaNova)
        {
            var dynamic = new DynamicParameters();
            var result = new AlterarSenha();
            try
            {
                dynamic.Add("ID", id);
                dynamic.Add("SENHA_ATUAL", senhaAtual);
                dynamic.Add("NOVA_SENHA", senhaNova);
                dynamic.Add("retorno", dbType: DbType.String, value: string.Empty, direction: ParameterDirection.Output);

                await dbConnection.ExecuteAsync("IMC_SP_ALTERAR_SENHA", dynamic, commandType: CommandType.StoredProcedure);

                result.retorno = dynamic.Get<string>("retorno");

                return result;
            }
            finally
            {
                dynamic = null;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

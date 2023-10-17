using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;

namespace Infrastructure.Repository
{
    public class AlterarPesoAlturaRepository : IAlterarPesoAlturaRepository
    {
        private readonly IDbConnection dbConnection;
        private bool disposedValue;

        public AlterarPesoAlturaRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }


        public async Task<IEnumerable<AlterarPesoAltura>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AlterarPesoAltura> GetAsync(int code)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AlterarPesoAltura>> SelectAsync(AlterarPesoAltura entity)
        {
            throw new NotImplementedException();
        }

        public async Task<AlterarPesoAltura> CreateAsync(AlterarPesoAltura entity)
        {
            throw new NotImplementedException();
        }

        public async Task<AlterarPesoAltura> UpdateAsync(AlterarPesoAltura entity)
        {
            throw new NotImplementedException();
        }

        public async Task<AlterarPesoAltura> DeleteAsync(int code, int user)
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

        public async Task<AlterarPesoAltura> UpdatePesoAlturaAsync(string cpf, decimal peso, decimal altura)
        {
            var dynamic = new DynamicParameters();
            var result = new AlterarPesoAltura();
            try
            {
                dynamic.Add("CPF", cpf);
                dynamic.Add("PESO", peso);
                dynamic.Add("ALTURA", altura);
                dynamic.Add("retorno", dbType: DbType.String,value:string.Empty, direction: ParameterDirection.Output);

                await dbConnection.ExecuteAsync("IMC_SP_ALTERAR_PESO_ALTURA", dynamic, commandType: CommandType.StoredProcedure);
             
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

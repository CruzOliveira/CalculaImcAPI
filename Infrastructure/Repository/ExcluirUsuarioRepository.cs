using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ExcluirUsuarioRepository : IExcluirUsuarioRepository
    {
        private readonly IDbConnection dbConnection;
        private bool disposedValue;

        public ExcluirUsuarioRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }


        public async Task<IEnumerable<ExcluirUsuario>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ExcluirUsuario> GetAsync(int code)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExcluirUsuario>> SelectAsync(ExcluirUsuario entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ExcluirUsuario> CreateAsync(ExcluirUsuario entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ExcluirUsuario> UpdateAsync(ExcluirUsuario entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ExcluirUsuario> DeleteAsync(int code, int user)
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
    }
}

using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CalculaIMCRepository : ICalculaIMCRepository
    {
        private readonly IDbConnection dbConnection;
        private bool disposedValue;

        public CalculaIMCRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }


        public async Task<IEnumerable<CalculaIMC>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CalculaIMC> GetAsync(int code)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CalculaIMC>> SelectAsync(CalculaIMC entity)
        {
            throw new NotImplementedException();
        }

        public async Task<CalculaIMC> CreateAsync(CalculaIMC entity)
        {
            throw new NotImplementedException();
        }

        public async Task<CalculaIMC> UpdateAsync(CalculaIMC entity)
        {
            throw new NotImplementedException();
        }

        public async Task<CalculaIMC> DeleteAsync(int code, int user)
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

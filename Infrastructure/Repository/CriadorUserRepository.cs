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
    }
}

using Domain.Base;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using FluentValidation;
using Infrastructure.Repository;
using Microsoft.Extensions.Caching.Distributed;
using Service.Redis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CriadorUserService : ICriadorUserService
    {
        public readonly ICriadorUserRepository infrastructure;
        private readonly IValidator<CriadorUser> validator;
        private readonly RedisCacheExtensions cache;

        public CriadorUserService(IDbConnection dbConnection, IValidator<CriadorUser> validator, IDistributedCache cache)
        {
            infrastructure = new CriadorUserRepository(dbConnection);
            this.validator = validator;
            this.cache = new RedisCacheExtensions(cache);
        }

        public async Task<Resultado<IEnumerable<CriadorUser>>> ListAsync()
        {
            try
            {
                return Resultado<IEnumerable<CriadorUser>>.ComSucesso(await this.infrastructure.ListAsync());
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<CriadorUser>>.ComErros(null, Resultado<IEnumerable<CriadorUser>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<CriadorUser>> GetAsync(int code)
        {
            try
            {
                return Resultado<CriadorUser>.ComSucesso(await this.infrastructure.GetAsync(code));
            }
            catch (Exception exception)
            {
                return Resultado<CriadorUser>.ComErros(null, Resultado<CriadorUser>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<IEnumerable<CriadorUser>>> SelectAsync(CriadorUser entity)
        {
            try
            {
                return Resultado<IEnumerable<CriadorUser>>.ComSucesso(await this.infrastructure.SelectAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<CriadorUser>>.ComErros(null, Resultado<IEnumerable<CriadorUser>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<CriadorUser>> CreateAsync(CriadorUser entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<CriadorUser>.ComErros(entity, errosValidacao);
                }

                return Resultado<CriadorUser>.ComSucesso(await this.infrastructure.CreateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<CriadorUser>.ComErros(null, Resultado<CriadorUser>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<CriadorUser>> UpdateAsync(CriadorUser entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<CriadorUser>.ComErros(entity, errosValidacao);
                }

                return Resultado<CriadorUser>.ComSucesso(await this.infrastructure.UpdateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<CriadorUser>.ComErros(null, Resultado<CriadorUser>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<CriadorUser>> DeleteAsync(int code, int user)
        {
            try
            {
                return Resultado<CriadorUser>.ComSucesso(await this.infrastructure.DeleteAsync(code, user));
            }
            catch (Exception exception)
            {
                return Resultado<CriadorUser>.ComErros(null, Resultado<CriadorUser>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<Resultado<CriadorUser>> CreateUserAsync(CriadorUser entity)
        {
            try
            {
                var resultado = await this.infrastructure.CreateUserAsync(entity);
                if (resultado.retorno.Contains("Erro"))
                {
                    return Resultado<CriadorUser>.ComErros(null, Resultado<CriadorUser>.AdicionarErro(Error.Criar(string.Empty, resultado.retorno, TipoErro.Validacao, null)));
                }
                return Resultado<CriadorUser>.ComSucesso(resultado);
            }
            catch (Exception exception)
            {
                return Resultado<CriadorUser>.ComErros(null, Resultado<CriadorUser>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }
    }
}

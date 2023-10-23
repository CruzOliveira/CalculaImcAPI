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
    public class CriadorIMCService : ICriadorIMCService
    {
        public readonly ICriadorIMCRepository infrastructure;
        private readonly IValidator<CriadorIMC> validator;
        private readonly RedisCacheExtensions cache;

        public CriadorIMCService(IDbConnection dbConnection, IValidator<CriadorIMC> validator, IDistributedCache cache)
        {
            infrastructure = new CriadorIMCRepository(dbConnection);
            this.validator = validator;
            this.cache = new RedisCacheExtensions(cache);
        }

        public async Task<Resultado<IEnumerable<CriadorIMC>>> ListAsync()
        {
            try
            {
                return Resultado<IEnumerable<CriadorIMC>>.ComSucesso(await this.infrastructure.ListAsync());
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<CriadorIMC>>.ComErros(null, Resultado<IEnumerable<CriadorIMC>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<CriadorIMC>> GetAsync(int code)
        {
            try
            {
                return Resultado<CriadorIMC>.ComSucesso(await this.infrastructure.GetAsync(code));
            }
            catch (Exception exception)
            {
                return Resultado<CriadorIMC>.ComErros(null, Resultado<CriadorIMC>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<IEnumerable<CriadorIMC>>> SelectAsync(CriadorIMC entity)
        {
            try
            {
                return Resultado<IEnumerable<CriadorIMC>>.ComSucesso(await this.infrastructure.SelectAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<CriadorIMC>>.ComErros(null, Resultado<IEnumerable<CriadorIMC>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<CriadorIMC>> CreateAsync(CriadorIMC entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<CriadorIMC>.ComErros(entity, errosValidacao);
                }

                return Resultado<CriadorIMC>.ComSucesso(await this.infrastructure.CreateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<CriadorIMC>.ComErros(null, Resultado<CriadorIMC>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<CriadorIMC>> UpdateAsync(CriadorIMC entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<CriadorIMC>.ComErros(entity, errosValidacao);
                }

                return Resultado<CriadorIMC>.ComSucesso(await this.infrastructure.UpdateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<CriadorIMC>.ComErros(null, Resultado<CriadorIMC>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<CriadorIMC>> DeleteAsync(int code, int user)
        {
            try
            {
                return Resultado<CriadorIMC>.ComSucesso(await this.infrastructure.DeleteAsync(code, user));
            }
            catch (Exception exception)
            {
                return Resultado<CriadorIMC>.ComErros(null, Resultado<CriadorIMC>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<Resultado<CriadorIMC>> CreateResultadoAsync(int id_user, decimal peso, decimal altura)
        {
            try
            {
                var resultado = await this.infrastructure.CreateResultadoAsync(id_user, peso, altura);

                if (resultado.retorno.Contains("Erro"))
                {
                    return Resultado<CriadorIMC>.ComErros(null, Resultado<CriadorIMC>.AdicionarErro(Error.Criar(string.Empty, resultado.retorno, TipoErro.Validacao, null)));
                }

                return Resultado<CriadorIMC>.ComSucesso(resultado);
            }
            catch (Exception exception)
            {
                return Resultado<CriadorIMC>.ComErros(null, Resultado<CriadorIMC>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }

        }
    }
}



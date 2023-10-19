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
    public class ResultadoIMCService : IResultadoIMCService
    {
        public readonly IResultadoIMCRepository infrastructure;
        private readonly IValidator<ResultadoIMC> validator;
        private readonly RedisCacheExtensions cache;

        public ResultadoIMCService(IDbConnection dbConnection, IValidator<ResultadoIMC> validator, IDistributedCache cache)
        {
            infrastructure = new ResultadoIMCRepository(dbConnection);
            this.validator = validator;
            this.cache = new RedisCacheExtensions(cache);
        }

        public async Task<Resultado<IEnumerable<ResultadoIMC>>> ListAsync()
        {
            try
            {
                return Resultado<IEnumerable<ResultadoIMC>>.ComSucesso(await this.infrastructure.ListAsync());
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<ResultadoIMC>>.ComErros(null, Resultado<IEnumerable<ResultadoIMC>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<ResultadoIMC>> GetAsync(int code)
        {
            try
            {
                return Resultado<ResultadoIMC>.ComSucesso(await this.infrastructure.GetAsync(code));
            }
            catch (Exception exception)
            {
                return Resultado<ResultadoIMC>.ComErros(null, Resultado<ResultadoIMC>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<IEnumerable<ResultadoIMC>>> SelectAsync(ResultadoIMC entity)
        {
            try
            {
                return Resultado<IEnumerable<ResultadoIMC>>.ComSucesso(await this.infrastructure.SelectAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<ResultadoIMC>>.ComErros(null, Resultado<IEnumerable<ResultadoIMC>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<ResultadoIMC>> CreateAsync(ResultadoIMC entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<ResultadoIMC>.ComErros(entity, errosValidacao);
                }

                return Resultado<ResultadoIMC>.ComSucesso(await this.infrastructure.CreateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<ResultadoIMC>.ComErros(null, Resultado<ResultadoIMC>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<ResultadoIMC>> UpdateAsync(ResultadoIMC entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<ResultadoIMC>.ComErros(entity, errosValidacao);
                }

                return Resultado<ResultadoIMC>.ComSucesso(await this.infrastructure.UpdateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<ResultadoIMC>.ComErros(null, Resultado<ResultadoIMC>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<ResultadoIMC>> DeleteAsync(int code, int user)
        {
            try
            {
                return Resultado<ResultadoIMC>.ComSucesso(await this.infrastructure.DeleteAsync(code, user));
            }
            catch (Exception exception)
            {
                return Resultado<ResultadoIMC>.ComErros(null, Resultado<ResultadoIMC>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<Resultado<ResultadoIMC>> CreateResultadoAsync(int info_user_id)
        {
            try
            {
                var resultado = await this.infrastructure.CreateResultadoAsync(info_user_id);

                if (resultado.retorno.Contains("Erro"))
                {
                    return Resultado<ResultadoIMC>.ComErros(null, Resultado<ResultadoIMC>.AdicionarErro(Error.Criar(string.Empty, resultado.retorno, TipoErro.Validacao, null)));
                }

                return Resultado<ResultadoIMC>.ComSucesso(resultado);
            }
            catch (Exception exception)
            {
                return Resultado<ResultadoIMC>.ComErros(null, Resultado<ResultadoIMC>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }

        }
    }
}



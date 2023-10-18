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
    public class ExcluirUsuarioService : IExcluirUsuarioService
    {
        public readonly IExcluirUsuarioRepository infrastructure;
        private readonly IValidator<ExcluirUsuario> validator;
        private readonly RedisCacheExtensions cache;

        public ExcluirUsuarioService(IDbConnection dbConnection, IValidator<ExcluirUsuario> validator, IDistributedCache cache)
        {
            infrastructure = new ExcluirUsuarioRepository(dbConnection);
            this.validator = validator;
            this.cache = new RedisCacheExtensions(cache);
        }

        public async Task<Resultado<IEnumerable<ExcluirUsuario>>> ListAsync()
        {
            try
            {
                return Resultado<IEnumerable<ExcluirUsuario>>.ComSucesso(await this.infrastructure.ListAsync());
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<ExcluirUsuario>>.ComErros(null, Resultado<IEnumerable<ExcluirUsuario>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<ExcluirUsuario>> GetAsync(int code)
        {
            try
            {
                return Resultado<ExcluirUsuario>.ComSucesso(await this.infrastructure.GetAsync(code));
            }
            catch (Exception exception)
            {
                return Resultado<ExcluirUsuario>.ComErros(null, Resultado<ExcluirUsuario>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<IEnumerable<ExcluirUsuario>>> SelectAsync(ExcluirUsuario entity)
        {
            try
            {
                return Resultado<IEnumerable<ExcluirUsuario>>.ComSucesso(await this.infrastructure.SelectAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<ExcluirUsuario>>.ComErros(null, Resultado<IEnumerable<ExcluirUsuario>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<ExcluirUsuario>> CreateAsync(ExcluirUsuario entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<ExcluirUsuario>.ComErros(entity, errosValidacao);
                }

                return Resultado<ExcluirUsuario>.ComSucesso(await this.infrastructure.CreateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<ExcluirUsuario>.ComErros(null, Resultado<ExcluirUsuario>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<ExcluirUsuario>> UpdateAsync(ExcluirUsuario entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<ExcluirUsuario>.ComErros(entity, errosValidacao);
                }

                return Resultado<ExcluirUsuario>.ComSucesso(await this.infrastructure.UpdateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<ExcluirUsuario>.ComErros(null, Resultado<ExcluirUsuario>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<ExcluirUsuario>> DeleteAsync(int code, int user)
        {
            try
            {
                return Resultado<ExcluirUsuario>.ComSucesso(await this.infrastructure.DeleteAsync(code, user));
            }
            catch (Exception exception)
            {
                return Resultado<ExcluirUsuario>.ComErros(null, Resultado<ExcluirUsuario>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<Resultado<ExcluirUsuario>> DeleteUserAsync(int id, string senha)
        {
            try
            {
                var resultado = await this.infrastructure.DeleteUserAsync(id, senha);

                if (resultado.retorno.Contains("Erro"))
                {
                    return Resultado<ExcluirUsuario>.ComErros(null, Resultado<ExcluirUsuario>.AdicionarErro(Error.Criar(string.Empty, resultado.retorno, TipoErro.Validacao, null)));
                }
                return Resultado<ExcluirUsuario>.ComSucesso(resultado);
            }
            catch (Exception exception)
            {
                return Resultado<ExcluirUsuario>.ComErros(null, Resultado<ExcluirUsuario>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }
    }
}

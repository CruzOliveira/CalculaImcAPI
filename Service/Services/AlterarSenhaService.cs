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
    public class AlterarSenhaService : IAlterarSenhaService
    {
        public readonly IAlterarSenhaRepository infrastructure;
        private readonly IValidator<AlterarSenha> validator;
        private readonly RedisCacheExtensions cache;

        public AlterarSenhaService(IDbConnection dbConnection, IValidator<AlterarSenha> validator, IDistributedCache cache)
        {
            infrastructure = new AlterarSenhaRepository(dbConnection);
            this.validator = validator;
            this.cache = new RedisCacheExtensions(cache);
        }

        public async Task<Resultado<IEnumerable<AlterarSenha>>> ListAsync()
        {
            try
            {
                return Resultado<IEnumerable<AlterarSenha>>.ComSucesso(await this.infrastructure.ListAsync());
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<AlterarSenha>>.ComErros(null, Resultado<IEnumerable<AlterarSenha>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<AlterarSenha>> GetAsync(int code)
        {
            try
            {
                return Resultado<AlterarSenha>.ComSucesso(await this.infrastructure.GetAsync(code));
            }
            catch (Exception exception)
            {
                return Resultado<AlterarSenha>.ComErros(null, Resultado<AlterarSenha>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<IEnumerable<AlterarSenha>>> SelectAsync(AlterarSenha entity)
        {
            try
            {
                return Resultado<IEnumerable<AlterarSenha>>.ComSucesso(await this.infrastructure.SelectAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<AlterarSenha>>.ComErros(null, Resultado<IEnumerable<AlterarSenha>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<AlterarSenha>> CreateAsync(AlterarSenha entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<AlterarSenha>.ComErros(entity, errosValidacao);
                }

                return Resultado<AlterarSenha>.ComSucesso(await this.infrastructure.CreateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<AlterarSenha>.ComErros(null, Resultado<AlterarSenha>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<AlterarSenha>> UpdateAsync(AlterarSenha entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<AlterarSenha>.ComErros(entity, errosValidacao);
                }

                return Resultado<AlterarSenha>.ComSucesso(await this.infrastructure.UpdateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<AlterarSenha>.ComErros(null, Resultado<AlterarSenha>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<AlterarSenha>> DeleteAsync(int code, int user)
        {
            try
            {
                return Resultado<AlterarSenha>.ComSucesso(await this.infrastructure.DeleteAsync(code, user));
            }
            catch (Exception exception)
            {
                return Resultado<AlterarSenha>.ComErros(null, Resultado<AlterarSenha>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        
        public async Task<Resultado<AlterarSenha>> UpdateAlterarSenhaAsync(int id, string senhaAtual, string senhaNova)
        {
            try
            {
                var resultado = await this.infrastructure.UpdateAlterarSenhaAsync(id, senhaAtual, senhaNova);

                if (resultado.retorno.Contains("Erro"))
                {
                    return Resultado<AlterarSenha>.ComErros(null, Resultado<AlterarSenha>.AdicionarErro(Error.Criar(string.Empty, resultado.retorno, TipoErro.Validacao, null)));
                }

                return Resultado<AlterarSenha>.ComSucesso(resultado);
            }
            catch (Exception exception)
            {
                return Resultado<AlterarSenha>.ComErros(null, Resultado<AlterarSenha>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }
    }
}

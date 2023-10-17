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
    public class AlterarPesoAlturaService : IAlterarPesoAlturaService
    {
        public readonly IAlterarPesoAlturaRepository infrastructure;
        private readonly IValidator<AlterarPesoAltura> validator;
        private readonly RedisCacheExtensions cache;

        public AlterarPesoAlturaService(IDbConnection dbConnection, IValidator<AlterarPesoAltura> validator, IDistributedCache cache)
        {
            infrastructure = new AlterarPesoAlturaRepository(dbConnection);
            this.validator = validator;
            this.cache = new RedisCacheExtensions(cache);
        }

        public async Task<Resultado<IEnumerable<AlterarPesoAltura>>> ListAsync()
        {
            try
            {
                return Resultado<IEnumerable<AlterarPesoAltura>>.ComSucesso(await this.infrastructure.ListAsync());
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<AlterarPesoAltura>>.ComErros(null, Resultado<IEnumerable<AlterarPesoAltura>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<AlterarPesoAltura>> GetAsync(int code)
        {
            try
            {
                return Resultado<AlterarPesoAltura>.ComSucesso(await this.infrastructure.GetAsync(code));
            }
            catch (Exception exception)
            {
                return Resultado<AlterarPesoAltura>.ComErros(null, Resultado<AlterarPesoAltura>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<IEnumerable<AlterarPesoAltura>>> SelectAsync(AlterarPesoAltura entity)
        {
            try
            {
                return Resultado<IEnumerable<AlterarPesoAltura>>.ComSucesso(await this.infrastructure.SelectAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<AlterarPesoAltura>>.ComErros(null, Resultado<IEnumerable<AlterarPesoAltura>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<AlterarPesoAltura>> CreateAsync(AlterarPesoAltura entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<AlterarPesoAltura>.ComErros(entity, errosValidacao);
                }

                return Resultado<AlterarPesoAltura>.ComSucesso(await this.infrastructure.CreateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<AlterarPesoAltura>.ComErros(null, Resultado<AlterarPesoAltura>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<AlterarPesoAltura>> UpdateAsync(AlterarPesoAltura entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<AlterarPesoAltura>.ComErros(entity, errosValidacao);
                }

                return Resultado<AlterarPesoAltura>.ComSucesso(await this.infrastructure.UpdateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<AlterarPesoAltura>.ComErros(null, Resultado<AlterarPesoAltura>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<AlterarPesoAltura>> DeleteAsync(int code, int user)
        {
            try
            {
                return Resultado<AlterarPesoAltura>.ComSucesso(await this.infrastructure.DeleteAsync(code, user));
            }
            catch (Exception exception)
            {
                return Resultado<AlterarPesoAltura>.ComErros(null, Resultado<AlterarPesoAltura>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<Resultado<AlterarPesoAltura>> UpdatePesoAlturaAsync(string cpf, decimal peso, decimal altura)
        {
            try
            {
                var resultado = await this.infrastructure.UpdatePesoAlturaAsync(cpf, peso, altura);

                if (resultado.retorno.Contains("Erro"))
                {
                    return Resultado<AlterarPesoAltura>.ComErros(null, Resultado<AlterarPesoAltura>.AdicionarErro(Error.Criar(string.Empty, resultado.retorno, TipoErro.Validacao, null)));
                }

                return Resultado<AlterarPesoAltura>.ComSucesso(resultado);
            }
            catch (Exception exception)
            {
                return Resultado<AlterarPesoAltura>.ComErros(null, Resultado<AlterarPesoAltura>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }
    }
}

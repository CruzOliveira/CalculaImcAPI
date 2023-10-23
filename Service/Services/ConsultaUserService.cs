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
    public class ConsultaUserService : IConsultaUserService
    {
        public readonly IConsultaUserRepository infrastructure;
        private readonly IValidator<ConsultaUser> validator;
        private readonly RedisCacheExtensions cache;

        public ConsultaUserService(IDbConnection dbConnection, IValidator<ConsultaUser> validator, IDistributedCache cache)
        {
            infrastructure = new ConsultaUserRepository(dbConnection);
            this.validator = validator;
            this.cache = new RedisCacheExtensions(cache);
        }

        public async Task<Resultado<IEnumerable<ConsultaUser>>> ListAsync()
        {
            try
            {
                return Resultado<IEnumerable<ConsultaUser>>.ComSucesso(await this.infrastructure.ListAsync());
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<ConsultaUser>>.ComErros(null, Resultado<IEnumerable<ConsultaUser>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<ConsultaUser>> GetAsync(int code)
        {
            try
            {
                return Resultado<ConsultaUser>.ComSucesso(await this.infrastructure.GetAsync(code));
            }
            catch (Exception exception)
            {
                return Resultado<ConsultaUser>.ComErros(null, Resultado<ConsultaUser>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<IEnumerable<ConsultaUser>>> SelectAsync(ConsultaUser entity)
        {
            try
            {
                return Resultado<IEnumerable<ConsultaUser>>.ComSucesso(await this.infrastructure.SelectAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<ConsultaUser>>.ComErros(null, Resultado<IEnumerable<ConsultaUser>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<ConsultaUser>> CreateAsync(ConsultaUser entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<ConsultaUser>.ComErros(entity, errosValidacao);
                }

                return Resultado<ConsultaUser>.ComSucesso(await this.infrastructure.CreateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<ConsultaUser>.ComErros(null, Resultado<ConsultaUser>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<ConsultaUser>> UpdateAsync(ConsultaUser entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<ConsultaUser>.ComErros(entity, errosValidacao);
                }

                return Resultado<ConsultaUser>.ComSucesso(await this.infrastructure.UpdateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<ConsultaUser>.ComErros(null, Resultado<ConsultaUser>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<ConsultaUser>> DeleteAsync(int code, int user)
        {
            try
            {
                return Resultado<ConsultaUser>.ComSucesso(await this.infrastructure.DeleteAsync(code, user));
            }
            catch (Exception exception)
            {
                return Resultado<ConsultaUser>.ComErros(null, Resultado<ConsultaUser>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<Resultado<ListConsultaUser>> GetConsultaAsync(int id_user)
        {
            try
            {
                return Resultado <ListConsultaUser>.ComSucesso(await this.infrastructure.GetConsultaAsync(id_user));
            }
            catch (Exception exception)
            {
                return Resultado<ListConsultaUser>.ComErros(null, Resultado<ConsultaUser>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }
    }
}

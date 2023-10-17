using Application.AppData;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlterarPesoAlturaController : Controller
    {
        private readonly IAlterarPesoAlturaService service;
        private readonly IMapper mapper;
        private readonly string chaveToken;

        public AlterarPesoAlturaController(IConfiguration configuration, IAlterarPesoAlturaService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
            this.chaveToken = configuration.GetSection("Seguranca:ChaveToken").Value;
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> Update(string cpf, decimal peso, decimal altura)
        {
            //var autenticacao = Utils.ValidaToken(User.Claims, this.chaveToken);
            //if (autenticacao == null)
            //    return Unauthorized();

            //var entity = mapper.Map<AlterarPesoAltura>(string cpf, int peso, int altura);
            //entity.User = autenticacao.CodigoUsuario;


            if (cpf.Length != 11) return new BadRequestObjectResult("CPF INVALIDO");

            var resultado = await service.UpdatePesoAlturaAsync(cpf, peso, altura);

            

            if (resultado.BadRequest)
                return new BadRequestObjectResult(resultado);

            return new ObjectResult(resultado.Conteudo);
        }

        //[HttpGet]
        //public async Task<IActionResult> List()
        //{
        //    var autenticacao = Utils.ValidaToken(User.Claims, this.chaveToken);
        //    if (autenticacao == null)
        //        return Unauthorized();

        //    var resultado = await service.ListAsync();
        //    if (resultado.BadRequest)
        //        return new BadRequestObjectResult(resultado);

        //    return new ObjectResult(resultado.Conteudo);
        //}

        //// GET api/todo
        ///// <summary>
        ///// Obtém um(a) AlterarPesoAltura
        ///// </summary>
        //[HttpGet("{codigo}")]
        //public async Task<IActionResult> Get(int codigo)
        //{
        //    var autenticacao = Utils.ValidaToken(User.Claims, this.chaveToken);
        //    if (autenticacao == null)
        //        return Unauthorized();

        //    var resultado = await service.GetAsync(codigo);
        //    if (resultado.BadRequest)
        //        return new BadRequestObjectResult(resultado);

        //    return new ObjectResult(resultado.Conteudo);
        //}

        //// PATCH api/todo
        ///// <summary>
        ///// Retorna uma lista de AlterarPesoAltura
        ///// </summary>
        //[HttpPatch]
        //public async Task<IActionResult> Select(Domain.DTO.AlterarPesoAltura entityIn)
        //{
        //    var autenticacao = Utils.ValidaToken(User.Claims, this.chaveToken);
        //    if (autenticacao == null)
        //        return Unauthorized();

        //    var entity = mapper.Map<AlterarPesoAltura>(entityIn);

        //    var resultado = await service.SelectAsync(entity);
        //    if (resultado.BadRequest)
        //        return new BadRequestObjectResult(resultado);

        //    return new ObjectResult(resultado.Conteudo);
        //}

        //// POST api/todo
        ///// <summary>
        ///// Cria um(a) novo(a) AlterarPesoAltura
        ///// </summary>
        //[HttpPost]
        //public async Task<IActionResult> Create(Domain.DTO.AlterarPesoAltura entityIn)
        //{
        //    var autenticacao = Utils.ValidaToken(User.Claims, this.chaveToken);
        //    if (autenticacao == null)
        //        return Unauthorized();

        //    var entity = mapper.Map<AlterarPesoAltura>(entityIn);
        //    entity.User = autenticacao.CodigoUsuario;

        //    var resultado = await service.CreateAsync(entity);
        //    if (resultado.BadRequest)
        //        return new BadRequestObjectResult(resultado);

        //    return new ObjectResult(resultado.Conteudo);
        //}


        //// PUT api/todo
        ///// <summary>
        ///// Altera um(a) novo(a) AlterarPesoAltura
        ///// </summary>
        //[HttpPut]
        //public async Task<IActionResult> Update(Domain.DTO.AlterarPesoAltura entityIn)
        //{
        //    var autenticacao = Utils.ValidaToken(User.Claims, this.chaveToken);
        //    if (autenticacao == null)
        //        return Unauthorized();

        //    var entity = mapper.Map<AlterarPesoAltura>(entityIn);
        //    entity.User = autenticacao.CodigoUsuario;

        //    var resultado = await service.UpdateAsync(entity);
        //    if (resultado.BadRequest)
        //        return new BadRequestObjectResult(resultado);

        //    return new ObjectResult(resultado.Conteudo);
        //}

        //// DELETE api/todo
        ///// <summary>
        ///// Exclui um(a) AlterarPesoAltura
        ///// </summary>
        //[HttpDelete]
        //public async Task<IActionResult> Delete(int codigo)
        //{
        //    var autenticacao = Utils.ValidaToken(User.Claims, this.chaveToken);
        //    if (autenticacao == null)
        //        return Unauthorized();

        //    var resultado = await service.DeleteAsync(codigo, (int)autenticacao.CodigoUsuario);
        //    if (resultado.BadRequest)
        //        return new BadRequestObjectResult(resultado);

        //    return new ObjectResult(resultado.Conteudo);
        //}
    }
}

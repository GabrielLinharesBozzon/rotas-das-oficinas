using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Contracts.DTOs;
using RO.DevTest.Application.Features.Produtos.Commands.CriarProduto;
using RO.DevTest.Application.Features.Produtos.Commands.ExcluirProduto;
using RO.DevTest.Application.Features.Produtos.Commands.AtualizarProduto;
using RO.DevTest.Application.Features.Produtos.Queries.ObterProduto;
using RO.DevTest.Application.Features.Produtos.Queries.ObterProdutos;
using RO.DevTest.Application.Features.Common;

namespace RO.DevTest.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProdutosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ListaPaginada<ProdutoDto>>> ObterProdutos(
            [FromQuery] ObterProdutosQuery query)
        {
            var resultado = await _mediator.Send(query);
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDto>> ObterProduto(Guid id)
        {
            var query = new ObterProdutoQuery { Id = id };
            var resultado = await _mediator.Send(query);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDto>> CriarProduto(
            [FromBody] CriarProdutoCommand command)
        {
            var resultado = await _mediator.Send(command);
            return CreatedAtAction(nameof(ObterProduto), new { id = resultado.Id }, resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoDto>> AtualizarProduto(
            Guid id,
            [FromBody] AtualizarProdutoCommand command)
        {
            command.Id = id;
            var resultado = await _mediator.Send(command);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ExcluirProduto(Guid id)
        {
            var command = new ExcluirProdutoCommand { Id = id };
            var resultado = await _mediator.Send(command);
            return Ok(resultado);
        }
    }
}
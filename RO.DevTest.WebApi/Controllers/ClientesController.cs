using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Contracts.DTOs;
using RO.DevTest.Application.Features.Clientes.Commands.CriarCliente;
using RO.DevTest.Application.Features.Clientes.Commands.ExcluirCliente;
using RO.DevTest.Application.Features.Clientes.Commands.AtualizarCliente;
using RO.DevTest.Application.Features.Clientes.Queries.ObterCliente;
using RO.DevTest.Application.Features.Clientes.Queries.ObterClientes;
using RO.DevTest.Application.Features.Common;

namespace RO.DevTest.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ListaPaginada<ClienteDto>>> ObterClientes(
            [FromQuery] ObterClientesQuery query)
        {
            var resultado = await _mediator.Send(query);
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> ObterCliente(Guid id)
        {
            var query = new ObterClienteQuery { Id = id };
            var resultado = await _mediator.Send(query);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDto>> CriarCliente(
            [FromBody] CriarClienteCommand command)
        {
            var resultado = await _mediator.Send(command);
            return CreatedAtAction(nameof(ObterCliente), new { id = resultado.Id }, resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteDto>> AtualizarCliente(
            Guid id,
            [FromBody] AtualizarClienteCommand command)
        {
            command.Id = id;
            var resultado = await _mediator.Send(command);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ExcluirCliente(Guid id)
        {
            var command = new ExcluirClienteCommand { Id = id };
            var resultado = await _mediator.Send(command);
            return Ok(resultado);
        }
    }
}
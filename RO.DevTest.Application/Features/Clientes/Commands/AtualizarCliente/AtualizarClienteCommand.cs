using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RO.DevTest.Application.Contracts.DTOs;
using RO.DevTest.Application.Features.Common;
using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Application.Features.Clientes.Commands.AtualizarCliente
{
    public class AtualizarClienteCommand : BaseCommand<ClienteDto>
    {
        public new Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }

    public class AtualizarClienteCommandHandler : IRequestHandler<AtualizarClienteCommand, ClienteDto>
    {
        private readonly IRepositorioCliente _repositorioCliente;

        public AtualizarClienteCommandHandler(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        public async Task<ClienteDto> Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repositorioCliente.ObterPorIdAsync(request.Id);
            if (cliente == null)
                throw new Exception($"Cliente com ID {request.Id} não encontrado");

            cliente.Atualizar(request.Nome, request.Email, request.Telefone, request.Endereco);
            await _repositorioCliente.AtualizarAsync(cliente);

            return new ClienteDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                Endereco = cliente.Endereco,
                Ativo = cliente.Ativo
            };
        }
    }
}
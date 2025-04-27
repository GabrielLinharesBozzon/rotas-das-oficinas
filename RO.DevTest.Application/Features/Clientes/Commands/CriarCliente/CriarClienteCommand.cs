using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RO.DevTest.Application.Contracts.DTOs;
using RO.DevTest.Application.Features.Common;
using RO.DevTest.Domain.Abstract;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Features.Clientes.Commands.CriarCliente
{
    public class CriarClienteCommand : BaseCommand<ClienteDto>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }

    public class CriarClienteCommandHandler : IRequestHandler<CriarClienteCommand, ClienteDto>
    {
        private readonly IRepositorioCliente _repositorioCliente;

        public CriarClienteCommandHandler(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        public async Task<ClienteDto> Handle(CriarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente(request.Nome, request.Email, request.Telefone, request.Endereco);
            await _repositorioCliente.AdicionarAsync(cliente);

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
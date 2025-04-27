using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RO.DevTest.Application.Contracts.DTOs;
using RO.DevTest.Application.Features.Common;
using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Application.Features.Clientes.Queries.ObterCliente
{
    public class ObterClienteQuery : BaseQuery<ClienteDto>
    {
        public new Guid Id { get; set; }
    }

    public class ObterClienteQueryHandler : IRequestHandler<ObterClienteQuery, ClienteDto>
    {
        private readonly IRepositorioCliente _repositorioCliente;

        public ObterClienteQueryHandler(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        public async Task<ClienteDto> Handle(ObterClienteQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _repositorioCliente.ObterPorIdAsync(request.Id);
            if (cliente == null)
                throw new Exception($"Cliente com ID {request.Id} não encontrado");

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
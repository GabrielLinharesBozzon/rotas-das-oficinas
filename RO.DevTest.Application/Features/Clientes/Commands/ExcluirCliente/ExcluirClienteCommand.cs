using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RO.DevTest.Application.Features.Common;
using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Application.Features.Clientes.Commands.ExcluirCliente
{
    public class ExcluirClienteCommand : BaseCommand<bool>
    {
        public new Guid Id { get; set; }
    }

    public class ExcluirClienteCommandHandler : IRequestHandler<ExcluirClienteCommand, bool>
    {
        private readonly IRepositorioCliente _repositorioCliente;

        public ExcluirClienteCommandHandler(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        public async Task<bool> Handle(ExcluirClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repositorioCliente.ObterPorIdAsync(request.Id);
            if (cliente == null)
                throw new Exception($"Cliente com ID {request.Id} não encontrado");

            await _repositorioCliente.ExcluirAsync(request.Id);
            return true;
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RO.DevTest.Application.Features.Common;
using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Application.Features.Produtos.Commands.ExcluirProduto
{
    public class ExcluirProdutoCommand : BaseCommand<bool>
    {
        public new Guid Id { get; set; }
    }

    public class ExcluirProdutoCommandHandler : IRequestHandler<ExcluirProdutoCommand, bool>
    {
        private readonly IRepositorioProduto _repositorioProduto;

        public ExcluirProdutoCommandHandler(IRepositorioProduto repositorioProduto)
        {
            _repositorioProduto = repositorioProduto;
        }

        public async Task<bool> Handle(ExcluirProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _repositorioProduto.ObterPorIdAsync(request.Id);
            if (produto == null)
                throw new Exception($"Produto com ID {request.Id} não encontrado");

            await _repositorioProduto.ExcluirAsync(request.Id);
            return true;
        }
    }
}
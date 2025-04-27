using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RO.DevTest.Application.Contracts.DTOs;
using RO.DevTest.Application.Features.Common;
using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Application.Features.Produtos.Queries.ObterProduto
{
    public class ObterProdutoQuery : BaseQuery<ProdutoDto>
    {
        public new Guid Id { get; set; }
    }

    public class ObterProdutoQueryHandler : IRequestHandler<ObterProdutoQuery, ProdutoDto>
    {
        private readonly IRepositorioProduto _repositorioProduto;

        public ObterProdutoQueryHandler(IRepositorioProduto repositorioProduto)
        {
            _repositorioProduto = repositorioProduto;
        }

        public async Task<ProdutoDto> Handle(ObterProdutoQuery request, CancellationToken cancellationToken)
        {
            var produto = await _repositorioProduto.ObterPorIdAsync(request.Id);
            if (produto == null)
                throw new Exception($"Produto com ID {request.Id} não encontrado");

            return new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Estoque = produto.QuantidadeEstoque,
                Ativo = produto.Ativo
            };
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RO.DevTest.Application.Contracts.DTOs;
using RO.DevTest.Application.Features.Common;
using RO.DevTest.Domain.Abstract;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Features.Produtos.Commands.CriarProduto
{
    public class CriarProdutoCommand : BaseCommand<ProdutoDto>
    {
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }

    public class CriarProdutoCommandHandler : IRequestHandler<CriarProdutoCommand, ProdutoDto>
    {
        private readonly IRepositorioProduto _repositorioProduto;

        public CriarProdutoCommandHandler(IRepositorioProduto repositorioProduto)
        {
            _repositorioProduto = repositorioProduto;
        }

        public async Task<ProdutoDto> Handle(CriarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto(request.Nome, request.Descricao, request.Preco, request.Estoque);
            await _repositorioProduto.AdicionarAsync(produto);

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
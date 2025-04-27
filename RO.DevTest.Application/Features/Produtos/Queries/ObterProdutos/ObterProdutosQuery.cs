using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RO.DevTest.Application.Contracts.DTOs;
using RO.DevTest.Application.Features.Common;
using RO.DevTest.Domain.Abstract;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Features.Produtos.Queries.ObterProdutos
{
    public class ObterProdutosQuery : IRequest<ListaPaginada<ProdutoDto>>
    {
        public string? TermoBusca { get; set; }
        public string OrdenarPor { get; set; } = "nome";
        public int NumeroPagina { get; set; } = 1;
        public int TamanhoPagina { get; set; } = 10;
    }

    public class ObterProdutosQueryHandler : IRequestHandler<ObterProdutosQuery, ListaPaginada<ProdutoDto>>
    {
        private readonly IRepositorioProduto _repositorioProduto;

        public ObterProdutosQueryHandler(IRepositorioProduto repositorioProduto)
        {
            _repositorioProduto = repositorioProduto;
        }

        public async Task<ListaPaginada<ProdutoDto>> Handle(ObterProdutosQuery request, CancellationToken cancellationToken)
        {
            var produtos = await _repositorioProduto.ObterTodosAsync();

            if (!string.IsNullOrEmpty(request.TermoBusca))
            {
                produtos = produtos.Where(p =>
                    p.Nome.Contains(request.TermoBusca, StringComparison.OrdinalIgnoreCase) ||
                    p.Descricao.Contains(request.TermoBusca, StringComparison.OrdinalIgnoreCase));
            }

            produtos = request.OrdenarPor.ToLower() switch
            {
                "nome" => produtos.OrderBy(p => p.Nome),
                "preco" => produtos.OrderBy(p => p.Preco),
                "estoque" => produtos.OrderBy(p => p.QuantidadeEstoque),
                _ => produtos.OrderBy(p => p.Nome)
            };

            var skip = (request.NumeroPagina - 1) * request.TamanhoPagina;
            var produtosPaginados = produtos
                .Skip(skip)
                .Take(request.TamanhoPagina)
                .Select(p => new ProdutoDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Descricao = p.Descricao,
                    Preco = p.Preco,
                    Estoque = p.QuantidadeEstoque
                });

            var total = produtos.Count();

            return new ListaPaginada<ProdutoDto>(
                produtosPaginados.ToList(),
                total,
                request.NumeroPagina,
                request.TamanhoPagina);
        }
    }
}
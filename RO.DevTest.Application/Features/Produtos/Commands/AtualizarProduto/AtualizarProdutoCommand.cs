using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RO.DevTest.Application.Contracts.DTOs;
using RO.DevTest.Application.Features.Common;
using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Application.Features.Produtos.Commands.AtualizarProduto
{
    public class AtualizarProdutoCommand : BaseCommand<ProdutoDto>
    {
        public new Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }

    public class AtualizarProdutoCommandHandler : IRequestHandler<AtualizarProdutoCommand, ProdutoDto>
    {
        private readonly IRepositorioProduto _repositorioProduto;

        public AtualizarProdutoCommandHandler(IRepositorioProduto repositorioProduto)
        {
            _repositorioProduto = repositorioProduto;
        }

        public async Task<ProdutoDto> Handle(AtualizarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _repositorioProduto.ObterPorIdAsync(request.Id);
            if (produto == null)
                throw new Exception($"Produto com ID {request.Id} não encontrado");

            produto.Atualizar(request.Nome, request.Descricao, request.Preco, request.Estoque);
            await _repositorioProduto.AtualizarAsync(produto);

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
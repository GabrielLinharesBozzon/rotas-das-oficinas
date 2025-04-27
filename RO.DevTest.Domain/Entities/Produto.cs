using System;
using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Domain.Entities
{
    public class Produto : BaseEntity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public bool Ativo { get; private set; }

        protected Produto() { }

        public Produto(string nome, string descricao, decimal preco, int quantidadeEstoque)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode estar vazio", nameof(nome));

            if (preco <= 0)
                throw new ArgumentException("Preço deve ser maior que zero", nameof(preco));

            if (quantidadeEstoque < 0)
                throw new ArgumentException("Quantidade em estoque não pode ser negativa", nameof(quantidadeEstoque));

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
            Ativo = true;
        }

        public void Atualizar(string nome, string descricao, decimal preco, int quantidadeEstoque)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode estar vazio", nameof(nome));

            if (preco <= 0)
                throw new ArgumentException("Preço deve ser maior que zero", nameof(preco));

            if (quantidadeEstoque < 0)
                throw new ArgumentException("Quantidade em estoque não pode ser negativa", nameof(quantidadeEstoque));

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
        }

        public void AtualizarEstoque(int quantidade)
        {
            if (QuantidadeEstoque + quantidade < 0)
                throw new InvalidOperationException("Estoque insuficiente");

            QuantidadeEstoque += quantidade;
        }

        public void Desativar()
        {
            Ativo = false;
        }

        public void Ativar()
        {
            Ativo = true;
        }
    }
}
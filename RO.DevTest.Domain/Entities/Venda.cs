using System;
using System.Collections.Generic;
using System.Linq;
using RO.DevTest.Domain.Abstract;
using RO.DevTest.Domain.Enums;

namespace RO.DevTest.Domain.Entities
{
    public class Venda : BaseEntity
    {
        public Guid ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }
        public DateTime DataVenda { get; private set; }
        public decimal ValorTotal { get; private set; }
        public string Status { get; private set; }
        public ICollection<ItemVenda> Itens { get; private set; }

        protected Venda() { }

        public Venda(Guid clienteId, DateTime dataVenda)
        {
            ClienteId = clienteId;
            DataVenda = dataVenda;
            Status = StatusVenda.Pendente;
            Itens = new List<ItemVenda>();
        }

        public void AdicionarItem(Produto produto, int quantidade)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero", nameof(quantidade));

            if (produto.QuantidadeEstoque < quantidade)
                throw new InvalidOperationException("Estoque insuficiente");

            var item = new ItemVenda(this, produto, quantidade, produto.Preco);
            Itens.Add(item);
            produto.AtualizarEstoque(-quantidade);
            CalcularTotal();
        }

        public void RemoverItem(Guid itemId)
        {
            var item = Itens.FirstOrDefault(i => i.Id == itemId);
            if (item == null)
                throw new InvalidOperationException("Item não encontrado");

            item.Produto.AtualizarEstoque(item.Quantidade);
            Itens.Remove(item);
            CalcularTotal();
        }

        public void Concluir()
        {
            if (Itens.Count == 0)
                throw new InvalidOperationException("Não é possível concluir uma venda sem itens");

            Status = StatusVenda.Concluida;
        }

        public void Cancelar()
        {
            foreach (var item in Itens)
            {
                item.Produto.AtualizarEstoque(item.Quantidade);
            }
            Status = StatusVenda.Cancelada;
        }

        private void CalcularTotal()
        {
            ValorTotal = Itens.Sum(i => i.ValorTotal);
        }
    }
}
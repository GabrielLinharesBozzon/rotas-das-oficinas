using System;
using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Domain.Entities
{
    public class ItemVenda : BaseEntity
    {
        public Guid VendaId { get; private set; }
        public Venda Venda { get; private set; }
        public Guid ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public decimal ValorTotal { get; private set; }

        protected ItemVenda() { }

        public ItemVenda(Venda venda, Produto produto, int quantidade, decimal precoUnitario)
        {
            if (venda == null)
                throw new ArgumentNullException(nameof(venda));

            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero", nameof(quantidade));

            if (precoUnitario <= 0)
                throw new ArgumentException("Preço unitário deve ser maior que zero", nameof(precoUnitario));

            VendaId = venda.Id;
            Venda = venda;
            ProdutoId = produto.Id;
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            CalcularTotal();
        }

        public void AtualizarQuantidade(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero", nameof(quantidade));

            Quantidade = quantidade;
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            ValorTotal = Quantidade * PrecoUnitario;
        }
    }
}
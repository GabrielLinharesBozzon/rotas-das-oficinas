using System;
using System.Collections.Generic;

namespace RO.DevTest.Application.Contracts.DTOs
{
    public class VendaDto
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<ItemVendaDto> Itens { get; set; } = new();
    }

    public class ItemVendaDto
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }

    public class CriarVendaDto
    {
        public Guid ClienteId { get; set; }
        public List<CriarItemVendaDto> Itens { get; set; } = new();
    }

    public class CriarItemVendaDto
    {
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }

    public class AtualizarVendaDto
    {
        public string Status { get; set; } = string.Empty;
    }
}
using System;

namespace RO.DevTest.Application.Contracts.DTOs
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public bool Ativo { get; set; }
    }

    public class CriarClienteDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
    }

    public class AtualizarClienteDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
    }
}
using System;
using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Endereco { get; private set; }
        public bool Ativo { get; private set; }

        protected Cliente() { }

        public Cliente(string nome, string email, string telefone, string endereco)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode estar vazio", nameof(nome));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email não pode estar vazio", nameof(email));

            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            Ativo = true;
        }

        public void Atualizar(string nome, string email, string telefone, string endereco)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode estar vazio", nameof(nome));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email não pode estar vazio", nameof(email));

            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
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
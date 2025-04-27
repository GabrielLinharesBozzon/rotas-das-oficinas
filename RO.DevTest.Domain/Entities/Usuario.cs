using System;
using Microsoft.AspNetCore.Identity;
using RO.DevTest.Domain.Abstract;
using RO.DevTest.Domain.Enums;

namespace RO.DevTest.Domain.Entities
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; } = string.Empty;
        public UserRole Role { get; private set; }
        public bool Ativo { get; private set; }

        public Usuario() : base() { }

        public Usuario(string nomeUsuario, string email, UserRole role)
        {
            UserName = nomeUsuario;
            Email = email;
            Role = role;
            Ativo = true;
        }

        public void Atualizar(string nomeUsuario, string email, UserRole role)
        {
            UserName = nomeUsuario;
            Email = email;
            Role = role;
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
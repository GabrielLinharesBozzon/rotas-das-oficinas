using System;

namespace RO.DevTest.Application.Contracts.DTOs
{
    public class UsuarioDto
    {
        public UsuarioDto()
        {
            NomeUsuario = string.Empty;
            Email = string.Empty;
            Funcao = string.Empty;
        }

        public string Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Funcao { get; set; }
        public bool Ativo { get; set; }
    }

    public class CriarUsuarioDto
    {
        public CriarUsuarioDto()
        {
            NomeUsuario = string.Empty;
            Email = string.Empty;
            Senha = string.Empty;
            Funcao = string.Empty;
        }

        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Funcao { get; set; }
    }

    public class AtualizarUsuarioDto
    {
        public AtualizarUsuarioDto()
        {
            NomeUsuario = string.Empty;
            Email = string.Empty;
            Funcao = string.Empty;
        }

        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Funcao { get; set; }
    }

    public class LoginResponse
    {
        public LoginResponse()
        {
            Token = string.Empty;
            Usuario = new UsuarioDto();
        }

        public string Token { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}
using System;

namespace RO.DevTest.Application.Features.User.Commands.CriarUsuarioCommand;

public class CriarUsuarioResult
{
    public Guid Id { get; set; }
    public string NomeUsuario { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Funcao { get; set; } = string.Empty;
}
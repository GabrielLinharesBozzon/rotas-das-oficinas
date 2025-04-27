using System.Text.Json.Serialization;
using RO.DevTest.Application.Contracts.DTOs;

namespace RO.DevTest.Application.Features.Auth.Commands.LoginCommand;

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

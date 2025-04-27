using MediatR;
using RO.DevTest.Application.Contracts.DTOs;

namespace RO.DevTest.Application.Features.Auth.Commands.LoginCommand;

public class LoginCommand : IRequest<LoginResponse>
{
    public LoginCommand()
    {
        Username = string.Empty;
        Password = string.Empty;
    }

    public string Username { get; set; }
    public string Password { get; set; }
}

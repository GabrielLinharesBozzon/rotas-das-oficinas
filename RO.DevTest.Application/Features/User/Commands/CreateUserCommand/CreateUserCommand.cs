using MediatR;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Domain.Enums;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand;

public class CreateUserCommand : IRequest<CreateUserResult>
{
    public string Username { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PasswordConfirmation { get; set; } = string.Empty;
    public UserRoles Role { get; set; }

    public Usuario AssignTo()
    {
        var usuario = new Usuario(Username, Email, Role.ToString());
        usuario.Nome = Name;
        return usuario;
    }
}

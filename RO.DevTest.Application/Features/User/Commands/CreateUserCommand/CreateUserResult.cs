using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand;

public record CreateUserResult
{
    public string Id { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public CreateUserResult() { }

    public CreateUserResult(Usuario usuario)
    {
        Id = usuario.Id;
        Username = usuario.UserName;
        Email = usuario.Email;
        Name = usuario.Nome;
    }
}

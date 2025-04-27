using MediatR;
using RO.DevTest.Domain.Enums;

namespace RO.DevTest.Application.Features.User.Commands.CriarUsuarioCommand;

public class CriarUsuarioCommand : IRequest<CriarUsuarioResult>
{
    public string NomeUsuario { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string ConfirmacaoSenha { get; set; } = string.Empty;
    public UserRoles Papel { get; set; }

    public Domain.Entities.User AtribuirPara()
    {
        var usuario = new Domain.Entities.User(NomeUsuario, Email, Senha, Papel.ToString());
        usuario.Name = Nome;
        return usuario;
    }
}
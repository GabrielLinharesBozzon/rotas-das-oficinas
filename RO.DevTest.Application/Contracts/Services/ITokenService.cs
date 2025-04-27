using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Contracts.Services
{
    public interface ITokenService
    {
        string GenerateToken(Usuario user);
    }
}
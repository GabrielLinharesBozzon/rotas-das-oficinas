using System.Threading.Tasks;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Domain.Enums;

namespace RO.DevTest.Application.Contracts.Services
{
    public interface IUserRoleService
    {
        Task<bool> AssignRoleToUserAsync(Usuario usuario, UserRole role);
        Task<bool> RemoveRoleFromUserAsync(Usuario usuario, UserRole role);
        Task<bool> IsInRoleAsync(Usuario usuario, UserRole role);
    }
}
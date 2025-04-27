using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RO.DevTest.Application.Contracts.Services;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Domain.Enums;

namespace RO.DevTest.Infrastructure.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly UserManager<Usuario> _userManager;

        public UserRoleService(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> AssignRoleToUserAsync(Usuario usuario, UserRole role)
        {
            var result = await _userManager.AddToRoleAsync(usuario, role.ToString());
            return result.Succeeded;
        }

        public async Task<bool> RemoveRoleFromUserAsync(Usuario usuario, UserRole role)
        {
            var result = await _userManager.RemoveFromRoleAsync(usuario, role.ToString());
            return result.Succeeded;
        }

        public async Task<bool> IsInRoleAsync(Usuario usuario, UserRole role)
        {
            return await _userManager.IsInRoleAsync(usuario, role.ToString());
        }
    }
} 
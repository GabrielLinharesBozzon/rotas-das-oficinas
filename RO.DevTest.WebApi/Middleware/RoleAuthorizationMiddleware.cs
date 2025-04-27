using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using RO.DevTest.Application.Contracts.Services;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Domain.Enums;

namespace RO.DevTest.WebApi.Middleware
{
    public class RoleAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserRoleService _userRoleService;

        public RoleAuthorizationMiddleware(RequestDelegate next, IUserRoleService userRoleService)
        {
            _next = next;
            _userRoleService = userRoleService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            if (endpoint == null)
            {
                await _next(context);
                return;
            }

            var roleAttribute = endpoint.Metadata.GetMetadata<RequireRoleAttribute>();
            if (roleAttribute == null)
            {
                await _next(context);
                return;
            }

            var user = context.User;
            if (!user.Identity.IsAuthenticated)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            var usuario = new Usuario { UserName = user.Identity.Name };
            if (!await _userRoleService.IsInRoleAsync(usuario, roleAttribute.Role))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                return;
            }

            await _next(context);
        }
    }

    public class RequireRoleAttribute : Attribute
    {
        public UserRole Role { get; }

        public RequireRoleAttribute(UserRole role)
        {
            Role = role;
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Domain.Enums;
using RO.DevTest.WebApi.Middleware;

namespace RO.DevTest.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        [RequireRole(UserRole.Admin)]
        public IActionResult GetAdminData()
        {
            return Ok(new { message = "Acesso permitido para administradores" });
        }

        [HttpGet("manager")]
        [RequireRole(UserRole.Manager)]
        public IActionResult GetManagerData()
        {
            return Ok(new { message = "Acesso permitido para gerentes" });
        }

        [HttpGet("sales")]
        [RequireRole(UserRole.Sales)]
        public IActionResult GetSalesData()
        {
            return Ok(new { message = "Acesso permitido para vendedores" });
        }

        [HttpGet("customer")]
        [RequireRole(UserRole.Customer)]
        public IActionResult GetCustomerData()
        {
            return Ok(new { message = "Acesso permitido para clientes" });
        }
    }
}
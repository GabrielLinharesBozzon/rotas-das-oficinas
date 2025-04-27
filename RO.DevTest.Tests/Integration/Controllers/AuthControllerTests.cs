using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RO.DevTest.Application.Contracts.DTOs;
using RO.DevTest.Domain.Enums;
using Xunit;

namespace RO.DevTest.Tests.Integration.Controllers
{
    public class AuthControllerTests : IClassFixture<TestWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public AuthControllerTests(TestWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Login_WithValidCredentials_ReturnsToken()
        {
            // Arrange
            var loginDto = new LoginDto
            {
                Email = "admin@test.com",
                Password = "Admin123!"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/auth/login", loginDto);
            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(result?.Token);
        }

        [Fact]
        public async Task Login_WithInvalidCredentials_ReturnsUnauthorized()
        {
            // Arrange
            var loginDto = new LoginDto
            {
                Email = "invalid@test.com",
                Password = "Invalid123!"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/auth/login", loginDto);

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }

    public class LoginResponse
    {
        public string Token { get; set; }
    }
}
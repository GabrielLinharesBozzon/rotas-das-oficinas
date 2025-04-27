using System;
using Microsoft.Extensions.Configuration;
using Moq;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Domain.Enums;
using RO.DevTest.Infrastructure.Services;
using Xunit;

namespace RO.DevTest.Tests.Unit.Services
{
    public class TokenServiceTests
    {
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly TokenService _tokenService;

        public TokenServiceTests()
        {
            _configurationMock = new Mock<IConfiguration>();
            _configurationMock.Setup(x => x["Jwt:Key"]).Returns("sua_chave_secreta_muito_segura_e_longa_para_assinatura_do_token");
            _configurationMock.Setup(x => x["Jwt:Issuer"]).Returns("RO.DevTest");
            _configurationMock.Setup(x => x["Jwt:Audience"]).Returns("RO.DevTest.Users");

            _tokenService = new TokenService(_configurationMock.Object);
        }

        [Fact]
        public void GenerateToken_ShouldReturnValidToken()
        {
            // Arrange
            var usuario = new Usuario("testuser", "test@example.com", UserRole.Admin);

            // Act
            var token = _tokenService.GenerateToken(usuario);

            // Assert
            Assert.NotNull(token);
            Assert.NotEmpty(token);
        }

        [Fact]
        public void GenerateToken_ShouldIncludeUserClaims()
        {
            // Arrange
            var usuario = new Usuario("testuser", "test@example.com", UserRole.Admin);

            // Act
            var token = _tokenService.GenerateToken(usuario);

            // Assert
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            Assert.Contains(jwtToken.Claims, c => c.Type == "name" && c.Value == "testuser");
            Assert.Contains(jwtToken.Claims, c => c.Type == "email" && c.Value == "test@example.com");
            Assert.Contains(jwtToken.Claims, c => c.Type == "role" && c.Value == "Admin");
        }

        [Fact]
        public void GenerateToken_ShouldThrowException_WhenJwtKeyIsMissing()
        {
            // Arrange
            _configurationMock.Setup(x => x["Jwt:Key"]).Returns((string)null);
            var usuario = new Usuario("testuser", "test@example.com", UserRole.Admin);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _tokenService.GenerateToken(usuario));
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Moq;
using RO.DevTest.Application.Contracts.Services;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Domain.Enums;
using RO.DevTest.Infrastructure.Services;
using Xunit;

namespace RO.DevTest.Tests.Unit.Services
{
    public class UserRoleServiceTests
    {
        private readonly Mock<UserManager<Usuario>> _userManagerMock;
        private readonly IUserRoleService _userRoleService;

        public UserRoleServiceTests()
        {
            var userStoreMock = new Mock<IUserStore<Usuario>>();
            _userManagerMock = new Mock<UserManager<Usuario>>(
                userStoreMock.Object,
                null, null, null, null, null, null, null, null);

            _userRoleService = new UserRoleService(_userManagerMock.Object);
        }

        [Fact]
        public async Task AssignRoleToUserAsync_ShouldReturnTrue_WhenRoleIsAssigned()
        {
            // Arrange
            var usuario = new Usuario("testuser", "test@example.com", UserRole.Admin);
            _userManagerMock.Setup(x => x.AddToRoleAsync(usuario, UserRole.Admin.ToString()))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _userRoleService.AssignRoleToUserAsync(usuario, UserRole.Admin);

            // Assert
            Assert.True(result);
            _userManagerMock.Verify(x => x.AddToRoleAsync(usuario, UserRole.Admin.ToString()), Times.Once);
        }

        [Fact]
        public async Task AssignRoleToUserAsync_ShouldReturnFalse_WhenRoleAssignmentFails()
        {
            // Arrange
            var usuario = new Usuario("testuser", "test@example.com", UserRole.Admin);
            _userManagerMock.Setup(x => x.AddToRoleAsync(usuario, UserRole.Admin.ToString()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Error" }));

            // Act
            var result = await _userRoleService.AssignRoleToUserAsync(usuario, UserRole.Admin);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task RemoveRoleFromUserAsync_ShouldReturnTrue_WhenRoleIsRemoved()
        {
            // Arrange
            var usuario = new Usuario("testuser", "test@example.com", UserRole.Admin);
            _userManagerMock.Setup(x => x.RemoveFromRoleAsync(usuario, UserRole.Admin.ToString()))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _userRoleService.RemoveRoleFromUserAsync(usuario, UserRole.Admin);

            // Assert
            Assert.True(result);
            _userManagerMock.Verify(x => x.RemoveFromRoleAsync(usuario, UserRole.Admin.ToString()), Times.Once);
        }

        [Fact]
        public async Task IsInRoleAsync_ShouldReturnTrue_WhenUserHasRole()
        {
            // Arrange
            var usuario = new Usuario("testuser", "test@example.com", UserRole.Admin);
            _userManagerMock.Setup(x => x.IsInRoleAsync(usuario, UserRole.Admin.ToString()))
                .ReturnsAsync(true);

            // Act
            var result = await _userRoleService.IsInRoleAsync(usuario, UserRole.Admin);

            // Assert
            Assert.True(result);
            _userManagerMock.Verify(x => x.IsInRoleAsync(usuario, UserRole.Admin.ToString()), Times.Once);
        }

        [Fact]
        public async Task IsInRoleAsync_ShouldReturnFalse_WhenUserDoesNotHaveRole()
        {
            // Arrange
            var usuario = new Usuario("testuser", "test@example.com", UserRole.Admin);
            _userManagerMock.Setup(x => x.IsInRoleAsync(usuario, UserRole.Admin.ToString()))
                .ReturnsAsync(false);

            // Act
            var result = await _userRoleService.IsInRoleAsync(usuario, UserRole.Admin);

            // Assert
            Assert.False(result);
        }
    }
}
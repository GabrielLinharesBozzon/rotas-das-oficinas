using Microsoft.AspNetCore.Identity;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Domain.Enums;

namespace RO.DevTest.Application.Contracts.Infrastructure;

/// <summary>
/// This is a abstraction of the Identity library, creating methods that will interact with 
/// it to create and update users
/// </summary>
public interface IIdentityAbstractor
{
    /// <summary>
    /// Finds a <see cref="Usuario"/> through its
    /// ID asynchronously
    /// </summary>
    /// <param name="userId">
    /// The <see cref="Usuario"/>s ID
    /// </param>
    /// <returns>
    /// The <see cref="Usuario"/> if found, <see cref="null"/>
    /// otherwise
    /// </returns>
    Task<Usuario?> FindUserByIdAsync(string userId);

    /// <summary>
    /// Finds a <see cref="Usuario"/> through its
    /// email asynchronously
    /// </summary>
    /// <param name="email">
    /// The <see cref="Usuario"/>s email
    /// </param>
    /// <returns>
    /// The <see cref="Usuario"/> if found, <see cref="null"/>
    /// otherwise
    /// </returns>
    Task<Usuario?> FindUserByEmailAsync(string email);

    /// <summary>
    /// Gets the names of the <see cref="IdentityRole"/>s
    /// that a <see cref="Usuario"/> has asynchronously
    /// </summary>
    /// <param name="user">
    /// The <see cref="Usuario"/> to get the <see cref="IdentityRole"/>s
    /// </param>
    /// <returns>
    /// A <see cref="IList{T}"/> with the names of the roles
    /// </returns>
    Task<IList<string>> GetUserRolesAsync(Usuario user);

    /// <summary>
    /// Signs in a <see cref="Usuario"/> asynchronously in a non
    /// persistent way. The <see cref="Usuario"/>'s account is not
    /// locked if failed
    /// </summary>
    /// <param name="user">
    /// The <see cref="Usuario"/> to sign in
    /// </param>
    /// <param name="password">
    /// The <see cref="Usuario"/>'s password
    /// </param>
    /// <returns>
    /// A <see cref="SignInResult"/>
    /// </returns>
    Task<SignInResult> PasswordSignInAsync(Usuario user, string password);

    /// <summary>
    /// Creates a <see cref="Usuario"/> asynchronously an returns
    /// the <see cref="IdentityResult"/> of it
    /// </summary>
    /// <param name="user">
    /// The <see cref="Usuario"/> to be added
    /// </param>
    /// <param name="password">
    /// The plain text of the password to be used to hash it
    /// </param>
    /// <returns>
    /// The <see cref="IdentityResult"/>
    /// </returns>
    Task<IdentityResult> CreateUserAsync(Usuario user, string password);

    /// <summary>
    /// Adds a <see cref="Usuario"/> to a <see cref="IdentityRole"/>
    /// asynchronously. If the role doesn't exist, it will be created.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    Task<IdentityResult> AddToRoleAsync(Usuario user, UserRoles role);

    /// <summary>
    /// Deletes a <see cref="Usuario"/> from the database
    /// </summary>
    /// <param name="user">
    /// The <see cref="Usuario"/> to be deleted
    /// </param>
    /// <returns>
    /// A <see cref="Task{IdentityResult}"/>
    /// </returns>
    Task<IdentityResult> DeleteUser(Usuario user);
}

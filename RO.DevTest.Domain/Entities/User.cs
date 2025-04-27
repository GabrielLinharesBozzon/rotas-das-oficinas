using System;
using Microsoft.AspNetCore.Identity;
using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Domain.Entities;

/// <summary>
/// Represents a <see cref="IdentityUser"/> int the API
/// </summary>
public class User : BaseEntity
{
    /// <summary>
    /// Name of the user
    /// </summary>
    public string Name { get; set; } = string.Empty;

    public string Username { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string Role { get; private set; }
    public bool IsActive { get; private set; }

    public User() : base() { }

    public User(string username, string email, string passwordHash, string role)
    {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
        IsActive = true;
    }

    public void Update(string username, string email, string role)
    {
        Username = username;
        Email = email;
        Role = role;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }
}

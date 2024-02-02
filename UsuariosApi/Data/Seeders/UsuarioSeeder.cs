using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Models;

namespace UsuariosApi.Data.Seeders;

public class UsuarioSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        // Create a hasher to hash the password before seeding the user to the database
        var hasher = new PasswordHasher<Usuario>();

        // Create a new user for seeding
        var user = new Usuario
        {
            Id = "1c57b409-6540-4295-8363-f9da245d92be", // Use the same user ID you want to seed
            UserName = "username",
            NormalizedUserName = "USERNAME",
            Email = "user@example.com",
            NormalizedEmail = "USER@EXAMPLE.COM",
            EmailConfirmed = true,
            SecurityStamp = string.Empty,
            RegisteredAt = DateTime.UtcNow,
            Role = "Admin",
            
        };

        // Set the user password
        user.PasswordHash = hasher.HashPassword(user, "Jovemfla1@");

        // Seed the user
        modelBuilder.Entity<Usuario>().HasData(user);

        // Seed a role
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "role-id",
            Name = "Admin",
            NormalizedName = "ADMIN"
        });

        // Seed the user role relation
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "role-id",
            UserId = user.Id
        });
    }
}
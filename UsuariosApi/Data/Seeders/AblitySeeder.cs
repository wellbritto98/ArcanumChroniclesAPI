using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Data.Seeders;

public class AbilitySeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ability>().HasData(
            new Ability { Id = 1, Name = "Natação", Description = "Nadar" },
            new Ability { Id = 2, Name = "Corrida", Description = "Correr" },
            new Ability { Id = 3, Name = "Luta", Description = "Lutar" },
            new Ability { Id = 4, Name = "Escalada", Description = "Escalar" },
            new Ability { Id = 5, Name = "Pulo", Description = "Pular" }
        );
    }
}
using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Data.Seeders;

public class WayOfMagicSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WayOfMagic>().HasData(
            new WayOfMagic { Id = 1, Name = "Arcana", Description = "arcana" },
            new WayOfMagic { Id = 2, Name = "Divina", Description = "divina" },
            new WayOfMagic { Id = 3, Name = "Druida", Description = "druida" },
            new WayOfMagic { Id = 4, Name = "Feiticeiro", Description = "feiticeiro" }
        );
    }
}
using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Data.Seeders;

public class RegionSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Region>().HasData(
            new Region { Id = 1, Name = "Solária" },
            new Region { Id = 2, Name = "Glacialis" }
        );
    }
}

using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Data.Seeders;

public class PoloSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Polo>().HasData(
            new Polo { Id = 1, Name = "Maris", RegionId = 1 },
            new Polo { Id = 2, Name = "Marécanto", RegionId = 1 },
            new Polo { Id = 3, Name = "Frostland", RegionId = 2 },
            new Polo { Id = 4, Name = "Summitia", RegionId = 2 }
        );
    }
}

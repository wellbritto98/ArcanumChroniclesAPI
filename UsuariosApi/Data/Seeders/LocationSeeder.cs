using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Data.Seeders;

public class LocationSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>().HasData(
            new Location { Id = 1, Name = "Ministério de Solária", PoloId = 1, CompanyId = 1 }
        );
    }
}
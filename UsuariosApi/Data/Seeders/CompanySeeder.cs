using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Data.Seeders;

public class CompanySeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>().HasData(
            new Company
            {
                Id = 1, Name = "Ministério de Solária", PoloId = 1, Type = CompanyType.Ministry, Money = 1000000
            }
        );
    }
}

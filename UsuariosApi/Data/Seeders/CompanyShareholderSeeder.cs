using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Data.Seeders;

public class CompanyShareholderSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompanyShareholder>().HasData(
            new CompanyShareholder { CharacterId = 1, CompanyId = 1, Shares = 100 }
        );
    }
}
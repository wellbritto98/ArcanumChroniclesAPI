using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Data.Seeders;

public class TypeOfMagicSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TypeOfMagic>().HasData(
            new TypeOfMagic { Id = 1, Name = "Não-magico", Description = "Não-magico" },
            new TypeOfMagic { Id = 2, Name = "Magico", Description = "Magico" },
            new TypeOfMagic { Id = 3, Name = "Mestiço", Description = "Mestiço" }
        );
    }
}
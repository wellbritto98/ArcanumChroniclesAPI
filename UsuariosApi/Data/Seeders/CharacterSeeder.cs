using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Data.Seeders;

public class CharacterSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>().HasData(
            new Character
            {
                Id = 1,
                Name = "Admilson",
                Surname = "Silva",
                UsuarioId = "1c57b409-6540-4295-8363-f9da245d92be",
                FatherBackgroundId = 1,
                MotherBackgroundId = 1,
                ChildhoodBackgroundId = 1,
                Gender = Enums.GenderEnum.Male,
                BirthDate = DateTime.UtcNow,
                BirthPoloId = 1,
                CurrentLocationId = 1,
                CharacterAvatarUrl =
                    "https://img.freepik.com/fotos-gratis/homem-bonito-posando-e-sorrindo_23-2149396133.jpg",
                WayOfMagicId = 1,
                TypeOfMagicId = 1
            });
    }
}

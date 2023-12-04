using Microsoft.EntityFrameworkCore;
using UsuariosApi.Models;

namespace UsuariosApi.Data.Seeders
{
    public class SurnameSeeder
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Surname>().HasData(
                new Surname { Id = 1, SurnameChar = "Smith" },
                new Surname { Id = 2, SurnameChar = "Johnson" },
                new Surname { Id = 3, SurnameChar = "Williams" },
                new Surname { Id = 4, SurnameChar = "Brown" },
                new Surname { Id = 5, SurnameChar = "Jones" },
                new Surname { Id = 6, SurnameChar = "Garcia" },
                new Surname { Id = 7, SurnameChar = "Miller" },
                new Surname { Id = 8, SurnameChar = "Davis" },
                new Surname { Id = 9, SurnameChar = "Rodriguez" },
                new Surname { Id = 10, SurnameChar = "Martinez" }
            );
        }
    }
}
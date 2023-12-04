using Microsoft.EntityFrameworkCore;
using UsuariosApi.Models;

namespace UsuariosApi.Data.Seeders
{
    public class NameSeeder
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Name>().HasData(
                new Name { Id = 1, NameChar = "James", Gender = "m" },
                new Name { Id = 2, NameChar = "John", Gender = "m" },
                new Name { Id = 3, NameChar = "Robert", Gender = "m" },
                new Name { Id = 4, NameChar = "Michael", Gender = "m" },
                new Name { Id = 5, NameChar = "William", Gender = "m" },
                new Name { Id = 6, NameChar = "David", Gender = "m" },
                new Name { Id = 7, NameChar = "Richard", Gender = "m" },
                new Name { Id = 8, NameChar = "Joseph", Gender = "m" },
                new Name { Id = 9, NameChar = "Charles", Gender = "m" },
                new Name { Id = 10, NameChar = "Thomas", Gender = "m" },
                new Name { Id = 11, NameChar = "Mary", Gender = "f" },
                new Name { Id = 12, NameChar = "Patricia", Gender = "f" },
                new Name { Id = 13, NameChar = "Jennifer", Gender = "f" },
                new Name { Id = 14, NameChar = "Linda", Gender = "f" },
                new Name { Id = 15, NameChar = "Elizabeth", Gender = "f" },
                new Name { Id = 16, NameChar = "Barbara", Gender = "f" },
                new Name { Id = 17, NameChar = "Susan", Gender = "f" },
                new Name { Id = 18, NameChar = "Jessica", Gender = "f" },
                new Name { Id = 19, NameChar = "Sarah", Gender = "f" },
                new Name { Id = 20, NameChar = "Karen", Gender = "f" }
            );
        }
    }
}
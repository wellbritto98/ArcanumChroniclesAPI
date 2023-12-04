using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Data.Seeders;

public class WayOfMagicSpellSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WayOfMagicSpell>().HasData(
            new WayOfMagicSpell { WayOfMagicId = 1, SpellId = 1 },
            new WayOfMagicSpell { WayOfMagicId = 2, SpellId = 1 },
            new WayOfMagicSpell { WayOfMagicId = 3, SpellId = 1 },
            new WayOfMagicSpell { WayOfMagicId = 4, SpellId = 1 }
        );
    }
}
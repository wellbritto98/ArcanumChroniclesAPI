using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Data.Seeders;

public class WayOfMagicAbilitySeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WayOfMagicAbility>().HasData(
            new WayOfMagicAbility { WayOfMagicId = 1, AbilityId = 1 },
            new WayOfMagicAbility { WayOfMagicId = 1, AbilityId = 2 },
            new WayOfMagicAbility { WayOfMagicId = 1, AbilityId = 3 },
            new WayOfMagicAbility { WayOfMagicId = 1, AbilityId = 4 },
            new WayOfMagicAbility { WayOfMagicId = 1, AbilityId = 5 },
            new WayOfMagicAbility { WayOfMagicId = 2, AbilityId = 1 },
            new WayOfMagicAbility { WayOfMagicId = 2, AbilityId = 2 },
            new WayOfMagicAbility { WayOfMagicId = 2, AbilityId = 3 },
            new WayOfMagicAbility { WayOfMagicId = 2, AbilityId = 4 },
            new WayOfMagicAbility { WayOfMagicId = 2, AbilityId = 5 },
            new WayOfMagicAbility { WayOfMagicId = 3, AbilityId = 1 },
            new WayOfMagicAbility { WayOfMagicId = 3, AbilityId = 2 },
            new WayOfMagicAbility { WayOfMagicId = 3, AbilityId = 3 },
            new WayOfMagicAbility { WayOfMagicId = 3, AbilityId = 4 },
            new WayOfMagicAbility { WayOfMagicId = 3, AbilityId = 5 },
            new WayOfMagicAbility { WayOfMagicId = 4, AbilityId = 1 },
            new WayOfMagicAbility { WayOfMagicId = 4, AbilityId = 2 },
            new WayOfMagicAbility { WayOfMagicId = 4, AbilityId = 3 },
            new WayOfMagicAbility { WayOfMagicId = 4, AbilityId = 4 },
            new WayOfMagicAbility { WayOfMagicId = 4, AbilityId = 5 }
        );
    }
}
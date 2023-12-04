using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UsuariosApi.Data.EntityConfig;

public class WayOfMagicAbilityConfiguration : IEntityTypeConfiguration<WayOfMagicAbility>
{
    public void Configure(EntityTypeBuilder<WayOfMagicAbility> builder)
    {
        builder.HasKey(wma => new { wma.WayOfMagicId, wma.AbilityId });

    }
}

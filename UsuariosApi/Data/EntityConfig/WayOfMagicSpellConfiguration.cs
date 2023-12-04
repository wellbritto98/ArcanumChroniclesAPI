using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class WayOfMagicSpellConfiguration : IEntityTypeConfiguration<WayOfMagicSpell>
{
    public void Configure(EntityTypeBuilder<WayOfMagicSpell> builder)
    {
        builder.HasKey(wms => new { wms.WayOfMagicId, wms.SpellId });
        // ... outras configurações específicas para WayOfMagicSpell
    }
}
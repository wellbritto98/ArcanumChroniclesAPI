using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsuariosApi.Models;

public class CompanyShareholderConfiguration : IEntityTypeConfiguration<CompanyShareholder>
{
    public void Configure(EntityTypeBuilder<CompanyShareholder> builder)
    {
        builder.HasKey(cs => new { cs.CharacterId, cs.CompanyId });
    }
}
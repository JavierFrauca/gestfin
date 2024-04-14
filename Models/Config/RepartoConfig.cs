using Gestfin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestfin.Models.Config
{
    public class RepartoConfig : IEntityTypeConfiguration<Reparto>
    {
        public void Configure(EntityTypeBuilder<Reparto> builder)
        {
            builder.Property(prop => prop.Descripcion)
               .HasMaxLength(150)
               .IsRequired();
            builder.Property(prop => prop.Enteros)
                .HasPrecision(18, 6)
                .IsRequired();
        }
    }
}

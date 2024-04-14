using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestfin.Models.Config
{
    public class ReciboPagoConfig : IEntityTypeConfiguration<ReciboPago>
    {
        public void Configure(EntityTypeBuilder<ReciboPago> builder)
        {
            builder.Property(prop => prop.Importe)
            .HasPrecision(18, 6)
            .IsRequired();
        }
    }
}

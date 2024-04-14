using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestfin.Models.Config
{
    public class ReciboDetalleConfig : IEntityTypeConfiguration<ReciboDetalle>
    {
        public void Configure(EntityTypeBuilder<ReciboDetalle> builder)
        {
            builder.ToTable(name: "RecibosDetalles", opciones => opciones.IsTemporal());
            builder.Property(prop => prop.Importe)
            .HasPrecision(18, 6)
            .IsRequired();
        }
    }
}

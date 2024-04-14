using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestfin.Models.Config
{
    public class ReciboConfig : IEntityTypeConfiguration<Recibo>
    {
        public void Configure(EntityTypeBuilder<Recibo> builder)
        {
            builder.ToTable(name: "Recibos", opciones => opciones.IsTemporal());
            builder.Property(prop => prop.Importe)
                .HasPrecision(18, 6)
                .IsRequired();
        }
    }
}

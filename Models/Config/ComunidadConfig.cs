using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Gestfin.Models.Config
{
    public class ComunidadConfig : IEntityTypeConfiguration<Comunidad>
    {
        public void Configure(EntityTypeBuilder<Comunidad> builder)
        {
            builder.ToTable(name: "Comunidades", opciones => opciones.IsTemporal());
        }
    }
}

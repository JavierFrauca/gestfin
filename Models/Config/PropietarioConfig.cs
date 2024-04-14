using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestfin.Models.Config
{
    public class PropietarioConfig : IEntityTypeConfiguration<Propietario>
    {
        public void Configure(EntityTypeBuilder<Propietario> builder)
        {
            builder.ToTable(name: "Propietarios", opciones => opciones.IsTemporal());
        }
    }
}

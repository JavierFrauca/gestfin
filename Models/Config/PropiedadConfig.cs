using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Gestfin.Models.Config
{
    public class PropiedadConfig : IEntityTypeConfiguration<Propiedad>
    {
        public void Configure(EntityTypeBuilder<Propiedad> builder)
        {
            builder.ToTable(name: "Propiedades", opciones => opciones.IsTemporal());
        }
    }
}

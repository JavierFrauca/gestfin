using Gestfin.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Gestfin
{
    public class MainDB(DbContextOptions<MainDB> options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("data source=localhost\\sqlexpress;initial catalog=gestfin;integrated security=true;trustservercertificate=true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Comunidad> Comunidades { get; set; }
        public virtual DbSet<Propiedad> Propiedades { get; set; }
        public virtual DbSet<Propietario> Propietarios { get; set; }
        public virtual DbSet<PropietarioPropiedad> PropietariosPropiedades { get; set; }
        public virtual DbSet<Concepto> Conceptos { get; set; }
        public virtual DbSet<Reparto> Repartos { get; set; }
        public virtual DbSet<RepartoParticipacion> RepartosParticipaciones { get; set; }
        public virtual DbSet<Recibo> Recibos { get; set; }
        public virtual DbSet<ReciboDetalle> RecibosDetalles { get; set; }
        public virtual DbSet<ReciboPago> RecibosPagos { get; set; }
    }
}
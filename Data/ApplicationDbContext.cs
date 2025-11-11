using Microsoft.EntityFrameworkCore;
using LicenciasAPI.Models;

namespace LicenciasAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Licencia> Licencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Licencia>(entity =>
            {
                entity.ToTable("Licencias");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DNI).HasMaxLength(9).IsRequired();
                entity.Property(e => e.OrdenDelDia).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Tipo).IsRequired();
                entity.Property(e => e.Provincia).IsRequired();
                entity.Property(e => e.Localidad).IsRequired();
                entity.Property(e => e.Direccion).IsRequired();
            });
        }
    }
}

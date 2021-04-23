using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace pruebaHACSYS.Models
{
    public partial class vueContext : DbContext
    {
        public vueContext()
        {
        }

        public vueContext(DbContextOptions<vueContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Reporte> Reportes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost; Database=vue; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Reporte>(entity =>
            {
                entity.HasKey(e => e.IdReporte);

                entity.ToTable("Reporte");

                entity.Property(e => e.IdReporte)
                    .HasMaxLength(10)
                    .HasColumnName("idReporte")
                    .IsFixedLength(true);

                entity.Property(e => e.Acciones)
                    .HasColumnType("text")
                    .HasColumnName("acciones");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estatus)
                    .HasColumnType("text")
                    .HasColumnName("estatus");

                entity.Property(e => e.Fecha)
                    .HasColumnType("text")
                    .HasColumnName("fecha");

                entity.Property(e => e.Nombre)
                    .HasColumnType("text")
                    .HasColumnName("nombre");

                entity.Property(e => e.Razon)
                    .HasColumnType("text")
                    .HasColumnName("razon");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Iluminame_La_Vida.Models.Data
{
    public partial class IluminameContext : DbContext
    {
        public IluminameContext()
        {
        }

        public IluminameContext(DbContextOptions<IluminameContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Etiqueta> Etiqueta { get; set; }
        public virtual DbSet<Foto> Fotos { get; set; }
        public virtual DbSet<Geoubicacion> Geoubicacions { get; set; }
        public virtual DbSet<Reporte> Reportes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-AP83LF2M; Database=Iluminame; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etiqueta>(entity =>
            {
                entity.HasKey(e => e.IdEtiqueta);

                entity.Property(e => e.IdEtiqueta).HasColumnName("Id_Etiqueta");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IdFoto).HasColumnName("Id_Foto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Foto>(entity =>
            {
                entity.HasKey(e => e.IdFoto);

                entity.ToTable("Foto");

                entity.Property(e => e.IdFoto).HasColumnName("Id_Foto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Geoubicacion>(entity =>
            {
                entity.HasKey(e => e.IdGeoubicacion);

                entity.ToTable("Geoubicacion");

                entity.Property(e => e.IdGeoubicacion).HasColumnName("id_geoubicacion");

                entity.Property(e => e.Latitud).HasColumnName("latitud");

                entity.Property(e => e.Longitud).HasColumnName("longitud");
            });

            modelBuilder.Entity<Reporte>(entity =>
            {
                entity.HasKey(e => e.IdReporte);

                entity.ToTable("Reporte");

                entity.Property(e => e.IdReporte).HasColumnName("Id_Reporte");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdEtiqueta).HasColumnName("Id_Etiqueta");

                entity.Property(e => e.IdFoto).HasColumnName("Id_Foto");

                entity.Property(e => e.IdGeoubicacion).HasColumnName("Id_Geoubicacion");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.HasOne(d => d.IdEtiquetaNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.IdEtiqueta)
                    .HasConstraintName("FK_Reporte_Etiqueta");

                entity.HasOne(d => d.IdFotoNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.IdFoto)
                    .HasConstraintName("FK_Reporte_Foto");

                entity.HasOne(d => d.IdGeoubicacionNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.IdGeoubicacion)
                    .HasConstraintName("FK_Reporte_Geoubicacion");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Reporte_Usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdFoto).HasColumnName("Id_Foto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

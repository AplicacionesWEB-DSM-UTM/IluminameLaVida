using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Iluminame_La_Vida.Models
{
    public partial class IluminameFinalContext : DbContext
    {
        public IluminameFinalContext()
        {
        }

        public IluminameFinalContext(DbContextOptions<IluminameFinalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Etiqueta> Etiqueta { get; set; }
        public virtual DbSet<Reporte> Reportes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-AP83LF2M; Database=IluminameFinal; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etiqueta>(entity =>
            {
                entity.HasKey(e => e.IdEtiqueta);

                entity.Property(e => e.IdEtiqueta).HasColumnName("Id_Etiqueta");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reporte>(entity =>
            {
                entity.HasKey(e => e.IdReporte)
                    .HasName("PK_Report");

                entity.ToTable("Reporte");

                entity.Property(e => e.IdReporte).HasColumnName("Id_Reporte");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Foto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdEtiqueta).HasColumnName("Id_Etiqueta");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.HasOne(d => d.IdEtiquetaNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.IdEtiqueta)
                    .HasConstraintName("FK_Report_Etiqueta");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Report_Usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK_Registro");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

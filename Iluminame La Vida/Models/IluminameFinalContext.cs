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

        public virtual DbSet<Etiquetum> Etiqueta { get; set; }
        public virtual DbSet<Registro> Registros { get; set; }
        public virtual DbSet<Reporte> Reportes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server =DESKTOP-L2QVN2H\\SQLEXPRESS; Database =IluminameFinal; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etiquetum>(entity =>
            {
                entity.HasKey(e => e.IdEtiqueta);

                entity.Property(e => e.IdEtiqueta)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_etiqueta");

                entity.Property(e => e.DescEti)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Desc_Eti");

                entity.Property(e => e.FotoEti)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Foto_Eti");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Registro>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Registro");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");

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

            modelBuilder.Entity<Reporte>(entity =>
            {
                entity.HasKey(e => e.IdReporte);

                entity.Property(e => e.IdReporte)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Reporte");

                entity.Property(e => e.Coords)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescripLugar)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDen).HasColumnType("datetime");

                entity.Property(e => e.FotoReporte)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Foto_Reporte");

                entity.Property(e => e.IdEtiqueta).HasColumnName("Id_Etiqueta");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");

                entity.HasOne(d => d.IdEtiquetaNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.IdEtiqueta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reportes_Etiqueta");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reportes_Registro");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

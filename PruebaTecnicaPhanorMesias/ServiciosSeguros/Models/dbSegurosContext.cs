using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServiciosSeguros.Models
{
    public partial class dbSegurosContext : DbContext
    {
        public dbSegurosContext()
        {
        }

        public dbSegurosContext(DbContextOptions<dbSegurosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbRol> TbRol { get; set; }
        public virtual DbSet<TbUsuario> TbUsuario { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=PMESIAS\\SQLDEVELOPER;Database=dbSeguros;UID=sa;PWD=123456;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbRol>(entity =>
            {
                entity.HasKey(e => e.RolId)
                    .HasName("PK_usrTbRol");

                entity.ToTable("tbRol", "usr");

                entity.Property(e => e.RolId).HasColumnName("rolId");

                entity.Property(e => e.Rol)
                    .HasColumnName("rol")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.HasKey(e => e.UsuarioId)
                    .HasName("PK_usrTbUsuario");

                entity.ToTable("tbUsuario", "usr");

                entity.HasIndex(e => e.Login)
                    .HasName("AK_usrLogin")
                    .IsUnique();

                entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");

                entity.Property(e => e.Contrasena)
                    .HasColumnName("contrasena")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasColumnName("nombres")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RolId).HasColumnName("rolId");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.TbUsuario)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK_tbUsuario_tbRol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

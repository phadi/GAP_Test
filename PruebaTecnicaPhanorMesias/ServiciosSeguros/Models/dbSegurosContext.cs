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

        public virtual DbSet<TbCliente> TbCliente { get; set; }
        public virtual DbSet<TbPermisoPorRol> TbPermisoPorRol { get; set; }
        public virtual DbSet<TbPoliza> TbPoliza { get; set; }
        public virtual DbSet<TbPolizaPorCliente> TbPolizaPorCliente { get; set; }
        public virtual DbSet<TbRol> TbRol { get; set; }
        public virtual DbSet<TbTipoCubrimiento> TbTipoCubrimiento { get; set; }
        public virtual DbSet<TbTipoDoc> TbTipoDoc { get; set; }
        public virtual DbSet<TbTipoRiesgo> TbTipoRiesgo { get; set; }
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
            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.ClienteId)
                    .HasName("PK_seguroTbCliente");

                entity.ToTable("tbCliente", "seguro");

                entity.HasIndex(e => e.Documento)
                    .HasName("AK_DocumentoUser")
                    .IsUnique();

                entity.Property(e => e.ClienteId).HasColumnName("clienteId");

                entity.Property(e => e.Direccrion)
                    .HasColumnName("direccrion")
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .HasColumnName("documento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCompleto)
                    .HasColumnName("nombreCompleto")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDoc).HasColumnName("tipoDoc");

                entity.HasOne(d => d.TipoDocNavigation)
                    .WithMany(p => p.TbCliente)
                    .HasForeignKey(d => d.TipoDoc)
                    .HasConstraintName("FK_tbCliente_tbTipoDoc");
            });

            modelBuilder.Entity<TbPermisoPorRol>(entity =>
            {
                entity.HasKey(e => e.PermisoPorRolId)
                    .HasName("PK_usrTbPermisoPorRol");

                entity.ToTable("tbPermisoPorRol", "usr");

                entity.Property(e => e.PermisoPorRolId).HasColumnName("permisoPorRolId");

                entity.Property(e => e.Accion)
                    .HasColumnName("accion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Controlador)
                    .HasColumnName("controlador")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nivel).HasColumnName("nivel");

                entity.Property(e => e.RolId).HasColumnName("rolId");

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.TbPermisoPorRol)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK_tbPermisoPorRol_tbRol");
            });

            modelBuilder.Entity<TbPoliza>(entity =>
            {
                entity.HasKey(e => e.PolizaId)
                    .HasName("PK_seguroTbPoliza");

                entity.ToTable("tbPoliza", "seguro");

                entity.Property(e => e.PolizaId).HasColumnName("polizaId");

                entity.Property(e => e.Cubrimiento)
                    .HasColumnName("cubrimiento")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Descriocion)
                    .HasColumnName("descriocion")
                    .IsUnicode(false);

                entity.Property(e => e.InicioVigencia)
                    .HasColumnName("inicioVigencia")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodoCobertura).HasColumnName("periodoCobertura");

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("money");

                entity.Property(e => e.TipoCubrimiento).HasColumnName("tipoCubrimiento");

                entity.Property(e => e.TipoRiesgo).HasColumnName("tipoRiesgo");

                entity.HasOne(d => d.TipoCubrimientoNavigation)
                    .WithMany(p => p.TbPoliza)
                    .HasForeignKey(d => d.TipoCubrimiento)
                    .HasConstraintName("FK_tbPoliza_tbTipoCubrimiento");

                entity.HasOne(d => d.TipoRiesgoNavigation)
                    .WithMany(p => p.TbPoliza)
                    .HasForeignKey(d => d.TipoRiesgo)
                    .HasConstraintName("FK_tbPoliza_tbTipoRiesgo");
            });

            modelBuilder.Entity<TbPolizaPorCliente>(entity =>
            {
                entity.HasKey(e => e.PolizaPorClienteId)
                    .HasName("PK_seguroTbPolizaPorCliente");

                entity.ToTable("tbPolizaPorCliente", "seguro");

                entity.Property(e => e.ClientreId).HasColumnName("clientreId");

                entity.Property(e => e.FechaIfinal)
                    .HasColumnName("fechaIFinal")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.PolizaId).HasColumnName("polizaId");

                entity.HasOne(d => d.Clientre)
                    .WithMany(p => p.TbPolizaPorCliente)
                    .HasForeignKey(d => d.ClientreId)
                    .HasConstraintName("FK_tbPolizaPorCliente_tbCliente");

                entity.HasOne(d => d.Poliza)
                    .WithMany(p => p.TbPolizaPorCliente)
                    .HasForeignKey(d => d.PolizaId)
                    .HasConstraintName("FK_tbPolizaPorCliente_tbPoliza");
            });

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

            modelBuilder.Entity<TbTipoCubrimiento>(entity =>
            {
                entity.HasKey(e => e.TipoCubrimientoId)
                    .HasName("PK_seguroTbTipoCubrimiento");

                entity.ToTable("tbTipoCubrimiento", "seguro");

                entity.Property(e => e.TipoCubrimientoId).HasColumnName("tipoCubrimientoId");

                entity.Property(e => e.TipoCubrimiento)
                    .HasColumnName("tipoCubrimiento")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbTipoDoc>(entity =>
            {
                entity.HasKey(e => e.TipoDocId)
                    .HasName("PK_seguroTbTipoDoc");

                entity.ToTable("tbTipoDoc", "seguro");

                entity.Property(e => e.TipoDocId).HasColumnName("tipoDocId");

                entity.Property(e => e.TipoDocumento)
                    .HasColumnName("tipoDocumento")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbTipoRiesgo>(entity =>
            {
                entity.HasKey(e => e.TipoRiesgoId)
                    .HasName("PK_seguroTbTipoRiesgo");

                entity.ToTable("tbTipoRiesgo", "seguro");

                entity.Property(e => e.TipoRiesgoId).HasColumnName("tipoRiesgoId");

                entity.Property(e => e.TipoRiesgo)
                    .HasColumnName("tipoRiesgo")
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

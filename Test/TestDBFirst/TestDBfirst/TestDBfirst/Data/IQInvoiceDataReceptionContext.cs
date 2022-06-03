using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestDBfirst.Data
{
    public partial class IQInvoiceDataReceptionContext : DbContext
    {
        public IQInvoiceDataReceptionContext()
        {
        }

        public IQInvoiceDataReceptionContext(DbContextOptions<IQInvoiceDataReceptionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<RequestInvoiceData> RequestInvoiceData { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ServiceDetail> ServiceDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=bog-dev-dtabase;Database=IQInvoiceDataReception;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AI");

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.IdInvoice)
                    .HasName("PK__Invoice__4AFC50A4B27FC295");

                entity.ToTable("Invoice", "Data");

                entity.Property(e => e.IdInvoice).ValueGeneratedNever();

                entity.Property(e => e.Anticipo).HasColumnType("money");

                entity.Property(e => e.CamposObservaciones)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Cargos).HasColumnType("money");

                entity.Property(e => e.CodigoHabilitacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Copago).HasColumnType("money");

                entity.Property(e => e.Cude)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CuotaModeradora).HasColumnType("money");

                entity.Property(e => e.DigitoVerificacionPagador).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.DigitoVerificacionPrestador).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.FechaEgreso).HasColumnType("datetime");

                entity.Property(e => e.FechaFactura).HasColumnType("datetime");

                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.NitPagador).HasColumnType("numeric(13, 0)");

                entity.Property(e => e.NitPrestador).HasColumnType("numeric(13, 0)");

                entity.Property(e => e.NombrePagador)
                    .IsRequired()
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePrestador)
                    .IsRequired()
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroAutorizacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroContrato)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroFactura).HasColumnType("numeric(20, 0)");

                entity.Property(e => e.NumeroIdsuministroMipres)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NumeroIDSuministroMIPRES");

                entity.Property(e => e.NumeroImpres)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NumeroIMPRES");

                entity.Property(e => e.NumeroPoliza)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroidentificacionAfiliado).HasColumnType("numeric(13, 0)");

                entity.Property(e => e.PrefijoFactura)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellidoAfiliado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombreAfiliado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellidoAfiliado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombreAfiliado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SucursalPrincipalDepto).HasColumnType("numeric(2, 0)");

                entity.Property(e => e.SucursalPrincipalDireccion)
                    .IsRequired()
                    .HasMaxLength(1400)
                    .IsUnicode(false);

                entity.Property(e => e.SucursalPrincipalMun).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.SucursalSegundalDepto).HasColumnType("numeric(2, 0)");

                entity.Property(e => e.SucursalSegundalDireccion)
                    .HasMaxLength(1400)
                    .IsUnicode(false);

                entity.Property(e => e.SucursalSegundalMun).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.TipoDocumentoFact91N92)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumentoPrestador).HasColumnType("numeric(2, 0)");

                entity.Property(e => e.TipoIdentificacionAfiliado)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIdentificacionPagador).HasColumnType("numeric(2, 0)");

                entity.Property(e => e.TipoOperacion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ValorBruto).HasColumnType("money");

                entity.Property(e => e.ValorDescuento).HasColumnType("money");

                entity.Property(e => e.ValorIva)
                    .HasColumnType("money")
                    .HasColumnName("ValorIVA");

                entity.Property(e => e.ValorNeto).HasColumnType("money");
            });

            modelBuilder.Entity<RequestInvoiceData>(entity =>
            {
                entity.ToTable("RequestInvoiceData", "Log");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.Property(e => e.RequestJson)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "Auth");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ServiceDetail>(entity =>
            {
                entity.ToTable("ServiceDetail", "Data");

                entity.Property(e => e.Cantidad).HasColumnType("numeric(9, 0)");

                entity.Property(e => e.CodigoServicio)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionServicio)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ValorIva)
                    .HasColumnType("money")
                    .HasColumnName("ValorIVA");

                entity.Property(e => e.ValorTotal).HasColumnType("money");

                entity.Property(e => e.ValorUnitario).HasColumnType("money");

                entity.HasOne(d => d.IdInvoiceNavigation)
                    .WithMany(p => p.ServiceDetails)
                    .HasForeignKey(d => d.IdInvoice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ServiceDe__IdInv__36B12243");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("User", "Auth");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsLocked).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole", "Auth");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

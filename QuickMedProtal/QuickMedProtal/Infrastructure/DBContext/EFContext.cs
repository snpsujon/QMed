using Microsoft.EntityFrameworkCore;
using QuickMedProtal.Infrastructure.Models;

namespace QuickMedProtal.Infrastructure.DBContext
{
    public class EFContext : DbContext
    {
        public EFContext()
        {

        }

        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Menu_Permission> Menu_Permissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer(
                "Server=203.26.151.51;User Id=techstdio;Password=Asdf019lkjh;Database=QuickDB; Persist Security Info=true; TrustServerCertificate=true;Trusted_Connection=false;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasMaxLength(50);
                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.MenuIcon)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.MenuUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });
            modelBuilder.Entity<Menu_Permission>(entity =>
            {
                entity.ToTable("Menu_Permission");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasMaxLength(50);
                entity.Property(e => e.RoleId).HasMaxLength(450);
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });
        }
    }
}

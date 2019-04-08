using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Graham.Models
{
    public partial class GrahamContext : DbContext
    {
        public GrahamContext()
        {
        }

        public GrahamContext(DbContextOptions<GrahamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Holder> Holder { get; set; }
        public virtual DbSet<Market> Market { get; set; }
        public virtual DbSet<Portfolio> Portfolio { get; set; }
        public virtual DbSet<PortfolioSecurity> PortfolioSecurity { get; set; }
        public virtual DbSet<Security> Security { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-91VKTF3;Initial Catalog=Graham;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Holder>(entity =>
            {
                entity.HasKey(e => e.IdHolder);

                entity.Property(e => e.IdHolder).ValueGeneratedNever();

                entity.Property(e => e.Denomination)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Market>(entity =>
            {
                entity.HasKey(e => e.IdMarket);

                entity.Property(e => e.IdMarket).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.HasKey(e => e.IdPortfolio);

                entity.Property(e => e.IdPortfolio).ValueGeneratedNever();

                entity.HasOne(d => d.IdHolderNavigation)
                    .WithMany(p => p.Portfolio)
                    .HasForeignKey(d => d.IdHolder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Portfolio_Holder");
            });

            modelBuilder.Entity<PortfolioSecurity>(entity =>
            {
                entity.HasKey(e => e.IdPortfolioSecurity);

                entity.HasOne(d => d.IdPortfolioNavigation)
                    .WithMany(p => p.PortfolioSecurity)
                    .HasForeignKey(d => d.IdPortfolio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortfolioHolder_Portfolio");

                entity.HasOne(d => d.IdSecurityNavigation)
                    .WithMany(p => p.PortfolioSecurity)
                    .HasForeignKey(d => d.IdSecurity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortfolioHolder_Security");
            });

            modelBuilder.Entity<Security>(entity =>
            {
                entity.HasKey(e => e.IdSecurity);

                entity.Property(e => e.IdSecurity).ValueGeneratedNever();

                entity.Property(e => e.CurrentPrice).HasColumnType("decimal(8, 5)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMarketNavigation)
                    .WithMany(p => p.Security)
                    .HasForeignKey(d => d.IdMarket)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Security_Market");
            });
        }
    }
}

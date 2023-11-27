using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.DBModels
{
    public partial class DBAgentContext : DbContext
    {
        public DBAgentContext()
        {
        }

        public DBAgentContext(DbContextOptions<DBAgentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<SearchLogging> SearchLoggings { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserFavorite> UserFavorites { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=DBAgent;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");

                entity.Property(e => e.BranchAddress).HasMaxLength(100);

                entity.Property(e => e.BranchName).HasMaxLength(50);

                entity.Property(e => e.BranchPhone).HasMaxLength(10);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Branch_Region");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(50);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.Region1);

                entity.ToTable("Region");

                entity.Property(e => e.Region1).HasColumnName("Region");

                entity.Property(e => e.RegionName).HasMaxLength(50);
            });

            modelBuilder.Entity<SearchLogging>(entity =>
            {
                entity.ToTable("SearchLogging");

                entity.Property(e => e.CrationDate).HasColumnType("datetime");

                entity.Property(e => e.SearchParameters)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserEmail).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserPhoneNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<UserFavorite>(entity =>
            {
                entity.HasKey(e => e.UserFavoritesId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

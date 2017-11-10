using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

namespace Picbook.Repository.EntityFramework.Entities
{
    public partial class PicBookContext : DbContext
    {
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=Ben-PC\SQLEXPRESS;Initial Catalog=PicBook;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.MobilNumber)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProfileImageUrl).HasMaxLength(1024);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(24)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Album_Account");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MobileSizeUrl)
                    .HasColumnName("MobileSizeURL")
                    .HasMaxLength(1024);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.OriginalSizeUrl)
                    .IsRequired()
                    .HasColumnName("OriginalSizeURL")
                    .HasMaxLength(1024);

                entity.Property(e => e.WebSizeUrl)
                    .HasColumnName("WebSizeURL")
                    .HasMaxLength(1024);

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK_Image_Album");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_Account");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_Image");
            });
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                
            }

            return Task.FromResult(0);
        }
    }
}

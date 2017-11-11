using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PicBook.Web.ServerSide.Entities
{
    class PicBookDbContext : IdentityDbContext<Account, ApplicationRole, Guid>
    {
        
            public DbSet<Account> Account { get; set; }
            public DbSet<ApplicationRole> ApplicationRoles { get; set; }
            public DbSet<Image> Images { get; set; }
            public DbSet<Album> Albums { get; set; }
            public DbSet<Rating> Ratings { get; set; }

            public PicBookDbContext(DbContextOptions<PicBookDbContext> options) : base(options)
            { }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Account>(entity =>
                {
                    entity.ToTable("Account");
                });
            }
        
    }
}

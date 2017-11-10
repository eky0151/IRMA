using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PicBook.Web.ServerSide.Entities
{
    class PicBookDbContext : IdentityDbContext<Account, ApplicationRole, Guid>
    {
        
            public DbSet<Account> ApplicationUsers { get; set; }
            public DbSet<ApplicationRole> ApplicationRoles { get; set; }
            public DbSet<Image> Images { get; set; }
            public DbSet<Album> Albums { get; set; }
            public DbSet<Rating> Ratings { get; set; }

            public PicBookDbContext(DbContextOptions<PicBookDbContext> options) : base(options)
            { }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                // Customize the ASP.NET Identity model and override the defaults if needed.
                // For example, you can rename the ASP.NET Identity table names and more.
                // Add your customizations after calling base.OnModelCreating(builder);
            }
        
    }
}

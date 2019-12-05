using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EFСore
{
    public class AdminDbContext : IdentityDbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole
                {
                    Name = "Admin", NormalizedName = "ADMIN", Id = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
        }
    }
}
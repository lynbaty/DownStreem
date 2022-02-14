using downstreem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace downstreem.Data;

public class ApplicationDataContext : IdentityDbContext
{
    public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options)
        : base(options)
    {
    }

    public DbSet<User> User { get; set; }

    public DbSet<Entity> Entities { set; get; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Change column name Id => UserId
        // builder.Entity<IdentityUser>().ToTable("User").Property(p => p.Id).HasColumnName("UserId");

        builder.Entity<IdentityUser>().ToTable("User");
        builder.Entity<IdentityRole>().ToTable("Role");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
        builder.Entity<Entity>().ToTable("Entities");
    }
}

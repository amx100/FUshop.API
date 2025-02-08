global using Persistence.Configurations;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProperty.API.Core.Domain.Entities.JointTable;

namespace Persistence;

public sealed class DataContext(DbContextOptions options) : IdentityDbContext<
    Account,
    AccountRole,
    string,
    IdentityUserClaim<string>, // TUserClaim
    AccountIdentityUserRole, // TUserRole,
    IdentityUserLogin<string>, // TUserLogin
    IdentityRoleClaim<string>, // TRoleClaim
    IdentityUserToken<string> // TUserToken
>(options)
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Account>().ToTable("AspNetUsers");
        modelBuilder.Entity<AccountIdentityUserRole>().ToTable("AspNetUserRoles");
        modelBuilder.Entity<AccountRole>().ToTable("AspNetRoles");
        modelBuilder.Entity<AccountIdentityUserRole>()
            .HasOne(p => p.User)
            .WithMany(b => b.Roles)
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<AccountIdentityUserRole>()
            .HasOne(x => x.Role)
            .WithMany(x => x.Roles)
            .HasForeignKey(p => p.RoleId);

        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
    }

    public DbSet<Product>? Products { get; set; }
    public DbSet<ProductSize> ProductSizes { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<OrderItem>? OrderItems { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<Size>? Sizes {  get; set; }
}
using Microsoft.EntityFrameworkCore;
using WarThunderParody.Domain.Entity;

namespace WarThunderParody.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRole>().HasNoKey();
    }

    public DbSet<Category> category { get; set; }
    public DbSet<Nation> nation { get; set; }
    public DbSet<Order> order { get; set; }
    public DbSet<Product> product { get; set; }
    public DbSet<Roles> roles { get; set; }
    public DbSet<UserAccount> user_account { get; set; }
    public DbSet<UserRole> user_role { get; set; }
}
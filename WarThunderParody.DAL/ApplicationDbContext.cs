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
            modelBuilder.Entity<Category>().ToTable("category");
            modelBuilder.Entity<Nation>().ToTable("nation");
            modelBuilder.Entity<Order>().ToTable("order");
            modelBuilder.Entity<Role>().ToTable("role");
            modelBuilder.Entity<Account>().ToTable("account");
            modelBuilder.Entity<UserRole>().ToTable("user_role");
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Nation> Nation { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> UserAccount { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
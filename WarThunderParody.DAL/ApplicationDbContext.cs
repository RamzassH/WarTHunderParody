using Microsoft.EntityFrameworkCore;
using WarThunderParody.Domain.Entity;

namespace WarThunderParody.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Category> category { get; set; }
}
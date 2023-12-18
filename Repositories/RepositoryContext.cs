using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Config;
using System.Reflection;

namespace Repositories;

public class RepositoryContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public RepositoryContext(DbContextOptions<RepositoryContext> options)
    : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //Config dosyasındaki configrastonları tek tek aşşağıdaki gibi tanımlayabiliriz.
        
        //modelBuilder.ApplyConfiguration(new ProductConfig());
        //modelBuilder.ApplyConfiguration(new CategoryConfig());

        //ya da aşşağıdaki gibi tek seferde tanımlayabiliriz.

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}


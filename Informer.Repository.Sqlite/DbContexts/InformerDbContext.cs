using Informer.Repository.Contract.Models;
using Informer.Repository.Sqlite.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Informer.Repository.Sqlite.DbContexts;

public class FDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public FDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder Builder)
    {
        base.OnModelCreating(Builder);

        Builder.ApplyConfigurationsFromAssembly(typeof(EmployeeMapping).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlite("Data Source=c:\\Database\\products.db");
        
    }
}

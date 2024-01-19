using Informer.Repository.Contract.Models;
using Informer.Repository.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Informer.Repository.DbContexts;

public class InformerDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public InformerDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder Builder)
    {
        base.OnModelCreating(Builder);

        Builder.ApplyConfigurationsFromAssembly(typeof(EmployeeMapping).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
}

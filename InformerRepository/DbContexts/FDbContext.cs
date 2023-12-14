using InformerRepository.Contract.Models;
using InformerRepository.Mappings;
using Microsoft.EntityFrameworkCore;

namespace InformerRepository.DbContexts;

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
}

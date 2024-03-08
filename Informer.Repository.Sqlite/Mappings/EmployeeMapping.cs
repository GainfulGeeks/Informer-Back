using Informer.Repository.Contract.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Informer.Repository.Mappings;

public class EmployeeMapping : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName).HasMaxLength(50);

        builder.Property(x => x.LastName).HasMaxLength(40);
    }
}
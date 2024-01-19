using Informer.Repository.Contract;
using Informer.Repository.Contract.Models;
using Informer.Repository.DbContexts;

namespace Informer.Repository.Repositories;

public class EmployeeRepositoy : IEmployeeRepository
{
    private readonly InformerDbContext _dbContext;

    public EmployeeRepositoy(InformerDbContext contexts)
    {
        _dbContext = contexts;
    }

    public List<Employee> GetEmployees()
    {
        return _dbContext.Employees.ToList();
    }
}
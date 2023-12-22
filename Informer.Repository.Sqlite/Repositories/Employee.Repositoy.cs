using Informer.Repository.Contract;
using Informer.Repository.Contract.Models;
using Informer.Repository.Sqlite.DbContexts;

namespace Informer.Repository.Sqlite.Repositories;

public class EmployeeRepositoy : IEmployeeRepository
{
    private readonly FDbContext _dbContext;

    public EmployeeRepositoy(FDbContext contexts)
    {
        _dbContext = contexts;
    }

    public List<Employee> GetEmployees()
    {
        return _dbContext.Employees.ToList();
    }
}
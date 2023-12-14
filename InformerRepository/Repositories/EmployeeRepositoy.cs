using InformerRepository.Contract;
using InformerRepository.Contract.Models;
using InformerRepository.DbContexts;

namespace InformerRepository.Repositories;

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
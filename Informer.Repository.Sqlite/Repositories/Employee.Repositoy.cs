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

    public Employee GetById(int id)
    {
        return _dbContext.Employees.Where(a => a.Id == id).FirstOrDefault();
    }

    public void Create(Employee employee)
    {
        _dbContext.Employees.Add(employee);
    }

    public void Delete(Employee employee)
    {
        _dbContext.Employees.Remove(employee);
    }
}
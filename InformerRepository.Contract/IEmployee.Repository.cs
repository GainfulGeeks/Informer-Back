using Informer.Repository.Contract.Models;

namespace Informer.Repository.Contract;

public interface IEmployeeRepository
{
    List<Employee> GetEmployees();
    void Create(Employee employee);
    void Delete(Employee employee);
    Employee GetById(int id);
    void Update();
}

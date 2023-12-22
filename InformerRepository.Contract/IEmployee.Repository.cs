using Informer.Repository.Contract.Models;

namespace Informer.Repository.Contract;

public interface IEmployeeRepository
{
    List<Employee> GetEmployees();
}

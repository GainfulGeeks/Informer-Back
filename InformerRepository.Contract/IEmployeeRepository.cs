using InformerRepository.Contract.Models;

namespace InformerRepository.Contract;

public interface IEmployeeRepository
{
    List<Employee> GetEmployees();
}

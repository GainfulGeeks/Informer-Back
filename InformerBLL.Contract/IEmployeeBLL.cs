using InformerBLL.Contract.Models;

namespace InformerBLL.Contract;

public interface IEmployeeBLL
{
    List<EmployeeDTO> GetEmployees();
}
using Informer.BLL.Contract.Models;

namespace Informer.BLL.Contract;

public interface IEmployeeBLL
{
    List<EmployeeDTO> GetEmployees();
}
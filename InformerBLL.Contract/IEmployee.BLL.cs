using Informer.BLL.Contract.Models;

namespace Informer.BLL.Contract;

public interface IEmployeeBLL
{
    List<EmployeeDTO> GetEmployees();
    void Create(CreateOrModifyEmployeeDTO employeeDTO);
    void Delete(int id);
    void Update(int id, CreateOrModifyEmployeeDTO dto);
}
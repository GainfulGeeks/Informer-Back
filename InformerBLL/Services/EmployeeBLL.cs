using InformerBLL.Contract;
using InformerBLL.Contract.Models;
using InformerRepository.Contract;

namespace InformerBLL.Services;

public class EmployeeBLL : IEmployeeBLL
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeBLL(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    public List<EmployeeDTO> GetEmployees()
    {
        var employees = _employeeRepository.GetEmployees();

        return employees.Select(x => new EmployeeDTO
        {
            Address = x.Address,
            Birthdate = x.Birthdate,
            FirstName = x.FirstName,
            LastName = x.LastName,
            PersonnelCode = x.PersonnelCode,
            PhoneNumber = x.PhoneNumber
        }).ToList();
    }
}
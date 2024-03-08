using Informer.BLL.Contract;
using Informer.BLL.Contract.Models;
using Informer.BLL.Services.Mapper;
using Informer.Repository.Contract;

namespace Informer.BLL.Services;

public class EmployeeBLL : IEmployeeBLL
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeBLL(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public void Create(CreateOrModifyEmployeeDTO employeeDTO)
    {
        var employee = EmployeeMapper.Map(employeeDTO);

        _employeeRepository.Create(employee);
    }

    public List<EmployeeDTO> GetEmployees()
    {
        var employees = _employeeRepository.GetEmployees();

        return employees.Select(x => new EmployeeDTO
        {
            Id = x.Id,
            Address = x.Address,
            Birthdate = x.Birthdate,
            FirstName = x.FirstName,
            LastName = x.LastName,
            PersonnelCode = x.PersonnelCode,
            PhoneNumber = x.PhoneNumber
        }).ToList();
    }

    public void Delete(int id)
    {
        var employee = _employeeRepository.GetById(id);
        if(employee == null)
        {
            throw new Exception("Employee Does Not Exist!");
        }
        _employeeRepository.Delete(employee);
    }

    public void Update(int id,CreateOrModifyEmployeeDTO dto)
    {
        var employee = _employeeRepository.GetById(id);
        employee.Update(dto.FirstName, dto.LastName, dto.PhoneNumber, dto.PhoneNumber, dto.Birthdate, dto.PersonnelCode, dto.Gender);
        _employeeRepository.Update();
    }
}
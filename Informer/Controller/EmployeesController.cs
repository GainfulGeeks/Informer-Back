using Informer.BLL.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Informer.Controller;

[ApiController]
public class EmployeesController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IEmployeeBLL _employeeBLL;

    public EmployeesController(IEmployeeBLL employeeBLL)
    {
        _employeeBLL = employeeBLL;
    }

    [Route("api/[controller]")]
    [HttpGet]
    public IActionResult Get()
    {
        var employees = _employeeBLL.GetEmployees();

        return Ok(employees);
    }
}
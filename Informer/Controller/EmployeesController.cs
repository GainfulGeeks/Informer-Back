using InformerBLL.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Informer.Controllers;

[ApiController]
public class EmployeesController : Controller
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


        employees.Select(x => new { FirstName = x.FirstName, Tel = x.PhoneNumber }).ToList();

        return Ok(employees);
    }
}
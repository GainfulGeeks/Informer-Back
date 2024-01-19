using Informer.BLL.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Informer.Controllers;

[Authorize]
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

        return Ok(employees);
    }
}
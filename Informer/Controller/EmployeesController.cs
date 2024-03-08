using Informer.BLL.Contract;
using Informer.BLL.Contract.Models;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    [Route("api/[controller]")]
    [HttpGet]
    public IActionResult Get()
    {
        var employees = _employeeBLL.GetEmployees();

        return Ok(employees);
    }

    [Authorize]
    [Route("api/[controller]")]
    [HttpPost]
    public IActionResult Post(CreateOrModifyEmployeeDTO dto)
    {
        _employeeBLL.Create(dto);

        return Ok();
    }

    [Authorize]
    [Route("api/[controller]")]
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        _employeeBLL.Delete(id);
        return Ok();
    }

    [Authorize]
    [Route("api/[controller]/{id}")]
    [HttpPut]
    public IActionResult Put(int id, CreateOrModifyEmployeeDTO dto)
    {
        _employeeBLL.Update(id,dto);
        return Ok();
    }
}
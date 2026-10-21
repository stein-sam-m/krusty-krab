using KrustyKrab.Domain.Employees;
using Microsoft.AspNetCore.Mvc;

namespace KrustyKrab.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class EmployeesController(IEmployeeRepository employees) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<IReadOnlyList<Employee>>(StatusCodes.Status200OK)]
    public async Task<IReadOnlyList<Employee>> GetAll(CancellationToken cancellationToken)
        => await employees.GetAllAsync(cancellationToken);

    [HttpGet("{id}")]
    [ProducesResponseType<Employee>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Employee>> GetById(uint id, CancellationToken cancellationToken)
    {
        var employee = await employees.GetByIdAsync(id, cancellationToken);
        return employee is null ? NotFound() : employee;
    }
}

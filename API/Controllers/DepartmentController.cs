using Application.DTOs.Departments;
using Application.Interfaces.Department;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/department")]
public class DepartmentController: ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _departmentService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var department = await _departmentService.GetByIdAsync(id);
        return department is null ? NotFound() : Ok(department);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DepartmentRequestDTO dto)
    {
        var department = await _departmentService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] DepartmentRequestDTO dto)
    {
        var updatedDepartment = await _departmentService.UpdateAsync(id, dto);
        return updatedDepartment ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deletedDepartment = await _departmentService.DeleteAsync(id);
        return deletedDepartment ? NoContent() : NotFound();
    }
}
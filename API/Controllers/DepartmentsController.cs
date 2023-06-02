using API.Models;
using API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DepartmentsController : ControllerBase
  {
    private readonly ApiDbContext _context;

    public DepartmentsController(ApiDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult GetDepartments()
    {
      var departments = _context.Departments.ToList();
      return Ok(departments);
    }

    [HttpGet("{id}")]
    public IActionResult GetDepartment(int id)
    {
      var department = _context.Departments.Find(id);
      if (department == null)
      {
        return NotFound();
      }

      return Ok(department);
    }

    [HttpPost]
    public IActionResult CreateDepartment([FromBody] Department department)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.Departments.Add(department);
      _context.SaveChanges();
      return Created("api/departments/" + department.DepartmentId, department);
    }
  }
}
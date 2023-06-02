using API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class SalariesController : ControllerBase
  {
    private readonly ApiDbContext _context;

    public SalariesController(ApiDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult GetSalaries()
    {
      var salaries = _context.Salaries.ToList();
      return Ok(salaries);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var salaryInDb = _context.Salaries.Find(id);
      if (salaryInDb == null)
      {
        return NotFound();
      }

      _context.Salaries.Remove(salaryInDb);
      _context.SaveChanges();
      return Ok();
    }
  }
}
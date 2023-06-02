using API.Models;
using API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PersonsController : ControllerBase
  {
    private readonly ApiDbContext _context;

    public PersonsController(ApiDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult GetPersons()
    {
      var persons = _context.Persons.Include(x => x.Position)
          .ThenInclude(x => x.Department)
          .Select(x => new PersonALL()
          {
            Id = x.Id,
            Name = x.Name,
            PositionName = x.Position.Name,
            Salary = x.Salary.Amount,
            DepartmentName = x.Position.Department.DepartmentName
          }).ToList();

      return Ok(persons);
    }

    [HttpGet("{id}")]
    public IActionResult GetPerson(int id)
    {
      var person = _context.Persons.Include(x => x.Position)
          .ThenInclude(x => x.Department)
          .FirstOrDefault(x => x.Id == id);

      if (person == null)
      {
        return NotFound();
      }

      return Ok(person);
    }

    [HttpPost]
    public IActionResult CreatePerson([FromBody] Person person)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.Persons.Add(person);
      _context.SaveChanges();
      return Created("api/persons/" + person.Id, person);
    }
  }
}
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

    [HttpPut("{id}")]
    public IActionResult UpdatePerson(int id, [FromBody] Person person)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var personInDb = _context.Persons.Find(id);
      if (personInDb == null)
      {
        return NotFound();
      }

      personInDb.Name = person.Name;
      personInDb.Surname = person.Surname;
      personInDb.Age = person.Age;
      personInDb.Email = person.Email;
      personInDb.Password = person.Password;
      personInDb.Address = person.Address;
      personInDb.PositionId = person.PositionId;
      personInDb.SalaryId = person.SalaryId;

      _context.SaveChanges();
      return Ok(personInDb);
    }
  }
}
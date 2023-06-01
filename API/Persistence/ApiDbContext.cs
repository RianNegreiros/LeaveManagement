using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
  public class ApiDbContext : DbContext
  {
    public DbSet<Person> Persons { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Department> Departments { get; set; }
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {
    }
  }
}
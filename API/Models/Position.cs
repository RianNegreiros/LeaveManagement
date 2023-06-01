using System.ComponentModel.DataAnnotations;

namespace API.Models
{
  public class Position
  {
    public Position()
    {
      Persons = new HashSet<Person>();
    }

    [Key]
    public int PositionId { get; set; }
    [Required]
    public string Name { get; set; }
    public virtual ICollection<Person> Persons { get; set; }
  }
}
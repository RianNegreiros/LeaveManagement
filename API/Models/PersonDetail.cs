using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
  public class PersonDetail
  {
    [Key]
    public int Id { get; set; }
    public string PersonCity { get; set; }
    public DateTime BirthDate { get; set; }

    [ForeignKey("Person")]
    public int PersonId { get; set; }
    public Person Person { get; set; }
  }
}
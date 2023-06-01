namespace API.Models
{
  public class Salary
  {
    public Salary()
    {
      Persons = new HashSet<Person>();
    }
    public int SalaryId { get; set; }
    public int Amount { get; set; }
    public virtual ICollection<Person> Persons { get; set; }
  }
}
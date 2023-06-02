using System.ComponentModel.DataAnnotations;

namespace WPF
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}

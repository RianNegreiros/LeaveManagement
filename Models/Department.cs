using System.ComponentModel.DataAnnotations;

namespace departments.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Department Name is required")]
        public string DepartmentName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Dtos
{
    public class DepartmentPostDto
    {
        [Required(ErrorMessage = "Department Name is required")]
        [MaxLength(20, ErrorMessage = "More than 20 characters not allowed")]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Special characters are not allowed")]
        public string DepartmentName { get; set; }
    }
}

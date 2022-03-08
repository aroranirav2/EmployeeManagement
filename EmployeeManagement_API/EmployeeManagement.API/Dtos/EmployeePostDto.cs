using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Dtos
{
    public class EmployeePostDto
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [StringLength(1, ErrorMessage = "length has to be 1 character")]
        [RegularExpression("M|F|O", ErrorMessage = "Gender has to M, F or O")]
        public string Gender { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}

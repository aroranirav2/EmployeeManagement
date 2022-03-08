namespace EmployeeManagement.API.Dtos
{
    public class EmployeeForDepartmentDto
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
    }
}

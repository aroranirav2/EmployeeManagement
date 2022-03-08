namespace EmployeeManagement.API.Dtos
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DepartmentForEmployeeDto Department { get; set; }
    }
}

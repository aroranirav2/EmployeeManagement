namespace EmployeeManagement.Repository.Domain
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public virtual IEnumerable<Employee> Employees { get; set; }
    }
}

using EmployeeManagement.Repository.Domain;

namespace EmployeeManagement.Repository.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<Employee> GetEmployeesByDepartmentId(Guid departmentId);
        Task AddNewEmployeeAsync(Employee employee);
        Task<Employee?> GetEmployeeByEmployeeId(Guid employeeId);
    }
}

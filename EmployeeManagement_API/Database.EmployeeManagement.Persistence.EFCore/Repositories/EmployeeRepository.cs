using EmployeeManagement.Repository.Domain;
using EmployeeManagement.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Database.EmployeeManagement.Persistence.EFCore.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeSystemDbContext _employeeSystemDbContext;
        public EmployeeRepository(EmployeeSystemDbContext employeeSystemDbContext)
        {
            _employeeSystemDbContext = employeeSystemDbContext;
        }

        public async Task AddNewEmployeeAsync(Employee employee)
        {
            await _employeeSystemDbContext.AddAsync(employee).ConfigureAwait(false);
            await _employeeSystemDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public IEnumerable<Employee> GetAllEmployees() =>
            _employeeSystemDbContext.Employee
            .Include(e => e.Department)
            .Include(e => e.Phones)
            .Include(e => e.Addresses)
            .AsNoTracking();

        public IEnumerable<Employee> GetEmployeesByDepartmentId(Guid departmentId) =>
            _employeeSystemDbContext.Employee
                .Include(e => e.Department)
                .Where(e => e.Department.DepartmentId == departmentId)
                .AsNoTracking();
    }
}

﻿using EmployeeManagement.Repository.Domain;
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
            _employeeSystemDbContext.Add(employee);
            await _employeeSystemDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public IEnumerable<Employee> GetAllEmployees() =>
            _employeeSystemDbContext.Employee
            .Include(e => e.Department)
            .Include(e => e.Phones)
            .Include(e => e.Addresses)
            .AsNoTracking();
        public IEnumerable<Employee> GetEmployeesByDepartmentId(Guid departmentId) =>
            _employeeSystemDbContext.Department
            .Where(x => x.DepartmentId == departmentId)
            .Include(x => x.Employees)
            .AsNoTracking()
            .SelectMany(x => x.Employees);

        public async Task<Employee?> GetEmployeeByEmployeeId(Guid employeeId) =>
            await _employeeSystemDbContext.Employee.Where(e => e.EmployeeId == employeeId)
            .Include(x => x.Department)
            .Include(x => x.Addresses)
            .Include(x => x.Phones)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }
}

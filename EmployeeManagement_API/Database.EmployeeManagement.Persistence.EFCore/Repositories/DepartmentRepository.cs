﻿using EmployeeManagement.Repository.Domain;
using EmployeeManagement.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Database.EmployeeManagement.Persistence.EFCore.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeSystemDbContext _employeeSystemDbContext;
        public DepartmentRepository(EmployeeSystemDbContext employeeSystemDbContext)
        {
            _employeeSystemDbContext = employeeSystemDbContext;
        }
        public IEnumerable<Department> GetAllDepartmentsWithoutEmployees() =>
            _employeeSystemDbContext.Department.AsNoTracking();
        public IEnumerable<Department> GetAllDepartmentsWithEmployees() =>
            _employeeSystemDbContext.Department.Include(x => x.Employees).AsNoTracking();

        public async Task<Department?> GetDepartmentByIdAsync(Guid departmentId) =>
             await _employeeSystemDbContext.Department.FindAsync(departmentId).ConfigureAwait(false);

        public async Task AddNewDepartmentAsync(Department department)
        {
            await _employeeSystemDbContext.Department.AddAsync(department).ConfigureAwait(false);
            await _employeeSystemDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<Guid?> GetDepartmentIdByDepartmentName(string departmentName)
        {
            var department = await _employeeSystemDbContext.Department
                .Where(x => x.DepartmentName == departmentName)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
            return department?.DepartmentId;
        }
    }
}
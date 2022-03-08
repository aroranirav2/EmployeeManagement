﻿using EmployeeManagement.Repository.Domain;

namespace EmployeeManagement.Repository.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartmentsWithoutEmployees();
        IEnumerable<Department> GetAllDepartmentsWithEmployees();
        Task<Department?> GetDepartmentByIdAsync(Guid departmentId);
        Task AddNewDepartmentAsync(Department department);
        Task<Guid?> GetDepartmentIdByDepartmentName(string departmentName);
    }
}

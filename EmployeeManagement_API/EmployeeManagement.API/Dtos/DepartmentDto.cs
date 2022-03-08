﻿namespace EmployeeManagement.API.Dtos
{
    public class DepartmentDto
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public IEnumerable<EmployeeForDepartmentDto> Employees { get; set; }
    }
}

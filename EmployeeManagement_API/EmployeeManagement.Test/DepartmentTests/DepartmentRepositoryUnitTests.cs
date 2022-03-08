using Database.EmployeeManagement.Persistence.EFCore;
using Database.EmployeeManagement.Persistence.EFCore.Repositories;
using EmployeeManagement.Repository.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using EmployeeManagement.Repository.Repositories;
using System;

namespace EmployeeManagement.Test.DepartmentTests
{
    public class DepartmentRepositoryUnitTests
    {
        private readonly DbContextOptions<EmployeeSystemDbContext> employeeDbContextOptions;
        private readonly EmployeeSystemDbContext employeeSystemDbContext;
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentRepositoryUnitTests()
        {
            employeeDbContextOptions = new DbContextOptionsBuilder<EmployeeSystemDbContext>()
                .UseInMemoryDatabase(databaseName: "EmployeeSystem")
                .Options;
            employeeSystemDbContext = new EmployeeSystemDbContext(employeeDbContextOptions);
            departmentRepository = new DepartmentRepository(employeeSystemDbContext);
        }

        [Fact]
        public async Task Get_All_Departments_Count_Is_One()
        {
            var testData = new Department
            {
                DepartmentName = "Test"
            };
            await employeeSystemDbContext.Department.AddAsync(testData);
            await employeeSystemDbContext.SaveChangesAsync();
            var result = departmentRepository.GetAllDepartmentsWithoutEmployees().ToList().Count;
            Assert.Equal(1, result);
        }
        [Fact]
        public async Task Get_Department_By_Id_Returns_Null()
        {
            var id = Guid.NewGuid();
            var department = await departmentRepository.GetDepartmentByIdAsync(id);
            Assert.Null(department);
        }
    }
}

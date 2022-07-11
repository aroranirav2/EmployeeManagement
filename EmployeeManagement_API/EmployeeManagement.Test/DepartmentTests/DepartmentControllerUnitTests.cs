using AutoMapper;
using Contracts;
using EmployeeManagement.API.AutoMapperProfiles;
using EmployeeManagement.API.Controllers;
using EmployeeManagement.API.Dtos;
using EmployeeManagement.Repository.Domain;
using EmployeeManagement.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagement.Test.DepartmentTests
{
    public class DepartmentControllerUnitTests
    {
        private readonly Mock<IDepartmentRepository> mockDepartmentRepo;
        private readonly Mock<ILoggerManager> mockLogger;
        private readonly DepartmentController departmentController;
        private readonly MappingProfiles mappingProfiles;
        private readonly MapperConfiguration mapperConfiguration;
        private readonly IMapper mapper;
        public DepartmentControllerUnitTests()
        {
            mockDepartmentRepo = new Mock<IDepartmentRepository>();
            mockLogger = new Mock<ILoggerManager>();
            mappingProfiles = new MappingProfiles();
            mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfiles));
            mapper = new Mapper(mapperConfiguration);
            departmentController = new DepartmentController(mockDepartmentRepo.Object, mapper, mockLogger.Object);
        }
        [Fact]
        public async Task Get_All_Departments_Without_Employees_Returns_Correct_Values()
        {
            mockDepartmentRepo.Setup(repo => repo.GetAllDepartmentsWithoutEmployees())
                .Returns(TestDepartments);

            var actionResult = await departmentController.GetAllDepartmentsWithoutEmployees().ConfigureAwait(false);
            var okObjectResult = actionResult.Result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            Assert.Equal(StatusCodes.Status200OK, okObjectResult?.StatusCode);
            var model = okObjectResult?.Value as List<DepartmentDto>;
            Assert.NotNull(model);
            Assert.Equal(2, model?.Count);
        }
        [Fact]
        public async Task Get_All_Departments_Without_Employees_Returns_Not_Found_Result()
        {
            mockDepartmentRepo.Setup(repo => repo.GetAllDepartmentsWithoutEmployees())
                .Returns(new List<Department>());

            var result = await departmentController.GetAllDepartmentsWithoutEmployees().ConfigureAwait(false);
            Assert.IsType<NotFoundResult>(result.Result);
            Assert.Null(result.Value);
        }
        [Fact]
        public async Task Get_All_Departments_With_Employees_Returns_Not_Found()
        {
            mockDepartmentRepo.Setup(repo => repo.GetAllDepartmentsWithEmployees())
                .Returns(new List<Department>());

            var result = await departmentController.GetAllDepartmentsWithEmployees().ConfigureAwait(false);
            Assert.IsType<NotFoundResult>(result.Result);
            Assert.Null(result.Value);
        }
        [Fact]
        public async Task Get_All_Departments_With_Employees_Returns_Correct_Values()
        {
            mockDepartmentRepo.Setup(repo => repo.GetAllDepartmentsWithEmployees())
                .Returns(TestDepartments);

            var actionResult = await departmentController.GetAllDepartmentsWithEmployees().ConfigureAwait(false);
            var okObjectResult = actionResult.Result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            Assert.Equal(StatusCodes.Status200OK, okObjectResult?.StatusCode);
            var models = okObjectResult?.Value as List<DepartmentDto>;
            foreach(var model in models)
                Assert.NotNull(model.Employees);
            Assert.NotNull(models);
            Assert.Equal(2, models?.Count);
        }

        [Fact]
        public async Task Get_Department_By_Id_Returns_Ok()
        {
            var testGuid = new Guid("c5eb3de9-4631-4814-b12c-e755cb7e8ef1");
            mockDepartmentRepo.Setup(repo => repo.GetDepartmentByIdAsync(testGuid).Result)
             .Returns(TestDepartments.FirstOrDefault(x => x.DepartmentId == testGuid));

            var actionResult = await departmentController.GetDepartmentById(testGuid).ConfigureAwait(false);

            Assert.IsType<OkObjectResult>(actionResult.Result);

            var okObjectResult = actionResult.Result as OkObjectResult;

            var department = okObjectResult?.Value as DepartmentDto;
            Assert.NotNull(department);
            Assert.Equal("Test", department?.DepartmentName);
        }

        [Fact]
        public async Task Get_Department_By_Id_Returns_Not_Found()
        {
            var testGuid = new Guid("c5eb3de9-4631-4814-b12c-e755cb7e8ef1");
            mockDepartmentRepo.Setup(repo => repo.GetDepartmentByIdAsync(testGuid).Result)
             .Returns(TestDepartments.FirstOrDefault(x => x.DepartmentId == testGuid));

            var actionResult = await departmentController.GetDepartmentById(new Guid("9022fd49-5669-469e-8464-95b10a00bb1d")).ConfigureAwait(false);

            Assert.IsType<NotFoundResult>(actionResult.Result);

            Assert.Null(actionResult?.Value);
        }
        private List<Department> TestDepartments =>
            new List<Department>
            {
                new Department
                {
                    DepartmentId = new Guid("c5eb3de9-4631-4814-b12c-e755cb7e8ef1"),
                    DepartmentName = "Test",
                    Employees = new List<Employee>
                    {
                        new Employee
                        {
                            EmployeeId = new Guid("9022fd49-5669-469e-8464-95b10a00bb1d"),
                            FirstName = "First",
                            LastName = "Last",
                        }
                    }
                },
                new Department
                {
                    DepartmentId = new Guid("a7c51910-3491-4ea9-a750-f6c7ecde75fa"),
                    DepartmentName = "Test 1",
                    Employees = new List<Employee>
                    {
                        new Employee
                        {
                            EmployeeId = new Guid("ab31de1c-d5c1-4ad6-be1f-55e8f303fd7d"),
                            FirstName = "First 1",
                            LastName = "Last 1",
                        }
                    }
                }
            };
    }
}

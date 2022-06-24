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
                .Returns(GetTestAllDepartments());

            var actionResult = await departmentController.GetAllDepartmentsWithoutEmployees();
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

            var result = await departmentController.GetAllDepartmentsWithoutEmployees();
            Assert.IsType<NotFoundResult>(result.Result);
            Assert.Null(result.Value);
        }
        [Fact]
        public async Task Get_All_Departments_With_Employees_Returns_Not_Found()
        {
            mockDepartmentRepo.Setup(repo => repo.GetAllDepartmentsWithEmployees())
                .Returns(new List<Department>());

            var result = await departmentController.GetAllDepartmentsWithEmployees();
            Assert.IsType<NotFoundResult>(result.Result);
            Assert.Null(result.Value);
        }
        [Fact]
        public async Task Get_All_Departments_With_Employees_Returns_Correct_Values()
        {
            mockDepartmentRepo.Setup(repo => repo.GetAllDepartmentsWithEmployees())
                .Returns(GetTestAllDepartments());

            var actionResult = await departmentController.GetAllDepartmentsWithEmployees();
            var okObjectResult = actionResult.Result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            Assert.Equal(StatusCodes.Status200OK, okObjectResult?.StatusCode);
            var models = okObjectResult?.Value as List<DepartmentDto>;
            foreach(var model in models)
                Assert.NotNull(model.Employees);
            Assert.NotNull(models);
            Assert.Equal(2, models?.Count);
        }

        private List<Department> GetTestAllDepartments() =>
            new List<Department>
            {
                new Department
                {
                    DepartmentId = Guid.NewGuid(),
                    DepartmentName = "Test",
                    Employees = new List<Employee>
                    {
                        new Employee
                        {
                            EmployeeId = Guid.NewGuid(),
                            FirstName = "First",
                            LastName = "Last",
                        }
                    }
                },
                new Department
                {
                    DepartmentId = Guid.NewGuid(),
                    DepartmentName = "Test 1",
                    Employees = new List<Employee>
                    {
                        new Employee
                        {
                            EmployeeId = Guid.NewGuid(),
                            FirstName = "First 1",
                            LastName = "Last 1",
                        }
                    }
                }
            };
    }
}

using AutoMapper;
using EmployeeManagement.API.Dtos;
using EmployeeManagement.Repository.Domain;

namespace EmployeeManagement.API.AutoMapperProfiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            #region Department
            CreateMap<Department, DepartmentDto>();
            CreateMap<Department, DepartmentForEmployeeDto>();
            CreateMap<DepartmentPostDto, Department>();
            #endregion
            #region Employee
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, EmployeeForDepartmentDto>();
            CreateMap<EmployeePostDto, Employee>();
            #endregion
        }
    }
}

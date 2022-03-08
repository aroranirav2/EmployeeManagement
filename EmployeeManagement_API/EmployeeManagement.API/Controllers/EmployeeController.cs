using AutoMapper;
using Contracts;
using EmployeeManagement.API.Dtos;
using EmployeeManagement.Repository.Domain;
using EmployeeManagement.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository, IMapper mapper, ILoggerManager loggerManager)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;

        }
        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            if(!employees.Any())
            {
                await _loggerManager.LogWarnAsync($"No employees found");
                return NotFound();
            }
            var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }
        [HttpGet("{departmentId:guid}")]
        public async Task<ActionResult<List<EmployeeDto>>> GetEmployeesByDepartmentId(Guid departmentId)
        {
            var employees = _employeeRepository.GetEmployeesByDepartmentId(departmentId);
            if(!employees.Any())
            {
                await _loggerManager.LogWarnAsync($"No employees found for deparment id {departmentId}");
                return NotFound();
            }
            var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] EmployeePostDto employeeDto)
        {
            if (employeeDto == null)
                return BadRequest("Employee is null");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var departmentId = await _departmentRepository.GetDepartmentIdByDepartmentName(employeeDto.DepartmentName);
            if (departmentId == null)
                return BadRequest("Invalid department name");
            var employee = _mapper.Map<Employee>(employeeDto);
            employee.DepartmentId = departmentId ?? throw new Exception("deparment id is null");
            await _employeeRepository.AddNewEmployeeAsync(employee);
            return Ok();
        }
    }
}

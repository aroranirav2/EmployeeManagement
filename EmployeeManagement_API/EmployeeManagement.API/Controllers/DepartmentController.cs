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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        public DepartmentController(IDepartmentRepository departmentRepository, IMapper mapper, ILoggerManager loggerManager)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;
        }
        [HttpGet]
        public async Task<ActionResult<List<DepartmentDto>>> GetAllDepartmentsWithoutEmployees()
        {
            var departments = _departmentRepository.GetAllDepartmentsWithoutEmployees();
            if (!departments.Any())
            {
                await _loggerManager.LogWarnAsync($"No departments found for all the departments without employees");
                return NotFound();
            }
            var departmentDtos = _mapper.Map<List<DepartmentDto>>(departments);
            return Ok(departmentDtos);
        }
        [HttpGet]
        public async Task<ActionResult<List<DepartmentDto>>> GetAllDepartmentsWithEmployees()
        {
            var departments = _departmentRepository.GetAllDepartmentsWithEmployees();
            if (!departments.Any())
            {
                await _loggerManager.LogWarnAsync($"No departments found for all the departments with employees");
                return NotFound();
            }
            var departmentDtos = _mapper.Map<List<DepartmentDto>>(departments);
            return Ok(departmentDtos);
        }
        [HttpGet("{id:guid}", Name = "departmentId")]
        public async Task<ActionResult<DepartmentDto>> GetDepartmentById(Guid id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                await _loggerManager.LogWarnAsync($"No department found with department id = {id}");
                return NotFound();
            }
            var departmentDto = _mapper.Map<DepartmentDto>(department);
            return Ok(departmentDto);
        }
        [HttpGet("{name}", Name = "departmentName")]
        public async Task<ActionResult<DepartmentDto>> GetDepartmentByName(string name)
        {
            var department = await _departmentRepository.GetDepartmentByNameAsync(name);
            var departmentDto = _mapper.Map<DepartmentDto>(department);
            return Ok(departmentDto);
        }
        [HttpPost]
        public async Task<IActionResult> PostDepartment([FromBody] DepartmentPostDto departmentPostDto)
        {
            if (departmentPostDto == null)
                return BadRequest("department is null");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var department = _mapper.Map<Department>(departmentPostDto);
            await _departmentRepository.AddNewDepartmentAsync(department);
            return CreatedAtAction(nameof(GetDepartmentByName), new { name = departmentPostDto.DepartmentName }, department);
        }

    }
}

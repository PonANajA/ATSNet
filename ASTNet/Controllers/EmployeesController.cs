using Microsoft.AspNetCore.Mvc;
using ASTNet.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ASTNet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _employeeService.GetEmployees();
            return Ok(result);
        }
    }
}

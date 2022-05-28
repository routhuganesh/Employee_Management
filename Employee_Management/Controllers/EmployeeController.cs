using Employee_Management.Models;
using Employee_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService<Employee> employeeService;

        public EmployeeController(IEmployeeService<Employee> employeeService )
        {
            this.employeeService = employeeService;
        }
        [HttpGet]
        public ActionResult<Employee> Get(int id)
        {
            var result =  employeeService.Get(id);
            if (result == null)
            {
                return NotFound("Employee record did not found");
            }
            return Ok(result);
        }
        
        [HttpPost("CreateEmployee")]
        public ActionResult<Employee> CreateEmployee(CreateEmployeeDto request)
        {
            if(request==null)
            {
                return BadRequest("Employee is null");

            }
            employeeService.Create(request);
            //return GetCount(request.DepartmentId);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetCount(int id)
        {
            var result = employeeService.GetCount(id);

            return Ok(result);
        }

    }
}

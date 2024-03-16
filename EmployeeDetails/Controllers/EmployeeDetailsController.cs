using EmployeeDetails.Employees;
using EmployeeDetails.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeDetails.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeDetailsController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost]
        public async Task<IActionResult> PostEmployee(CreateEmployeeModel employeeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdEmployee = await _employeeService.CreateEmployee(employeeModel);

                return Ok(createdEmployee); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
        }
       

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
          {

            try
            {
                var employeeDetailsList = await _employeeService.GetEmployees();

                return Ok(employeeDetailsList); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var employeeDetails = await _employeeService.GetEmployee(id);

                if (employeeDetails == null)
                {
                    return NotFound(); 
                }

                return Ok(employeeDetails); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
        }

        [HttpPost("employees/{empId}/salarypaid")]
        public async Task<IActionResult> SavePaidSalary(int empId,SalaryPaidModel salaryPaidModel)
        {
            try
            {
                var newSalaryPaid = await _employeeService.SavePaidSalary(empId,salaryPaidModel);

                return Ok(newSalaryPaid); 
            }
            
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while saving the salary paid record: {ex.Message}");
            }
        }
    }
}

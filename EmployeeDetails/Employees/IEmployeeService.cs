using EmployeeDetails.ViewModel;
using EmployeeDetails.Models;


namespace EmployeeDetails.Employees
{
     public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDetailsModel>> GetEmployees();
        Task<EmployeeDetailsModel> GetEmployee(int id);
        Task<SalaryPaid> SavePaidSalary(int empId, SalaryPaidModel salaryPaidModel);
        Task<Employee> CreateEmployee(CreateEmployeeModel employeeModel);

    }
}

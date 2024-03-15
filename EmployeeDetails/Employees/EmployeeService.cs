using EmployeeDetails.Models.Data;
using EmployeeDetails.ViewModel;
using Microsoft.EntityFrameworkCore;
using EmployeeDetails.Models;

namespace EmployeeDetails.Employees
{

    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDb _dbContext;

        public EmployeeService(ApplicationDb dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<EmployeeDetailsModel>> GetEmployees()
        {
            var employee = await _dbContext.Employee
                .Include(e => e.AnnualSalary)
                .Include(e => e.SalariesPaid)
                .ToListAsync();

            var employeeDetailsList = employee.Select(e => new EmployeeDetailsModel
            {
                FirstName = e.FirstName,
                SurName = e.SurName,
                DateOfBirth = e.DOB,
                Gender = e.Gender,
                Address = e.Address,
                JoiningDate = e.StartDate,
                AnnualSalaryAmount = e.AnnualSalary.AnnualSalaryAmount,
                SalariesPaid = e.SalariesPaid

            });

            return employeeDetailsList;
        }




        public async Task<EmployeeDetailsModel> GetEmployee(int id)
        {
            var employee = await _dbContext.Employee
            .Include(x => x.AnnualSalary)
            .Include(x => x.SalariesPaid)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
            if (employee == null)
            {
                return null;
            }
                var employeeDetails = new EmployeeDetailsModel
                {

                    FirstName = employee.FirstName,
                    SurName = employee.SurName,
                    DateOfBirth = employee.DOB,
                    Gender = employee.Gender,
                    Address = employee.Address,
                    JoiningDate = employee.StartDate,
                    AnnualSalaryAmount = employee.AnnualSalary.AnnualSalaryAmount,
                    SalariesPaid = employee.SalariesPaid

                };
                return employeeDetails;
            }

            public async Task<Employee> CreateEmployee(CreateEmployeeModel employeeModel)
            {
                var newEmployee = new Employee
                {
                    FirstName = employeeModel.FirstName,
                    SurName = employeeModel.SurName,
                    DOB = employeeModel.DateOfBirth,
                    Gender = employeeModel.Gender,
                    Address = employeeModel.Address,
                    StartDate = employeeModel.StartDate,
                    
        };
                _dbContext.Employee.Add(newEmployee);
                var annualSalary = new AnnualSalary
                {
                    AnnualSalaryAmount = employeeModel.AnnualSalaryAmount,
                    Employee = newEmployee,
                    

                };
                _dbContext.AnnualSalary.Add(annualSalary);

            newEmployee.AnnualSalary =annualSalary;

            await _dbContext.SaveChangesAsync();


                return newEmployee;
            }


        public async Task<SalaryPaid> SavePaidSalary(int empId, SalaryPaidModel salaryPaidModel)
        {
            
            var emp = await _dbContext.Employee.FindAsync(empId);

           
            if (emp == null)
            {
                return null;
            }

            var lastMonthSalary = salaryPaidModel.IncludeLastMonthSalary ? salaryPaidModel.LastMonthSalary : 0.0m;


            var newSalary = new SalaryPaid
            {
                Month = salaryPaidModel.Month,
                PaidDays = salaryPaidModel.PaidDays,
                Amount = salaryPaidModel.Amount,
                IncludeLastMonthSalary = salaryPaidModel.IncludeLastMonthSalary,
                LastMonthSalary = lastMonthSalary,
                EmployeeId = emp.Id 
            };

           
            _dbContext.SalaryPaid.Add(newSalary);
            await _dbContext.SaveChangesAsync();

            return newSalary;
        }

    }
}
    


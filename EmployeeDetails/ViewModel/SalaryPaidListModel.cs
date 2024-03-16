using EmployeeDetails.Models;

namespace EmployeeDetails.ViewModel
{
    public class SalaryPaidListModel
    {
          public int EmployeeId { get; set; }
            public Month Month { get; set; }

            public bool IncludeLastMonthSalary { get; set; }
        
            public decimal LastMonthSalary { get; set; }
          
            public int PaidDays { get; set; }
          
            public decimal Amount { get; set; }


      
    }
}

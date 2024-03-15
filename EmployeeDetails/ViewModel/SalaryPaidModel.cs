using EmployeeDetails.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDetails.ViewModel
{
    public class SalaryPaidModel
    {
        [Required]
        public Month Month { get; set; }

        [Required]
        public bool IncludeLastMonthSalary { get; set; }
        [Required]
        public decimal LastMonthSalary { get; set; }
        [Required]
        public int PaidDays { get; set; }
        [Required]
        public decimal Amount { get; set; }


    }
}

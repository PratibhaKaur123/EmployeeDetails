using EmployeeDetails.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDetails.ViewModel
{
    public class EmployeeDetailsModel
    {
        public int Id { get;set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }
        public Gender Gender { get; set; }
        public decimal ? AnnualSalaryAmount { get; set; }

        public List<SalaryPaid> ? SalariesPaid
        {
            get; set;
        }
    }
}


using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeDetailsApp.Models
{
    public class SalaryPaidViewModel
    {
        [Key]
        public int Id { get; set; }
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

        [Required]
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public EmployeeViewModel Employee { get; set; }
    }
    public enum Month
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
}

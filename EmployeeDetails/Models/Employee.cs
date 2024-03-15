using System.ComponentModel.DataAnnotations;

namespace EmployeeDetails.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public  string FirstName { get; set; }
        [Required]
        public string SurName { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Address { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public AnnualSalary ? AnnualSalary { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public List<SalaryPaid> ? SalariesPaid { get; set; }

    }
    public enum Gender
    {
        Male,
        Female,
        Other
     

    }
}

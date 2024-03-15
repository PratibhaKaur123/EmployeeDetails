
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDetailsApp.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Sur Name")]
        public string SurName { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Date Of Birth")]
        public DateTime DOB { get; set; }
        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Joining Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayName("Annual Salary")]
        public AnnualSalaryViewModel? AnnualSalary { get; set; }
        [Required]
        [DisplayName("Gender")]
        public Gender Gender { get; set; }
        [DisplayName("Salary Paid")]
        public List<SalaryPaidViewModel>? SalariesPaid { get; set; }

    }
    public enum Gender
    {
        Male,
        Female,
        Other


    }
}


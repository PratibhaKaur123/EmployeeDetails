using EmployeeDetails.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeDetailsApp.Models
{
    public class AnnualSalaryViewModel
    {
         [Key]
            public int Id { get; set; }
            [Required]
            public decimal AnnualSalaryAmount { get; set; }
            [Required]
            public int EmployeeId { get; set; }
            [JsonIgnore]
            public Employee Employee { get; set; }


       
    }
}

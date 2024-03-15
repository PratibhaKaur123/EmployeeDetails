using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeDetails.Models
{
    public class AnnualSalary
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

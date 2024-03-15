using EmployeeDetails.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDetails.ViewModel
{
    public class CreateEmployeeModel
    {
       
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string SurName { get; set; }
            [DataType(DataType.Date)]
            [Required]
            public DateTime DateOfBirth { get; set; }
            [Required]
            public string Address { get; set; }
            [DataType(DataType.Date)]
            [Required]
            public DateTime StartDate { get; set; }
            [Required]
            public Gender Gender { get; set; }
            [Required]
            public decimal AnnualSalaryAmount { get; set; }
        }
     }


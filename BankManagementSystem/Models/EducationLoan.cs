using BankManagementSystem.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Models
{
    public class EducationLoan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Loan Amount")]
        public double LoanAmount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Applied Date")]
        public DateTime AppliedDate { get; set; }

        [Required]
        [Range(0, 100)]
        [Display(Name = "Rate of Interest")]
        public double RateOfInterest { get; set; }

        [Required]
        [Display(Name = "Loan Duration")]
        public LoanDuration LoanDuration { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0, int.MaxValue, ErrorMessage = "Course fee must be greater than zero")]
        [Display(Name = "Course Fee")]
        public double CourseFee { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Name must contain only alphabets")]
        [Display(Name = "Father's Name")]
        public string FatherName { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Salary must be greater than zero")]
        [DataType(DataType.Currency)]
        [Display(Name = "Father's Salary")]
        public double FatherSalary { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Father's Occupation")]
        public string FatherOccupation { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Father's Company")]
        public string FatherCompany { get; set; }
    }
}

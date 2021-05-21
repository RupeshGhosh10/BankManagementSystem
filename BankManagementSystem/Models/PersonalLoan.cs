using BankManagementSystem.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Models
{
    public class PersonalLoan
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
        [Range(0, int.MaxValue, ErrorMessage = "Annual income must be greater than zero")]
        [DataType(DataType.Currency)]
        [Display(Name = "Annual Income")]
        public double AnnualIncome { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Designation { get; set; }

        [Required]
        [Range(0, 50, ErrorMessage = "Experince must be grater than zero")]
        [Display(Name = "Total Experience")]
        public int TotalExperience  { get; set; }

        [Required]
        [Range(0, 50, ErrorMessage = "Experince must be grater than zero")]
        [Display(Name = "Experience in Current Company")]
        public int TotalExperienceWithCurrentCompany { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}

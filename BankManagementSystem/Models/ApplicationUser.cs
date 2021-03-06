using BankManagementSystem.Models.CustomValidationAttribute;
using BankManagementSystem.Models.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Name must contain only alphabets")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        [Required]
        public State State { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Martial Status")]
        public MartialStatus MartialStatus { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [MinimumAge(18)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [Display(Name = "Citizen Type")]
        public CitizenStatus CitizenStatus { get; set; }

        [ForeignKey("BankAccount")]
        [Display(Name = "Account Number")]
        public int? BankAccountId { get; set; }

        public BankAccount BankAccount { get; set; }
    }
}

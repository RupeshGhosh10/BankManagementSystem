using BankManagementSystem.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Name must contain only alphabets")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^[6789]\d{9}$", ErrorMessage = "Please enter valid phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

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
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [Display(Name = "Account Type")]
        public BankAccountType BankAccountType { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Deposit { get; set; }

        [Required]
        [Display(Name = "Identification Proof Type")]
        public IdentificationProofType IdentificationProofType { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Identification Document Number")]
        public string IdentificationDocumentNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your password and confirm password do not match")]
        public string ConfirmPassword { get; set; }
    }
}

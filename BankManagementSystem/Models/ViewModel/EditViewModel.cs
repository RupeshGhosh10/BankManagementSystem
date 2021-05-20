using BankManagementSystem.Models.CustomValidationAttribute;
using BankManagementSystem.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Models.ViewModel
{
    public class EditViewModel
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
        [MinimumAge(18, ErrorMessage = "You must be 18 year or older to register")]
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

        [MaxLength(100)]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Name must contain only alphabets")]
        [Display(Name = "Nominee Name")]
        public string NomineeName { get; set; }

        [RegularExpression(@"^R-\d{3}$", ErrorMessage = "Enter valid account number in form R-XXX")]
        [Display(Name = "Nominee Account Number")]
        public string NomineeAccountNumber { get; set; }
    }
}

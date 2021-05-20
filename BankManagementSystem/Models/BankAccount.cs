using BankManagementSystem.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Models
{
    public class BankAccount
    {
        [Key]
        public int Id { get; set; }

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

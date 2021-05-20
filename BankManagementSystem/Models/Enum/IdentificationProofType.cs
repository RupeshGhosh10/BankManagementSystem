using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Models.Enum
{
    public enum IdentificationProofType
    {
        [Display(Name = "Adhar Card")]
        AdharCard,
        [Display(Name = "PAN Card")]
        PANCard,
        Passport,
        [Display(Name = "Voter Card")]
        VoterCard,
        [Display(Name = "Ration Card")]
        RationCard,
        Other
    }
}

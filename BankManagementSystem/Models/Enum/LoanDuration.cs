using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Models.Enum
{
    public enum LoanDuration
    {
        [Display(Name = "5 Year")]
        Five = 5,
        [Display(Name = "10 Year")]
        Ten = 10,
        [Display(Name = "15 Year")]
        Fifteen = 15,
        [Display(Name = "20 Year")]
        Twenty = 20
    }
}

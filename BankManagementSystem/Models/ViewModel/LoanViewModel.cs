using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Models.ViewModel
{
    public class LoanViewModel
    {
        public IEnumerable<PersonalLoan> PersonalLoans { get; set; }
        public IEnumerable<EducationLoan> EducationLoans { get; set; }
    }
}

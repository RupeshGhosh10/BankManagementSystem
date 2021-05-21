using BankManagementSystem.Data;
using BankManagementSystem.Models;
using BankManagementSystem.Models.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Controllers
{
    [Authorize]
    public class LoanController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public LoanController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PersonalLoan()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PersonalLoan([FromForm] PersonalLoan loan)
        {
            var user = await _userManager.GetUserAsync(User);

            loan.ApplicationUserId = user.Id;
            loan.AppliedDate = DateTime.Today;

            if (user.CitizenStatus == CitizenStatus.Normal) loan.RateOfInterest = 8;
            else loan.RateOfInterest = 5;

            if (ModelState.IsValid)
            {
                await _context.PersonalLoans.AddAsync(loan);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(loan);
        }
    }
}

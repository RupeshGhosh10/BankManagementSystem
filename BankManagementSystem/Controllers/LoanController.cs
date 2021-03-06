using BankManagementSystem.Data;
using BankManagementSystem.Models;
using BankManagementSystem.Models.Enum;
using BankManagementSystem.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var loanViewModel = new LoanViewModel
            {
                PersonalLoans = await _context.PersonalLoans.Where(m => m.ApplicationUserId == user.Id).ToListAsync(),
                EducationLoans = await _context.EducationLoans.Where(m => m.ApplicationUserId == user.Id).ToListAsync()
            };

            return View(loanViewModel);
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

        public IActionResult EducationLoan()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EducationLoan([FromForm] EducationLoan loan)
        {
            var user = await _userManager.GetUserAsync(User);

            loan.ApplicationUserId = user.Id;
            loan.AppliedDate = DateTime.Today;

            if (user.CitizenStatus == CitizenStatus.Normal) loan.RateOfInterest = 2;
            else loan.RateOfInterest = 4;

            if (ModelState.IsValid)
            {
                await _context.EducationLoans.AddAsync(loan);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(loan);
        }
    }
}

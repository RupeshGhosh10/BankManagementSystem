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
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;

            return age;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var bankAccount = new BankAccount
                {
                    BankAccountType = model.BankAccountType,
                    Deposit = model.Deposit,
                    IdentificationProofType = model.IdentificationProofType,
                    IdentificationDocumentNumber = model.IdentificationDocumentNumber,
                    NomineeName = model.NomineeName,
                    NomineeAccountNumber = model.NomineeAccountNumber
                };

                _context.BankAccounts.Add(bankAccount);
                _context.SaveChanges();

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Address = model.Address,
                    State = model.State,
                    Gender = model.Gender,
                    MartialStatus = model.MartialStatus,
                    DateOfBirth = model.DateOfBirth,
                    RegistrationDate = DateTime.Today,
                    BankAccountId = bankAccount.Id
                };

                var age = CalculateAge(user.DateOfBirth);
                if (age < 18) user.CitizenStatus = CitizenStatus.Minor;
                else if (age < 60) user.CitizenStatus = CitizenStatus.Normal;
                else user.CitizenStatus = CitizenStatus.Senior;

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Detail()
        {
            var user = await _userManager.GetUserAsync(User);
            var userView = await _userManager.Users.Include(m => m.BankAccount).SingleAsync(m => m.Id == user.Id);

            return View(userView);
        }

        [Authorize]
        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(User);
            var bankAccountInDb = await _context.BankAccounts.FirstOrDefaultAsync(m => m.Id == user.BankAccountId);

            var editViewModel = new EditViewModel
            {
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                State = user.State,
                Gender = user.Gender,
                MartialStatus = user.MartialStatus,
                DateOfBirth = user.DateOfBirth,
                BankAccountType = bankAccountInDb.BankAccountType,
                Deposit = bankAccountInDb.Deposit,
                IdentificationProofType = bankAccountInDb.IdentificationProofType,
                IdentificationDocumentNumber = bankAccountInDb.IdentificationDocumentNumber,
                NomineeName = bankAccountInDb.NomineeName,
                NomineeAccountNumber = bankAccountInDb.NomineeAccountNumber
            };

            return View(editViewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] EditViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            var bankAccountInDb = await _context.BankAccounts.FirstOrDefaultAsync(m => m.Id == user.BankAccountId);

            bankAccountInDb.BankAccountType = model.BankAccountType;
            bankAccountInDb.Deposit = model.Deposit;
            bankAccountInDb.IdentificationProofType = model.IdentificationProofType;
            bankAccountInDb.IdentificationDocumentNumber = model.IdentificationDocumentNumber;
            bankAccountInDb.NomineeName = model.NomineeName;
            bankAccountInDb.NomineeAccountNumber = model.NomineeAccountNumber;

            user.FullName = model.FullName;
            user.PhoneNumber = model.PhoneNumber;
            user.Address = model.Address;
            user.State = model.State;
            user.Gender = model.Gender;
            user.MartialStatus = model.MartialStatus;
            user.DateOfBirth = model.DateOfBirth;

            await _userManager.UpdateAsync(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}

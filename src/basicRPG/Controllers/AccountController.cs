using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using basicRPG.Models;
using basicRPG.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace basicRPG.Controllers
{
    public class AccountController : Controller
    {
        private readonly BasicRPGDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, BasicRPGDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        public IActionResult Index()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var players = _db.Players.Where(p => p.UserId == userId).Select(p => new { p.Name }).ToList();
            string name = "";
            if (players.Count > 0)
            {
              name = players[0].Name.ToString();
            }
            ViewBag.name = name;
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            ApplicationUser user = new ApplicationUser { UserName = model.Email, Email = model.Email };

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return await RegisterLogin(user, model.Password);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> RegisterLogin(ApplicationUser user, string password)
        {

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user.Email, password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {

                return RedirectToAction("Create", "Players", new { id = user.UserName });
            }
            else
            {
                return RedirectToAction("Register");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Player userPlayer = _db.Players.FirstOrDefault(p => p.UserId == userId);
                return RedirectToAction("Details","Locations");
            }
            else
            {
                return RedirectToAction("Register");
            }
        }
        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using basicRPG.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace basicRPG.Controllers
{
    public class PlayersController : Controller
    {
        private BasicRPGDbContext db = new BasicRPGDbContext();
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public PlayersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // GET: /<controller>/
        public IActionResult Create(string id)
        {
            Debug.WriteLine(id);

            ApplicationUser user = db.Users.FirstOrDefault(u=>u.UserName == id);
            ViewBag.UserId = user.Id;
            Debug.WriteLine(user.Id);
            return View();
        }
        [HttpPost]
        public IActionResult Create(Player player, string userId)
        {
            Player newPlayer = new Player(player.Name);
            newPlayer.UserId = userId;
            db.Add(newPlayer);
            db.SaveChanges();
            return RedirectToAction("Details", "Locations");
        }
        public IActionResult Edit()
        {
            return View(db.Players.ToList());
        }

    }
}
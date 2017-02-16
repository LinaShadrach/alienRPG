using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using basicRPG.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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
        public IActionResult Create(string name)
        {
            //ApplicationUser user = db.Users.FirstOrDefault(u=>u.UserName ==name);
            string id = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewBag.UserId = id;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Player player, string userId)
        {
            Player newPlayer = new Player(player.Name);
            //newPlayer.UserId = userId;
            //player.LocationId = 1;
            db.Add(newPlayer);
            db.SaveChanges();
            return RedirectToAction("Index", "Account");
        }
        public IActionResult Edit()
        {
            return View(db.Players.ToList());
        }

    }
}
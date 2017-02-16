using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using basicRPG.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace basicRPG.Controllers
{
    [Authorize]
    public class LocationsController : Controller
    {
        private BasicRPGDbContext db = new BasicRPGDbContext();
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LocationsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Player player = db.Players.Include(p => p.Location)
                .FirstOrDefault(p => p.UserId == userId);
            ViewBag.player = player;
            List<PlayerInventory> inventory = db.PlayerInventory.Include(pi => pi.Item)
                .Where(pi => pi.PlayerId == player.Id).ToList();
            foreach(PlayerInventory invetoryEntry in inventory)
            {
                ViewBag.items.Add(invetoryEntry.Item);
            }
            return View(player.Location);
        }

        [HttpPost]
        public IActionResult Details(int locationId)
        {
            locationId++;

            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Player player = db.Players.Include(p => p.Location)
                .FirstOrDefault(p => p.UserId == userId);
            player.LocationId = locationId;

            db.Entry(player).State = EntityState.Modified;
            var locationCount = db.Locations.ToList().Count;
            if(player.LocationId <= locationCount)
            {

                db.SaveChanges();
                ViewBag.player = player;
                List<PlayerInventory> inventory = db.PlayerInventory.Include(pi => pi.Item)
                    .Where(pi => pi.PlayerId == player.Id).ToList();
                foreach (PlayerInventory invetoryEntry in inventory)
                {
                    ViewBag.items.Add(invetoryEntry.Item);
                }
                return View(player.Location);
            }
            else
            {
                player.LocationId = 1;
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Account");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using basicRPG.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace basicRPG.Controllers
{
    public class RolesController : Controller
    {
        private BasicRPGDbContext db = new BasicRPGDbContext();
        public IActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IdentityRole role)
        {
            Debug.WriteLine(role.Name);
            role.NormalizedName = role.Name.ToUpper();
            try
            {
                db.Roles.Add(role);
                db.SaveChanges();
                ViewBag.ResultMessage = "Role Created Successfully!";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(string roleName)
        {
            var thisRole = db.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            return View(thisRole);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(IdentityRole role)
        {
                role.NormalizedName = role.Name.ToUpper();
            try
            {
                db.Entry(role).State = EntityState.Modified;
                Debug.WriteLine("try"+role.Name);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                Debug.WriteLine("***************************************"+role.Name);
                return View();
            }
        }

        public IActionResult Delete(string RoleName)
        {
            IdentityRole thisRole = db.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            db.Roles.Remove(thisRole);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

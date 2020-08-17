using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LastOne.Models;
using LastOne.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace LastOne.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly UserDbContext db;

        public HomeController(ILogger<HomeController> logger, UserDbContext db)
        {
            this.db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var allRoles = db.roles.ToList();
            return View(allRoles);
        }
        public IActionResult addRole(Role role)
        {
            db.roles.Add(role);
            db.SaveChanges();
            var allRoles = db.roles.ToList();
            return RedirectToAction("Index","Home",allRoles);
        }

        public IActionResult createUser() 
        {
            ViewData["roles"] = db.roles.ToList();
            return View();
        }
        public IActionResult addUserSubmit(User user, string[] phoneNumber) 
        {
            db.users.Add(user);
            db.SaveChanges();
            foreach (var item in phoneNumber)
            {
                var newPhone = new Number();
                newPhone.phoneNumber = item;
                newPhone.UserId = user.Id;
                db.numbers.Add(newPhone);
            }
            db.SaveChanges();

            return RedirectToAction("userList","Home");
        }
        public IActionResult userList() 
        {
            var allUser = db.users.ToList();
            var numberToUser = db.numbers.Include(w => w.user).Include(w=>w.user.Role).ToList();
            ViewData["numbers"] = numberToUser;
            return View(allUser);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

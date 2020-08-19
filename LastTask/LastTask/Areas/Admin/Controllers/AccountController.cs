using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastTask.Models;
using LastTask.Models.DataContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static LastTask.Models.Identity;

namespace LastTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        readonly SignInManager<PromediUser> signInManager;
        readonly UserManager<PromediUser> userManager;
        readonly RoleManager<PromediRole> roleManager;
        readonly UserDbContext db;
        public AccountController(UserDbContext db,SignInManager < PromediUser> signInManager,
            UserManager<PromediUser> userManager,
            RoleManager<PromediRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.db = db;
        }
        async public Task<IActionResult> SignIn()
        {
            var roleList = await roleManager.Roles.ToListAsync();
            return View(roleList);
        }
        async public Task<IActionResult> AddRole(string RoleName)
        {
            if (!string.IsNullOrWhiteSpace(RoleName))
            {
                var checkRole = await roleManager.FindByNameAsync(RoleName);
                if (checkRole != null)
                {
                    ViewBag.existRole = "Role has already existed!";
                }
                var role = new PromediRole
                {
                    Name = RoleName,
                };
                await roleManager.CreateAsync(role);
            }
            else
            {
                ViewBag.emptyInput = "Please,fill input";
            }
            return RedirectToAction("SignIn", "Account");
        }
        [HttpPost]
        async public Task<IActionResult> userRegister(string userName,string fatherName,string roleName, string number)
        {
            if (!string.IsNullOrWhiteSpace(userName)&& !string.IsNullOrWhiteSpace(fatherName)&& !string.IsNullOrWhiteSpace(roleName))
            {
                Number newNumber = new Number();
                if (!string.IsNullOrWhiteSpace(number))
                {
                    newNumber.phoneNumber = number;
                    db.numbers.Add(newNumber);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.emptyNumber = "Please,fill number";
                    return RedirectToAction("SignIn", "Account");
                }
                var userExistsOrNot = await userManager.FindByNameAsync(userName);
                if (userExistsOrNot == null)
                {
                    var newUser = new PromediUser
                    {
                        UserName = userName,
                        FatherName = fatherName,
                        NumberId = newNumber.Id,
                    };
                    await userManager.CreateAsync(newUser);
                    await userManager.AddToRoleAsync(newUser, roleName);
                }
                else
                {

                    ViewBag.existUser = "User has already existed";
                }
            }
            else
            {
                ViewBag.emptyInputs = "Please,fill all input";
            }
            return RedirectToAction("SignIn", "Account");
        }
    }
}

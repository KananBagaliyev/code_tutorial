using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using code_tutorial.DAL;
using code_tutorial.Models;
using code_tutorial.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace code_tutorial.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator,Teacher")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;

        public DashboardController(AppDbContext db,UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            List<User> users = new List<User>();

            foreach (User user in _db.Users.Where(u => u.isDeleted == false && u.EmailConfirmed == true)) 
            {
                if ((await _userManager.GetRolesAsync(user))[0] == "Teacher") 
                {
                    users.Add(user);
                }
            }

            DashboardVM dashboardVM = new DashboardVM()
            {
                Courses = _db.Courses.Where(c => c.isDeleted == false),
                Subjects = _db.Subjects.Where(s => s.isDeleted == false),
                Users = users,
                Subscribers = _db.Subscribers
                
            };
            return View(dashboardVM);
        }
    }
}

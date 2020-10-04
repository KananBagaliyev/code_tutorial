using final_poject.DAL;
using final_poject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.Areas.Admin.ViewComponents
{
    public class UserViewComponent:ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _db;

        public UserViewComponent(UserManager<User> userManager, AppDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Fullname = user.Fullname;
            TempData["User"] = (await _userManager.GetRolesAsync(user))[0];


            return View(user);
        }
    }
}

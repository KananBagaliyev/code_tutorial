using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using code_tutorial.DAL;
using code_tutorial.Helpers;
using code_tutorial.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace code_tutorial.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator,Teacher")]
    public class ChangePictureController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly IHostingEnvironment _env;

        public ChangePictureController(AppDbContext db, UserManager<User> userManager, IHostingEnvironment env)
        {
            _db = db;
            _userManager = userManager;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            User user = await _userManager.GetUserAsync(User);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public async Task<IActionResult> ChangePic(IFormFile File)
        {
            User user = await _userManager.GetUserAsync(User);
            if (File != null)
            {
                if (!File.isImage())
                {
                    ModelState.AddModelError(string.Empty, "Xahiş edirik şəkil formatı seçin");
                    return View(user);
                }
                if (user.Image != "profile-placeholder.png") 
                {
                    Helper.DeleteIMG(_env.WebRootPath, "img/teacher", user.Image);
                }
                string image = await File.SaveImg(_env.WebRootPath, "img/teacher");
                user.Image = image;
            }

            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index","Dashboard");
        }

        public async Task<IActionResult> RemovePicture()
        {
            User user = await _userManager.GetUserAsync(User);
            if (user.Image != "profile-placeholder.png") 
            {
                Helper.DeleteIMG(_env.WebRootPath, "img/teacher", user.Image);
            }
            string image = "profile-placeholder.png";
            user.Image = image;

            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index", "Dashboard");
        }
    }
}

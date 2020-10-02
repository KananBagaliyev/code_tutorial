using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_poject.DAL;
using final_poject.Helpers;
using final_poject.Models;
using final_poject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace final_poject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class HomePageController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;

        public HomePageController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            Greeting greeting = _db.Greetings.FirstOrDefault();
            HomePageVM hPageVM = new HomePageVM
            {
                prevImage = greeting.Image,
                Header = greeting.Header,
                Content = greeting.Content
            };
            return View(hPageVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public async Task<IActionResult> EditHomePage(HomePageVM homePageVM, IFormFile File)
        {

            Greeting greeting = _db.Greetings.FirstOrDefault();
            homePageVM.prevImage = greeting.Image;

            if (!ModelState.IsValid) 
            {
                return View(homePageVM);
            }

            if (File != null)
            {
                if (!File.isImage())
                {
                    ModelState.AddModelError(string.Empty, "Xahiş edirik şəkil formatı seçin");
                    return View(homePageVM);
                }
                Helper.DeleteIMG(_env.WebRootPath, "img", greeting.Image);
                greeting.Image = await File.SaveImg(_env.WebRootPath, "img");
            }

            greeting.Header = homePageVM.Header;
            greeting.Content = homePageVM.Content;

            await _db.SaveChangesAsync();

            HomePageVM hPageVM = new HomePageVM
            {
                prevImage = greeting.Image,
                Header = greeting.Header,
                Content = greeting.Content
            };
            return View(hPageVM);
        }
    }
}

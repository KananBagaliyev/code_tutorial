using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using code_tutorial.DAL;
using code_tutorial.Helpers;
using code_tutorial.Models;
using code_tutorial.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace code_tutorial.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class ContactPageController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;

        public ContactPageController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            ContactGreeting greeting = _db.ContactGreetings.FirstOrDefault();
            ContactPageVM cPageVM = new ContactPageVM
            {
                prevImage = greeting.Image,
                Header = greeting.Header,
                Content = greeting.Content
            };
            return View(cPageVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public async Task<IActionResult> EditContactPage(ContactPageVM contactPageVM, IFormFile File)
        {

            ContactGreeting greeting = _db.ContactGreetings.FirstOrDefault();
            contactPageVM.prevImage = greeting.Image;

            if (!ModelState.IsValid)
            {
                return View(contactPageVM);
            }

            if (File != null)
            {
                if (!File.isImage())
                {
                    ModelState.AddModelError(string.Empty, "Xahiş edirik şəkil formatı seçin");
                    return View(contactPageVM);
                }
                Helper.DeleteIMG(_env.WebRootPath, "img", greeting.Image);
                greeting.Image = await File.SaveImg(_env.WebRootPath, "img");
            }

            greeting.Header = contactPageVM.Header;
            greeting.Content = contactPageVM.Content;

            await _db.SaveChangesAsync();

            ContactPageVM cPageVM = new ContactPageVM
            {
                prevImage = greeting.Image,
                Header = greeting.Header,
                Content = greeting.Content
            };
            return View(cPageVM);
        }
    }
}

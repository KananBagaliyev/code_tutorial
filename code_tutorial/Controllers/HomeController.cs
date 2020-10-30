using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using code_tutorial.DAL;
using code_tutorial.Migrations;
using code_tutorial.Models;
using code_tutorial.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace code_tutorial.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;

        public HomeController(AppDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            List<Models.Category> categories = new List<Models.Category>();
            Models.Category fCategory = new Models.Category();
            Models.Category sCategory = new Models.Category();
            List<Models.Subject> subjects = new List<Models.Subject>();
            List<Models.Subject> fSubjects = new List<Models.Subject>();
            List<Models.Subject> sSubjects = new List<Models.Subject>();

            foreach (Models.Category category in _db.Categories.Where(c => c.isDeleted == false && _db.Subjects.Where(s=>s.Course.CategoryId ==c.Id && s.Course.isDeleted == false).Any(s=>s.isDeleted == false)).Take(2)) 
            {
                categories.Add(category);
            }

            if (categories.Count() == 1)
            {
                fCategory = categories[0];
            }
            else if (categories.Count() == 2) 
            {
                fCategory = categories[0];
                sCategory = categories[1];
            }

            

            HomeVM homeVM = new HomeVM
            {
                Greeting = _db.Greetings.FirstOrDefault(),
                Courses = _db.Courses.Where(c=>c.isDeleted == false && c.Category.isDeleted ==false).Take(6),
                FrontSubjects = fSubjects,
                BackSubjects = sSubjects,
                FavoriteSubjects = subjects
            };

            if (fCategory.Name != null)
            {
                homeVM.FrontSubjects = _db.Subjects.Include(s => s.Course).Where(s => s.CourseId == _db.Courses.Where(c => c.Id == s.CourseId).Where(c => c.CategoryId == fCategory.Id).FirstOrDefault().Id && s.isDeleted == false).OrderByDescending(s => s.Id).Take(3);
            }
            if (sCategory.Name != null) 
            {
                homeVM.BackSubjects = _db.Subjects.Include(s => s.Course).Where(s => s.CourseId == _db.Courses.Where(c => c.Id == s.CourseId).Where(c => c.CategoryId == sCategory.Id).FirstOrDefault().Id && s.isDeleted == false).OrderByDescending(s => s.Id).Take(3);
            }
            if(Request.Cookies["subject"]!= null) 
            {
                homeVM.FavoriteSubjects = JsonConvert.DeserializeObject<List<Models.Subject>>(Request.Cookies["subject"]);
            }
            if (User.Identity.IsAuthenticated) 
            {
                User user = await _userManager.GetUserAsync(User);
                foreach(SavedSubject savedSubject in _db.SavedSubjects.Where(s=>s.User == user)) 
                {
                    if (_db.Subjects.Any(s => s.Id == savedSubject.SubjectId && s.isDeleted == false && s.Course.isDeleted == false && s.Course.Category.isDeleted == false)) 
                    {
                        subjects.Add(_db.Subjects.FirstOrDefault(s => s.Id == savedSubject.SubjectId && s.isDeleted == false && s.Course.isDeleted == false && s.Course.Category.isDeleted == false));
                    }
                    
                }
                homeVM.FavoriteSubjects =  subjects;
            }
            return View(homeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public async Task<IActionResult> Subscribe(string sub) 
        {
            if (_db.Subscribers.Any(s => s.Email == sub.Trim())) 
            {
                TempData["Error"] = "Bu email ünvanı artıq abunə olmuşdur. Xahiş edirik başqa email daxil edəsiniz.";
                return RedirectToAction(nameof(Index));
            }
            Subscriber subscriber = new Subscriber
            {
                Email = sub,
                SubscribedDate = DateTime.Now
            };

            _db.Subscribers.Add(subscriber);

            await _db.SaveChangesAsync();
            TempData["Success"] = "Siz müvəffəqiyyətlə abunə oldunuz.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(string value)
        {
            string rawValue = value.Substring(1, value.Length - 2);
            List<Models.Subject> subjects = _db.Subjects.Include(s => s.Course).Where(s => s.Name.ToLower().Contains(value.ToLower()) || s.Definition.ToLower().Contains(value.ToLower())).ToList();

            return View(subjects);
        }
    }
}

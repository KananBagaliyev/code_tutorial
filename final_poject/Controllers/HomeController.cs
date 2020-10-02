using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_poject.DAL;
using final_poject.Migrations;
using final_poject.Models;
using final_poject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace final_poject.Controllers
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
            HomeVM homeVM = new HomeVM
            {
                Greeting = _db.Greetings.FirstOrDefault(),
                Courses = _db.Courses.Take(6),
                FrontSubjects = _db.Subjects.Include(s=>s.Course).Where(s=>s.CourseId == _db.Courses.Where(c=>c.Id == s.CourseId).Where(c=>c.CategoryId==1).FirstOrDefault().Id).OrderByDescending(s=>s.Id).Take(3),
                BackSubjects = _db.Subjects.Include(s => s.Course).Where(s => s.CourseId == _db.Courses.Where(c => c.Id == s.CourseId).Where(c => c.CategoryId == 2).FirstOrDefault().Id).OrderByDescending(s => s.Id).Take(3),
                
                
            };
            if(Request.Cookies["subject"]!= null) 
            {
                homeVM.FavoriteSubjects = JsonConvert.DeserializeObject<List<Models.Subject>>(Request.Cookies["subject"]);
            }
            if (User.Identity.IsAuthenticated) 
            {
                User user = await _userManager.GetUserAsync(User);
                List<Models.Subject> subjects = new List<Models.Subject>();
                foreach(SavedSubject savedSubject in _db.SavedSubjects.Where(s=>s.User == user)) 
                {
                    subjects.Add(_db.Subjects.FirstOrDefault(s => s.Id == savedSubject.SubjectId));
                }
                homeVM.FavoriteSubjects =  subjects;
            }
            return View(homeVM);
        }
    }
}

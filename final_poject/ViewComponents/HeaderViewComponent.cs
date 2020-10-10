using final_poject.DAL;
using final_poject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;

        public HeaderViewComponent(AppDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Subject> subjects = new List<Subject>();
            List<Subject> rawSubjects = new List<Subject>();
            if (Request.Cookies["subject"] != null) 
            {
                rawSubjects = JsonConvert.DeserializeObject<List<Subject>>(Request.Cookies["subject"]);
                foreach (Subject subject in rawSubjects) 
                {
                    if (_db.Subjects.FirstOrDefault(s => s.Id == subject.Id).isDeleted == false && _db.Courses.FirstOrDefault(c => c.Id == subject.CourseId).isDeleted == false && _db.Courses.Include(co => co.Category).FirstOrDefault(co => co.Id == subject.CourseId).Category.isDeleted == false)
                    {
                        subjects.Add(subject);
                    }
                }
            }
            
            if (User.Identity.IsAuthenticated)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.Fullname = user.Fullname;
                List<SavedSubject> dbSavedSubjects = _db.SavedSubjects.Where(s => s.User == user).ToList();
                List<Subject> dbSubjects = new List<Subject>();

                foreach (SavedSubject savedSubject in dbSavedSubjects)
                {
                    dbSubjects.Add(_db.Subjects.Include(s=>s.Course).Include(s=>s.Course.Category).FirstOrDefault(s => s.Id == savedSubject.SubjectId));
                }

                dbSubjects = dbSubjects.Where(s => s.isDeleted == false && s.Course.isDeleted == false &&s.Course.Category.isDeleted == false).ToList();
                subjects = dbSubjects;
            }

            return View(subjects);
        }
    }
}

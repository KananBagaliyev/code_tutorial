using final_poject.DAL;
using final_poject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            if (Request.Cookies["subject"] != null) 
            {
                subjects = JsonConvert.DeserializeObject<List<Subject>>(Request.Cookies["subject"]);
            }
            
            if (User.Identity.IsAuthenticated)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.Fullname = user.Fullname;
                List<SavedSubject> dbSavedSubjects = _db.SavedSubjects.Where(s => s.User == user).ToList();
                List<Subject> dbSubjects = new List<Subject>();

                foreach (SavedSubject savedSubject in dbSavedSubjects)
                {
                    dbSubjects.Add(_db.Subjects.FirstOrDefault(s => s.Id == savedSubject.SubjectId));
                }

                subjects = dbSubjects;
            }

            return View(subjects);
        }
    }
}

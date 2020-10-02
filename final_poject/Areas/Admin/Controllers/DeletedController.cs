using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_poject.DAL;
using final_poject.Models;
using final_poject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace final_poject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DeletedController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;

        public DeletedController(AppDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Category() 
        {
            return View(_db.Categories.Include(c=>c.User).Where(c=>c.isDeleted == true));
        }

        public async Task<IActionResult> ActivateCategory(int? id)
        {
            if (id == null) return NotFound();
            Category category = await _db.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (category == null) return NotFound();
            if (category.isDeleted == false) return NotFound();

            category.isDeleted = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Category");
        }

        public async Task<IActionResult> EditCategory(int? id) 
        {
            if (id == null) return NotFound();
            Category category = await _db.Categories.FindAsync(id);
            if (category == null) return NotFound();
            if (category.isDeleted == false) return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(int? id, Category _category)
        {
            if (id == null) return NotFound();
            Category category = await _db.Categories.FindAsync(id);
            if (category == null) return NotFound();
            if (category.isDeleted == false) return NotFound();

            if (_db.Categories.Any(c => c.Name.ToLower() == _category.Name.ToLower()))
            {
                if (category.Name.ToLower() != _category.Name.ToLower())
                {
                    ModelState.AddModelError(string.Empty, "Bu adda kateqoriya mövcuddur. Xahiş edirik başqa ad seçəsiniz.");
                    return View(_category);
                }
            }

            category.Name = _category.Name;
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Category));
        }

        public IActionResult Course()
        {
            return View(_db.Courses.Include(c => c.User).Include(c=>c.Category).Where(c => c.isDeleted == true));
        }

        public async Task<IActionResult> ActivateCourse(int?id) 
        {
            if (id == null) return NotFound();
            Course course = await _db.Courses.Include(c => c.Category).Where(c => c.Id == id).FirstOrDefaultAsync();
            if (course == null) return NotFound();
            if (course.isDeleted == false) return NotFound();
            TempData["Category"] = course.Category.Name.ToString();
            if (course.Category.isDeleted == true)
            {
                TempData["Error"] = "category";
                return RedirectToAction("Subject");
            }
            course.isDeleted = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Course");
        }

        public async Task<IActionResult> EditCourse(int? id) 
        {
            if (id == null) return NotFound();
            Course course = await _db.Courses.FindAsync(id);
            if (course == null) return NotFound();
            if (course.isDeleted == false) return NotFound();

            CourseEditVM editVM = new CourseEditVM
            {
                Categories = _db.Categories.Where(c => c.isDeleted == false),
                Category = _db.Categories.FirstOrDefault(c => c.Id == course.CategoryId),
                Course = course
            };
            return View(editVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCourse(int? id, CourseEditVM _course)
        {
            if (id == null) return NotFound();
            Course course = await _db.Courses.FindAsync(id);
            if (course == null) return NotFound();
            if (course.isDeleted == false) return NotFound();

            _course.Categories = _db.Categories;
            _course.Category = _db.Categories.FirstOrDefault(c => c.Id == course.CategoryId);

            if (!ModelState.IsValid)
            {
                return View(_course);
            }


            if (_db.Courses.Any(c => c.Name.ToLower() == _course.Course.Name.ToLower()))
            {
                if (course.Name.ToLower() != _course.Course.Name.ToLower())
                {
                    ModelState.AddModelError(string.Empty, "Bu adda kurs mövcuddur. Xahiş edirik başqa ad seçəsiniz.");
                    return View(_course);
                }
            }

            Category category = await _db.Categories.FindAsync(Int32.Parse(Request.Form["category"]));
            int prev_id = course.CategoryId;
            course.Name = _course.Course.Name;
            if (course.Category != category)
            {
                course.Category = category;
            }
            await _db.SaveChangesAsync();

            return RedirectToAction("Course");
        }
        public IActionResult Subject()
        {
            return View(_db.Subjects.Include(s => s.User).Include(s=>s.Course).Where(c => c.isDeleted == true));
        }

        public async Task<IActionResult> ActivateSubject(int? id)
        {
            TempData["Error"] = "false";
            if (id == null) return NotFound();
            Subject subject = await _db.Subjects.Include(s => s.Course.Category).Include(s=>s.Course).Where(c => c.Id == id).FirstOrDefaultAsync();
            TempData["Course"] = subject.Course.Name.ToString();
            TempData["Category"] = subject.Course.Category.Name.ToString();
            if (subject.Course.Category.isDeleted == true && subject.Course.isDeleted == true)
            {
                TempData["Error"] = "both";
                return RedirectToAction("Subject");
            }
            if (subject.Course.isDeleted == true) 
            {
                TempData["Error"] = "course";
                return RedirectToAction("Subject");
            }
            if (subject.Course.Category.isDeleted == true)
            {
                TempData["Error"] = "category";
                return RedirectToAction("Subject");
            }
            if (subject == null) return NotFound();
            if (subject.isDeleted == false) return NotFound();

            subject.isDeleted = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Subject");
        }

        public async Task<IActionResult> EditSubject(int? id) 
        {
            if (id == null) return NotFound();
            Subject subject = await _db.Subjects.Include(c => c.Course).Where(c => c.Id == id && c.isDeleted == true).FirstOrDefaultAsync();
            if (subject == null) return NotFound();
            if (subject.isDeleted == false) return NotFound();

            Article article = await _db.Articles.Include(a => a.Subject).Include(a => a.User).Where(a => a.SubjectId == subject.Id).FirstOrDefaultAsync();

            List<EditedSubject> editedSubjects = _db.EditedSubjects.Include(a => a.User).Where(e => e.SubjectId == subject.Id).ToList();

            EditedSubjectVM subjectVM = new EditedSubjectVM
            {
                Courses = _db.Courses.Where(c=>c.isDeleted == false),
                Article = article,
                Subject = subject,
                EditedSubjects = editedSubjects
            };
            return View(subjectVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSubject(int? id, ArticleVM articleVM)
        {
            if (id == null) return NotFound();
            Subject subject = await _db.Subjects.Include(s => s.Course).Where(s => s.Id == id && s.isDeleted == true).FirstOrDefaultAsync();
            if (subject == null) return NotFound();
            if (subject.isDeleted == false) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(articleVM);
            }

            User user = await _userManager.GetUserAsync(User);

            subject.Name = articleVM.Subject.Name;
            subject.Definition = articleVM.Subject.Definition;

            Article article = await _db.Articles.Where(a => a.SubjectId == subject.Id).FirstOrDefaultAsync();

            article.Content = articleVM.Article.Content;
            Course course = await _db.Courses.FindAsync(Int32.Parse(Request.Form["course"]));
            int prev_id = subject.CourseId;
            EditedSubject editedSubject = new EditedSubject
            {
                SubjectId = subject.Id,
                UserId = user.Id,
                EditedDate = DateTime.Now
            };
            subject.Course = course;
            _db.EditedSubjects.Add(editedSubject);
            await _db.SaveChangesAsync();
            return RedirectToAction("Subject");


        }
    }
}

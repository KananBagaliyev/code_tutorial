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
    //[Authorize(Roles = "Admin,Moderator,Teacher")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;


        public CategoryController(AppDbContext db,UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(_db.Categories.Where(c=>c.isDeleted == false));
        }

        public IActionResult EditCategory() 
        {
            return View(_db.Categories.Where(c=>c.isDeleted == false));
        }


        public async Task<IActionResult> CategoryEdit(int? id)
        {
            if (id == null) return NotFound();
            Category category = await _db.Categories.FindAsync(id);
            if (category == null) return NotFound();
            if (category.isDeleted == true) return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryEdit(int? id,Category _category)
        {
            if (id == null) return NotFound();
            Category category = await _db.Categories.FindAsync(id);
            if (category == null) return NotFound();
            if (category.isDeleted == true) return NotFound();

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

            return RedirectToAction(nameof(EditCategory));
        }

        public async Task<IActionResult> DeleteCategory(int? id)
        {
            TempData["Error"] = "false";
            if (id == null) return NotFound();
            Category category = await _db.Categories.FindAsync(id);
            if (category == null) return NotFound();
            if (category.isDeleted == true) return NotFound();

            if (_db.Subjects.Include(s => s.Course.Category).Where(s=>s.isDeleted == false).Any(s => s.Course.Category == category)) 
            {
                TempData["Error"] = "true";
                return RedirectToAction("EditCategory");
            }

            category.isDeleted = true;
            category.User = await _userManager.GetUserAsync(User);
            category.DeletedTime = DateTime.Now;
            await _db.SaveChangesAsync();
            return RedirectToAction("EditCategory");
        }

        public IActionResult NewCategory() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewCategory(Category _category)
        {

            if (_db.Categories.Any(c => c.Name.ToLower() == _category.Name.ToLower()))
            {
                ModelState.AddModelError(string.Empty, "Bu adda kateqoriya mövcuddur. Xahiş edirik başqa ad seçəsiniz.");
                return View(_category);
            }
            Category category = new Category
            {
                Name = _category.Name,
            };
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Course(int? id) 
        {
            if (id == null) return NotFound();
            Category category = await _db.Categories.FindAsync(id);
            if (category == null) return NotFound();
            if (category.isDeleted == true) return NotFound();

            List<Course> courses = _db.Courses.Include(c=>c.Category).Where(c => c.CategoryId == category.Id && c.isDeleted == false).ToList();
            CategoryVM categoryVM = new CategoryVM 
            {
                Category = category,
                Courses = courses
            };
            return View(categoryVM);
        }

        public async Task<IActionResult> EditCourse(int? id) 
        {
            if (id == null) return NotFound();
            Category category = await _db.Categories.FindAsync(id);
            if (category == null) return NotFound();
            if (category.isDeleted == true) return NotFound();

            CourseVM courseVM = new CourseVM
            {
                Courses = _db.Courses.Where(c => c.CategoryId == category.Id && c.isDeleted == false),
                Category = category
            };
            return View(courseVM);
        }

        public async Task<IActionResult> DeleteCourse(int? id)
        {
            TempData["Error"] = "false";
            if (id == null) return NotFound();
            Course course = await _db.Courses.Include(c=>c.Category).Where(c=>c.Id == id).FirstOrDefaultAsync();
            if (course == null) return NotFound();
            if (course.isDeleted == true) return NotFound();

            if (_db.Subjects.Include(s => s.Course.Category).Where(s => s.isDeleted == false).Any(s => s.Course == course))
            {
                TempData["Error"] = "true";
                return RedirectToAction("EditCourse", new { id = course.CategoryId });
            }
            course.isDeleted = true;
            course.User =await _userManager.GetUserAsync(User);
            course.DeletedTime = DateTime.Now;
            await _db.SaveChangesAsync();
            return RedirectToAction("EditCourse",new {id = course.CategoryId });
        }


        public async Task<IActionResult> CourseEdit(int? id)
        {
            if (id == null) return NotFound();
            Course course = await _db.Courses.FindAsync(id);
            if (course == null) return NotFound();
            if (course.isDeleted == true) return NotFound();

            CourseEditVM editVM = new CourseEditVM 
            {
                Categories = _db.Categories.Where(c=>c.isDeleted == false),
                Category = _db.Categories.FirstOrDefault(c=>c.Id == course.CategoryId),
                Course = course
            };
            return View(editVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CourseEdit(int? id, CourseEditVM _course)
        {
            if (id == null) return NotFound();
            Course course = await _db.Courses.FindAsync(id);
            if (course == null) return NotFound();
            if (course.isDeleted == true) return NotFound();
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

            return RedirectToAction("EditCourse",new {id = prev_id });
        }

        public async Task<IActionResult> NewCourse(int? id)
        {
            if (id == null) return NotFound();
            Category category = await _db.Categories.FindAsync(id);
            if (category == null) return NotFound();
            if (category.isDeleted == true) return NotFound();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewCourse(int? id, Course _course)
        {
            if (id == null) return NotFound();
            Category category = await _db.Categories.FindAsync(id);
            if (category == null) return NotFound();
            if (category.isDeleted == true) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(_course);
            }


            if (_db.Courses.Any(c => c.Name.ToLower() == _course.Name.ToLower()))
            {
                ModelState.AddModelError(string.Empty, "Bu adda kurs mövcuddur. Xahiş edirik başqa ad seçəsiniz.");
                return View(_course);
            }

            Course course = new Course 
            {
                Name = _course.Name,
                Category = category
            };
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
            return RedirectToAction("Course", new {id=category.Id });
        }

        public async Task<IActionResult> Subject(int? id) 
        {
            if (id == null) return NotFound();
            Course course = await _db.Courses.Include(c => c.Category).Where(c=>c.Id == id && c.isDeleted == false).FirstOrDefaultAsync();
            if (course == null) return NotFound();
            if (course.isDeleted == true) return NotFound();

            List<Subject> subjects = _db.Subjects.Include(s => s.Course).Where(s => s.CourseId == course.Id && s.isDeleted == false).OrderByDescending(s => s.Id).ToList();

            SubjectVM subjectVM = new SubjectVM
            {
                Subjects = subjects,
                Course = course
            };

            
            return View(subjectVM);
        }

        public async Task<IActionResult> Article(int? id) 
        {
            if (id == null) return NotFound();
            Subject subject = await _db.Subjects.Include(c => c.Course).Where(c => c.Id == id && c.isDeleted == false).FirstOrDefaultAsync();
            if (subject == null) return NotFound();
            if (subject.isDeleted == true) return NotFound();

            Article article = await _db.Articles.Include(a => a.Subject).Include(a=>a.User).Where(a => a.SubjectId == subject.Id).FirstOrDefaultAsync();

            List<EditedSubject> editedSubjects = _db.EditedSubjects.Include(a=>a.User).Where(e => e.SubjectId == subject.Id).ToList();

            EditedSubjectVM subjectVM = new EditedSubjectVM
            {
                Courses = _db.Courses.Where(c=>c.isDeleted == false),
                Article = article,
                Subject = subject,
                EditedSubjects = editedSubjects
            };
            return View(subjectVM);
        }
        public async Task<IActionResult> DeleteSubject(int? id)
        {
            if (id == null) return NotFound();
            Subject subject = await _db.Subjects.Include(s => s.Course).Where(s => s.Id == id).FirstOrDefaultAsync();
            if (subject == null) return NotFound();
            if (subject.isDeleted == true) return NotFound();

            subject.isDeleted = true;
            subject.User = await _userManager.GetUserAsync(User);
            subject.DeletedTime = DateTime.Now;
            await _db.SaveChangesAsync();
            return RedirectToAction("Subject", new { id = subject.CourseId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Article")]
        public async Task<IActionResult> EditArticle(int? id,ArticleVM articleVM) 
        {
            if (id == null) return NotFound();
            Subject subject = await _db.Subjects.Include(c => c.Course).Where(c => c.Id == id).FirstOrDefaultAsync();
            if (subject == null) return NotFound();


            if (!ModelState.IsValid) 
            {
                return View(articleVM);
            }

            User user = await _userManager.GetUserAsync(User);

            subject.Name = articleVM.Subject.Name;
            subject.Definition = articleVM.Subject.Definition;

            Article article = await _db.Articles.Where(a=>a.SubjectId == subject.Id).FirstOrDefaultAsync();

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
            return RedirectToAction("Subject",new {id = prev_id });


        }

        public async Task<IActionResult> NewSubject(int? id)
        {
            if (id == null) return NotFound();
            Course course = await _db.Courses.Include(c => c.Category).Where(c => c.Id == id).FirstOrDefaultAsync();
            if (course == null) return NotFound();

            ArticleVM articleVM = new ArticleVM { };
            return View(articleVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewSubject(int? id,ArticleVM articleVM)
        {
            if (id == null) return NotFound();
            Course course = await _db.Courses.Include(c => c.Category).Where(c => c.Id == id).FirstOrDefaultAsync();
            if (course == null) return NotFound();

            if (!ModelState.IsValid) 
            {
                return View(articleVM);
            }

            User user = await _userManager.GetUserAsync(User);

            Subject subject = new Subject
            {
                Name = articleVM.Subject.Name,
                Definition = articleVM.Subject.Definition,
                CourseId = course.Id
            };

            Article article = new Article
            {
                Content = articleVM.Article.Content,
                Subject = subject,
                PublishingDate = DateTime.Now,
                UserId = user.Id

            };

            _db.Articles.Add(article);
            await _db.SaveChangesAsync();
            return RedirectToAction("Subject",new {id = subject.Course.Id });
        }
    }
}

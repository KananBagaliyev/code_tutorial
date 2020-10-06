using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_poject.DAL;
using final_poject.Models;
using final_poject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace final_poject.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;
        public CourseController(AppDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(_db.Courses.Where(c=>c.isDeleted == false));
        }

        public async Task<IActionResult> Bookmark() 
        {
            List<Subject> subjects = new List<Subject>();
            if (User.Identity.IsAuthenticated)
            {
                User user = await _userManager.GetUserAsync(User);
                foreach (SavedSubject savedSubject in _db.SavedSubjects.Where(s => s.User == user))
                {
                    subjects.Add(_db.Subjects.Where(s=>s.isDeleted == false).FirstOrDefault(s => s.Id == savedSubject.SubjectId));
                }
            }
            else 
            {
                if (Request.Cookies["subject"] != null) 
                {
                    subjects = JsonConvert.DeserializeObject<List<Subject>>(Request.Cookies["subject"]);
                }
                subjects = subjects.Where(s => s.isDeleted == false).ToList();
                
            }
            return View(subjects);
        }

        public async Task<IActionResult> AddToFavorite(int? id,string control) 
        {
            if (id == null) return NotFound();
            Subject subject = await _db.Subjects.FindAsync(id);
            if (subject == null) return NotFound();


            if (User.Identity.IsAuthenticated)
            {
                User user = await _userManager.GetUserAsync(User);
                SavedSubject savedSubject = new SavedSubject
                {
                    User = user,
                    Subject =subject
                };

                _db.SavedSubjects.Add(savedSubject);
                await _db.SaveChangesAsync();
               
            }

            else 
            {
                string cookie = Request.Cookies["subject"];
                List<Subject> subjects;

                if (cookie == null)
                {
                    subjects = new List<Subject>();
                }
                else
                {
                    subjects = JsonConvert.DeserializeObject<List<Subject>>(cookie);
                }

                subjects.Add(subject);
                string favorite = JsonConvert.SerializeObject(subjects);
                Response.Cookies.Append("subject", favorite, new CookieOptions { MaxAge = TimeSpan.FromDays(14) });
            }
            if(control == "Bookmark") 
            {
                return RedirectToAction("Bookmark", "Course");
            }
            if (control == "Subject")
            {
                return RedirectToAction("Subject", new { id = subject.CourseId });
            }
            return RedirectToAction("Index", control);
        }

        public async Task<IActionResult> RemoveFromFavorite(int? id, string control) 
        {
            if (id == null) return NotFound();

            if (User.Identity.IsAuthenticated)
            {
                User user = await _userManager.GetUserAsync(User);
                SavedSubject savedSubject = _db.SavedSubjects.FirstOrDefault(s => s.SubjectId == id && s.User == user);

                _db.SavedSubjects.Remove(savedSubject);
                await _db.SaveChangesAsync();

                if(Request.Cookies["subject"] != null) 
                {
                    List<Subject> subjects = JsonConvert.DeserializeObject<List<Subject>>(Request.Cookies["subject"]);
                    if (subjects.Any(s => s.Id == id))
                    {
                        subjects.Remove(subjects.FirstOrDefault(s => s.Id == id));
                    };
                    if (subjects.Count == 0) { HttpContext.Response.Cookies.Delete("subject"); }
                    string favorite = JsonConvert.SerializeObject(subjects);
                    Response.Cookies.Append("subject", favorite, new CookieOptions { MaxAge = TimeSpan.FromDays(14) });
                }
            }
            else 
            {
                List<Subject> subjects = JsonConvert.DeserializeObject<List<Subject>>(Request.Cookies["subject"]);
                if (subjects.Find(s => s.Id == id) == null) return NotFound();
                subjects.Remove(subjects.FirstOrDefault(s => s.Id == id));
                if (subjects.Count == 0) { HttpContext.Response.Cookies.Delete("subject"); }
                string favorite = JsonConvert.SerializeObject(subjects);
                Response.Cookies.Append("subject", favorite, new CookieOptions { MaxAge = TimeSpan.FromDays(14) });
            }

            
            if (control == "Bookmark")
            {
                return RedirectToAction("Bookmark", "Course");
            }
            if (control == "Subject")
            {
                Subject subject = await _db.Subjects.Include(s => s.Course).Where(s => s.Id == id).FirstOrDefaultAsync();
                return RedirectToAction("Subject", new { id =subject.CourseId  }) ;
            }
            return RedirectToAction("Index",control);
        }



        public async Task<IActionResult> Subject(int? id) 
        {
            if (id == null) return NotFound();
            IEnumerable<Subject> subject = _db.Subjects.Include(s=>s.Course).Where(s=>s.CourseId == id && s.isDeleted == false);
            if (subject == null) return NotFound();

            List<Models.Subject> subjects = new List<Models.Subject>();

            FavoriteSubjectVM subjectVM = new FavoriteSubjectVM
            {
                Subjects = subject,
                Course = await _db.Courses.FindAsync(id),
                FavoriteSubjects = subjects
            };

            if (Request.Cookies["subject"] != null)
            {
                subjectVM.FavoriteSubjects = JsonConvert.DeserializeObject<List<Models.Subject>>(Request.Cookies["subject"]);
            }
            if (User.Identity.IsAuthenticated)
            {
                User user = await _userManager.GetUserAsync(User);
                foreach (SavedSubject savedSubject in _db.SavedSubjects.Where(s => s.User == user))
                {
                    subjects.Add(_db.Subjects.FirstOrDefault(s => s.Id == savedSubject.SubjectId));
                }
                subjectVM.FavoriteSubjects = subjects;
            }

            return View(subjectVM);

        }

        public async Task<IActionResult> Article(int? id)
        {
            if (id == null) return NotFound();
            Subject subject = await _db.Subjects.Include(s => s.Course).Where(s => s.Id == id).FirstOrDefaultAsync();
            if (subject == null) return NotFound();

            ComplexArticleVM articleVM = new ComplexArticleVM
            {
                Article = _db.Articles.Where(s => s.SubjectId == subject.Id).FirstOrDefault(),
                Subject = subject,
                RelatedSubjects = _db.Subjects.Where(s => s.Id != subject.Id).Take(5),
                Courses = _db.Courses.Take(6).OrderByDescending(c => c.Id),
                Comments = _db.Comments.Include(c => c.User).Where(c => c.Article == _db.Articles.Where(s => s.SubjectId == subject.Id).FirstOrDefault()).OrderByDescending(c=>c.Date),
                RepliedComments = _db.RepliedComments.Include(r=>r.User).Where(c=>c.Comment.Article == _db.Articles.Where(s => s.SubjectId == subject.Id).FirstOrDefault()).OrderByDescending(r=>r.Date)

            };

            return View(articleVM);

        }


        public async Task<IActionResult> AddComment(string data) 
        {
            User user = await _userManager.GetUserAsync(User);
            string[] reply = data.Split('"');
            if (reply.Length <11)
            {
                Comment comment = new Comment
                {
                    UserId = user.Id,
                    ArticleId = Int32.Parse(reply[3]),
                    Text = reply[7],
                    Date = DateTime.Now
                };
                _db.Comments.Add(comment);
            }
            else 
            {
                RepliedComment rComment = new RepliedComment
                {
                    UserId = user.Id,
                    Text = reply[7],
                    Date = DateTime.Now,
                    CommentId = Int32.Parse(reply[11]),
                    //ArticleId = Int32.Parse(reply[3])
                };

                _db.RepliedComments.Add(rComment);
            }

           
            await _db.SaveChangesAsync();

            ReplyVM replyVM = new ReplyVM
            {
                Comments = _db.Comments.Include(c => c.User).Where(c => c.Article == _db.Articles.Where(s => s.Id == Int32.Parse(reply[3])).FirstOrDefault()),
                RepliedComments = _db.RepliedComments.Include(r => r.User).Where(c => c.Comment.Article == _db.Articles.Where(s => s.Id == Int32.Parse(reply[3])).FirstOrDefault())
            };
            return Content("Okay");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Subject")]
        public async Task<IActionResult> Subscribe(string sub,int? id)
        {
            if (_db.Subscribers.Any(s => s.Email == sub.Trim()))
            {
                TempData["Error"] = "Bu email ünvanı artıq abunə olmuşdur. Xahiş edirik başqa email daxil edəsiniz.";
                return RedirectToAction("Subject",id);
            }
            Subscriber subscriber = new Subscriber
            {
                Email = sub,
                SubscribedDate = DateTime.Now
            };

            _db.Subscribers.Add(subscriber);

            await _db.SaveChangesAsync();
            TempData["Success"] = "Siz müvəffəqiyyətlə abunə oldunuz.";
            return RedirectToAction("Subject", id);
        }

        public IActionResult Search(string key) 
        {
            var model = _db.Subjects.Include(s=>s.Course).Where(s => s.Name.ToLower().Contains(key.ToLower()) || s.Definition.ToLower().Contains(key.ToLower())).Select(s => new Subject
            {
                Id = s.Id,
                Name = s.Name,
                Course = s.Course
            }).Take(5);
            return PartialView("_SubjectSearch", model);
        }

        public async Task<IActionResult> RemoveSelected(string data)
        {

            string[] subjectsId = data.Substring(1, data.Length - 2).Split(',');
            List<int> Ids = new List<int>();

            foreach (string subjectId in subjectsId)
            {
                Ids.Add(Int32.Parse(subjectId));
            }



            if (User.Identity.IsAuthenticated)
            {
                foreach (int id in Ids)
                {
                    if (!_db.SavedSubjects.Any(c => c.SubjectId == id)) return NotFound();
                    _db.SavedSubjects.Remove(_db.SavedSubjects.FirstOrDefault(c => c.SubjectId == id));
                }
            }
            else 
            {
                if (Request.Cookies["subject"] != null) 
                {
                    List<Subject> subjects = JsonConvert.DeserializeObject<List<Subject>>(Request.Cookies["subject"]);
                    foreach (int id in Ids)
                    {
                        if (subjects.Find(s => s.Id == id) == null) return NotFound();
                        subjects.Remove(subjects.FirstOrDefault(s => s.Id == id));
                    }

                    if (subjects.Count == 0) { HttpContext.Response.Cookies.Delete("subject"); }
                    string favorite = JsonConvert.SerializeObject(subjects);
                    Response.Cookies.Append("subject", favorite, new CookieOptions { MaxAge = TimeSpan.FromDays(14) });

                }

                

            }

            

            await _db.SaveChangesAsync();

            return Content("ok");
        }



    }
}

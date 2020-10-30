using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using code_tutorial.DAL;
using code_tutorial.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace code_tutorial.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator,Teacher")]
    public class CalendarController : Controller
    {

        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;

        public CalendarController(AppDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetEvents()
        {
            User user = await _userManager.GetUserAsync(User);
            List<Event> events = _db.Events.Where(e => e.UserId == user.Id).ToList();
            return Json(events);
        }

        [HttpPost]
        public async Task<JsonResult> SaveEvent(Event _event)
        {
            bool status = false;
            User user = await _userManager.GetUserAsync(User);
            if (_event.Id > 0)
            {
                Event eve = _db.Events.Where(e => e.Id == _event.Id && e.UserId == user.Id).FirstOrDefault();
                if (eve != null) 
                {
                    eve.Subject = _event.Subject;
                    eve.Description = _event.Description;
                    eve.StartingDate = _event.StartingDate;
                    eve.EndingDate = _event.EndingDate;
                }
            }
            else 
            {
                _event.UserId = user.Id;
                _db.Events.Add(_event);
            }
            await _db.SaveChangesAsync();

            status = true;
            return Json(status);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteEvent(int? eventId)
        {
            bool status = false;
            User user = await _userManager.GetUserAsync(User);
            Event eve = _db.Events.Where(e => e.Id == eventId && e.UserId == user.Id).FirstOrDefault();
            if (eve != null)
            {
                _db.Events.Remove(eve);
                await _db.SaveChangesAsync();
                status = true;
            }
            return Json (status);
        }
    }
}

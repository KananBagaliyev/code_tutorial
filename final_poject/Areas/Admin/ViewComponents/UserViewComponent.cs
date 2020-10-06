using final_poject.DAL;
using final_poject.Models;
using final_poject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.Areas.Admin.ViewComponents
{
    public class UserViewComponent:ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _db;

        public UserViewComponent(UserManager<User> userManager, AppDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Event> events = new List<Event>();

            User user = await _userManager.FindByNameAsync(User.Identity.Name);

            foreach (Event _event in _db.Events.Where(e => e.UserId == user.Id)) 
            {

                if (_event.StartingDate.Date == DateTime.Now.Date || _event.StartingDate.Date < DateTime.Now.Date && _event.EndingDate.Date > DateTime.Now.Date) 
                {
                    events.Add(_event);
                }
            }

            AdminHeaderVM headerVM = new AdminHeaderVM
            {
                User = user,
                Events = events,
                Messages = _db.Contacts.Where(c => c.isDeleted == false).OrderByDescending(c => c.Id) 

            };


            ViewBag.Fullname = user.Fullname;
            TempData["User"] = (await _userManager.GetRolesAsync(user))[0];


            return View(headerVM);
        }
    }
}

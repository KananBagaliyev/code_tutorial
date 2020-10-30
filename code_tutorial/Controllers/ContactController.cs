using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using code_tutorial.DAL;
using code_tutorial.Migrations;
using code_tutorial.Models;
using code_tutorial.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace code_tutorial.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _db;
        public ContactController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ContactVM contactVM = new ContactVM
            {
                Greeting = _db.ContactGreetings.FirstOrDefault()
            };

            return View(contactVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public async Task<IActionResult> SendFeedback(Models.Contact contact) 
        {
            Models.Contact add_contact = new Models.Contact
            {
                Name = contact.Name,
                Email = contact.Email,
                Subject = contact.Subject,
                Message = contact.Message,
                SendingDate = DateTime.Now
            };
            ContactVM contactVM = new ContactVM
            {
                Greeting = _db.ContactGreetings.FirstOrDefault()
            };
            _db.Contacts.Add(add_contact);
            await _db.SaveChangesAsync();
            return View(contactVM);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using final_poject.DAL;
using final_poject.Models;
using final_poject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace final_poject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class MailController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;

        public MailController(AppDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {

            User user = await _userManager.GetUserAsync(User);
            if ((await _userManager.GetRolesAsync(user))[0] != "Teacher")
            {
                return View(_db.Contacts);
            }
            return View();
        }

        public IActionResult Trash()
        {
            return View(_db.Contacts);
        }

        public async Task<IActionResult> Read(int? id)
        {
            if (id == null) return NotFound();
            Contact contact = await _db.Contacts.FindAsync(id);
            if (contact == null) return NotFound();

            contact.isRead = true;
            await _db.SaveChangesAsync();
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Read")]
        public async Task<IActionResult> Reply(int? id, string message)
        {
            if (id == null) return NotFound();
            Contact contact = await _db.Contacts.FindAsync(id);
            if (contact == null) return NotFound();

            User user = await _userManager.GetUserAsync(User);
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(user.Email, user.Fullname);
            mail.To.Add(new MailAddress(contact.Email));

            mail.Subject = contact.Subject;
            mail.Body = "<h2>Salam dəyərli istifadəçi.</h2> </br>" + message;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential("noreply.codetutorial@gmail.com", "kb6853917");
            smtp.Send(mail);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(string mails)
        {
            string[] mailsID = mails.Substring(1, mails.Length - 2).Split(',');
            List<int> Ids = new List<int>();

            foreach (string mailID in mailsID)
            {
                Ids.Add(Int32.Parse(mailID));
            }

            List<Contact> contacts = new List<Contact>();

            foreach (int id in Ids)
            {
                if (_db.Contacts.FirstOrDefault(c => c.Id == id).isDeleted == true) return NotFound();
                _db.Contacts.FirstOrDefault(c => c.Id == id).isDeleted = true;
            }

            await _db.SaveChangesAsync();

            return Content("ok");
        }

        public async Task<IActionResult> Restore(string mails)
        {
            string[] mailsID = mails.Substring(1, mails.Length - 2).Split(',');
            List<int> Ids = new List<int>();

            foreach (string mailID in mailsID)
            {
                Ids.Add(Int32.Parse(mailID));
            }

            List<Contact> contacts = new List<Contact>();

            foreach (int id in Ids)
            {
                if (_db.Contacts.FirstOrDefault(c => c.Id == id).isDeleted == false) return NotFound();
                _db.Contacts.FirstOrDefault(c => c.Id == id).isDeleted = false;
            }

            await _db.SaveChangesAsync();

            return Content("ok");
        }

        public async Task<IActionResult> Seen(string mails)
        {
            string[] mailsID = mails.Substring(1, mails.Length - 2).Split(',');
            List<int> Ids = new List<int>();

            foreach (string mailID in mailsID)
            {
                Ids.Add(Int32.Parse(mailID));
            }

            if (Ids.Count == 1)
            {
                if (_db.Contacts.FirstOrDefault(c => c.Id == Ids[0]).isRead == true)
                {
                    _db.Contacts.FirstOrDefault(c => c.Id == Ids[0]).isRead = false;
                }
                else
                {
                    _db.Contacts.FirstOrDefault(c => c.Id == Ids[0]).isRead = true;
                }

            }

            else
            {

                List<Contact> contacts = new List<Contact>();

                foreach (int id in Ids)
                {
                    _db.Contacts.FirstOrDefault(c => c.Id == id).isRead = true;
                }
            }

            await _db.SaveChangesAsync();

            return Content("ok");
        }

        public async Task<IActionResult> RestoreOne(int? id)
        {
            if (id == null) return NotFound();
            Contact contact = await _db.Contacts.FindAsync(id);
            if (contact == null) return NotFound();
            if (contact.isDeleted == false) return NotFound();

            contact.isDeleted = false;

            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RestroreActivate(int? id)
        {
            if (id == null) return NotFound();
            Contact contact = await _db.Contacts.FindAsync(id);
            if (contact == null) return NotFound();


            if (contact.isDeleted == false)
            {
                contact.isDeleted = true;
            }
            else if (contact.isDeleted == true)
            {
                contact.isDeleted = false;
            }



            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult SearchInbox(string key)
        {
            List<Contact> contacts = _db.Contacts.Where(c => c.isDeleted == false && c.Subject.ToLower().Contains(key.ToLower()) || c.isDeleted == false && c.Name.ToLower().Contains(key.ToLower())).ToList();
            return PartialView("_SearchInbox",contacts);
        }

        public IActionResult SearchTrash(string key)
        {
            List<Contact> contacts = _db.Contacts.Where(c => c.isDeleted == true && c.Subject.ToLower().Contains(key.ToLower()) || c.isDeleted == true && c.Name.ToLower().Contains(key.ToLower())).ToList();
            return PartialView("_SearchTrash", contacts);
        }
    }
}

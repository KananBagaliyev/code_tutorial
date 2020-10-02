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

            User user = await  _userManager.GetUserAsync(User);
            if((await _userManager.GetRolesAsync(user))[0] != "Teacher") 
            {
                return View(_db.Contacts);
            }
            return View();
        }

        public IActionResult Compose() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Compose")]
        public async Task<IActionResult> auye(SendMessageVM message)
        {
            User user = await _userManager.GetUserAsync(User);
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(user.Email,user.Fullname);
            mail.To.Add(new MailAddress(message.To));

            mail.Subject = message.Subject;
            //if(message.CC != null) 
            //{
            //    foreach(string cc in message.CC) 
            //    {
            //        mail.CC.Add(new MailAddress(cc));
            //    }
            //}
            //if (message.BCC != null)
            //{
            //    foreach (string bcc in message.BCC)
            //    {
            //        mail.Bcc.Add(new MailAddress(bcc));
            //    }
            //}
            mail.Body = "<h2>Salam dəyərli istifadəçi.</h2>";
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential("noreply.codetutorial@gmail.com","kb6853917");
            smtp.Send(mail);


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
            return View(contact);
        }
    }
}

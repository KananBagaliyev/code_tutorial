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
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace final_poject.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AccountController> _logger;
        public AccountController(AppDbContext db, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, ILogger<AccountController> logger)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Register(Register _register)
        {
            User user = new User
            {
                Fullname = _register.Fullname,
                Email = _register.Email,
                UserName = _register.Username
            };

            IdentityResult identityResult = await _userManager.CreateAsync(user, _register.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    
                }
                return View(_register);

            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);
            _logger.Log(LogLevel.Warning, confirmationLink);

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("noreply.codetutorial@gmail.com","No-Reply" );
            mail.To.Add(new MailAddress(user.Email));

            mail.Subject = "Hesab təsdiqləmə";
            mail.Body = "<h4>Salam dəyərli istifadəçi.</h4> </br> <p>Sizin təsdiqləmə linkiniz: </p>" + confirmationLink;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential("noreply.codetutorial@gmail.com", "kb6853917");
            smtp.Send(mail);

            await _userManager.AddToRoleAsync(user, Helpers.Helper.Roles.Member.ToString());
            if (Request.Cookies["subject"] != null)
            {
                List<Subject> subjects = JsonConvert.DeserializeObject<List<Models.Subject>>(Request.Cookies["subject"]);
                foreach (Subject cookieSubject in subjects)
                {
                    if (!_db.SavedSubjects.Where(s=>s.User == user).Any(s => s.Subject == cookieSubject))
                    {
                        _db.SavedSubjects.Add(new SavedSubject
                        {
                            User = user,
                            SubjectId = cookieSubject.Id
                        });
                        await _db.SaveChangesAsync();

                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token) 
        {
            if (userId == null || token == null) 
            {
                return RedirectToAction("Index", "Home");
            }

            var user =  await _userManager.FindByIdAsync(userId);
            if (user == null) 
            {
                ModelState.AddModelError(string.Empty, "Xahiş edirik doğru linkə daxil olasınız");
                return View();
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (!result.Succeeded) 
            {
                ModelState.AddModelError(string.Empty, "Email təsdiqlənə bilmədi");
                return View();
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login _login)
        {
            if (!ModelState.IsValid) return View(_login);
            User active_user = await _userManager.FindByNameAsync(_login.Username);
            if (active_user == null)
            {
                ModelState.AddModelError(string.Empty, "İstifadəçi adı və yaxud Şifrə yanlışdır!!!");
                return View(_login);
            }
            if (active_user.isDeleted == true)
            {
                ModelState.AddModelError(string.Empty, "Bu hesab ya silinib ya da blok olunub.");
                return View(_login);
            }
            if (active_user.EmailConfirmed == false)
            {
                ModelState.AddModelError(string.Empty, "Xahiş edirik email ünvanınızı təsdiq edəsiniz.");
                return View(_login);
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult;
            if (_login.isChecked == true)
            {
                signInResult = await _signInManager.PasswordSignInAsync(active_user, _login.Password, true, true);
            }
            else
            {
                signInResult = await _signInManager.PasswordSignInAsync(active_user, _login.Password, false, true);
            }

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "İstifadəçi adı və yaxud Şifrə yanlışdır!!!");
                return View(_login);
            }
            if (Request.Cookies["subject"] != null)
            {
                List<Subject> subjects = JsonConvert.DeserializeObject<List<Models.Subject>>(Request.Cookies["subject"]);
                foreach (Subject cookieSubject in subjects)
                {
                    if (!_db.SavedSubjects.Where(s=>s.User == active_user).Any(s => s.Subject == cookieSubject))
                    {
                        _db.SavedSubjects.Add(new SavedSubject
                        {
                            User = active_user,
                            SubjectId = cookieSubject.Id
                        });
                        await _db.SaveChangesAsync();

                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> MyAccount() 
        {
            User user = await _userManager.GetUserAsync(User);
            Register reg = new Register
            {
                Fullname = user.Fullname,
                Username = user.UserName,
                Email = user.Email
            };
            return View(reg);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeBasics(Register reg,string pass)
        {
            TempData["basicError"] = "";

            User user = await _userManager.GetUserAsync(User);
            PasswordVerificationResult passresult = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, pass);

            if (passresult == PasswordVerificationResult.Failed) 
            {
                TempData["basicError"] = "Xahiş edirik şifrəni doğru daxil edin";
                return RedirectToAction("MyAccount",user);
            }

            user.Fullname = reg.Fullname;
            user.Email = reg.Email;
            user.UserName = reg.Username;

            await _db.SaveChangesAsync();

            return RedirectToAction("MyAccount");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(Register reg, string pass)
        {
            List<string> errors = new List<string>();
            TempData["passError"] = "";

            User user = await _userManager.GetUserAsync(User);
            PasswordVerificationResult passresult = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, reg.Password);

            if (passresult == PasswordVerificationResult.Failed)
            {
                TempData["passError"] = "Xahiş edirik şifrəni doğru daxil edin";
                return RedirectToAction("MyAccount", user);
            }

            var passwordValidator = new PasswordValidator<User>();
            var result = await passwordValidator.ValidateAsync(_userManager, null, pass);

            if (!result.Succeeded) 
            {
                foreach (var error in result.Errors)
                {
                    errors.Add(error.Description);

                }
                TempData["modelError"] = errors;
                return RedirectToAction("MyAccount");
            }

            var newPassword = _userManager.PasswordHasher.HashPassword(user, pass);
            user.PasswordHash = newPassword;
            await _userManager.UpdateAsync(user);

            await _signInManager.SignOutAsync();

            return RedirectToAction("Index","Home");
        }

        public IActionResult ForgetPassword() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string Email)
        {

            if (Email == null)
            {
                return View();
            }

            User user = await _userManager.FindByEmailAsync(Email);


            if (user == null) 
            {
                ModelState.AddModelError(string.Empty, "Xahiş edirik doğru email daxil edin");
                return View();
            }

            if (user != null && await _userManager.IsEmailConfirmedAsync(user)) 
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resetPassword = Url.Action("ResetPassword", "Account", new { email = user.Email, token = token }, Request.Scheme);
                _logger.Log(LogLevel.Warning, resetPassword);

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("noreply.codetutorial@gmail.com", "No-Reply");
                mail.To.Add(new MailAddress(user.Email));

                mail.Subject = "Şifrə sıfırlama";
                mail.Body = "<h4>Salam dəyərli istifadəçi.</h4> </br> <p>Sizin sıfırlama linkiniz: </p>" + resetPassword;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                smtp.Credentials = new NetworkCredential("noreply.codetutorial@gmail.com", "kb6853917");
                smtp.Send(mail);

                ModelState.AddModelError(string.Empty, "Sizə şifrənizi sıfırlamaq üçün məlumat göndərildi");
                return View();
            }

            

            ModelState.AddModelError(string.Empty, "Sizə şifrənizi sıfırlamaq üçün məlumat göndərildi");
            return View();
        }

        public IActionResult ResetPassword(string token, string email) 
        {
            if(token == null || email == null) 
            {
                ModelState.AddModelError(string.Empty, "Xahiş edirik doğru linkə daxil olasınız");
                return View();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPass)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await _userManager.FindByEmailAsync(resetPass.Email);

                if (user != null)
                {
                    // reset the user password
                    var result = await _userManager.ResetPasswordAsync(user, resetPass.Token, resetPass.Password);
                    if (result.Succeeded)
                    {
                        ModelState.AddModelError(string.Empty, "Şifrəniz sıfırlandı");
                        return View();
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(resetPass);
                }
                ModelState.AddModelError(string.Empty, "Xəta meydana gəldi");
                return View();
            }
            return View(resetPass);
        }

        public async Task CreateRole()
        {

            if (!await _roleManager.RoleExistsAsync(Helpers.Helper.Roles.Admin.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(Helpers.Helper.Roles.Admin.ToString()));
            }

            if (!await _roleManager.RoleExistsAsync(Helpers.Helper.Roles.Moderator.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(Helpers.Helper.Roles.Moderator.ToString()));
            }

            if (!await _roleManager.RoleExistsAsync(Helpers.Helper.Roles.Teacher.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(Helpers.Helper.Roles.Teacher.ToString()));
            }

            if (!await _roleManager.RoleExistsAsync(Helpers.Helper.Roles.Member.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(Helpers.Helper.Roles.Member.ToString()));
            }


        }
    }
}

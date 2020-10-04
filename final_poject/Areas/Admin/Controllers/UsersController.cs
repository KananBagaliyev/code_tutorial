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
    [Authorize(Roles = "Admin, Moderator")]
    public class UsersController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;

        public UsersController(AppDbContext db, UserManager<User>  userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            List<UserVM> userVM = new List<UserVM>();
            User currentUser = await _userManager.GetUserAsync(User);
            string userRole = (await _userManager.GetRolesAsync(currentUser))[0];

            if (userRole == "Moderator")
            {
                foreach (User user in _db.Users.Where(u => u.isDeleted == false))
                {
                    if ((await _userManager.GetRolesAsync(user))[0] == "Teacher" || (await _userManager.GetRolesAsync(user))[0] == "User")
                    {
                        if (user != currentUser) 
                        {
                            UserVM uVM = new UserVM
                            {
                                Id = user.Id,
                                Fullname = user.Fullname,
                                Username = user.UserName,
                                userRole = (await _userManager.GetRolesAsync(user))[0],
                                loggedUserRole = userRole
                            };
                            userVM.Add(uVM);
                        }
                    }
                }
            }

            else 
            {
                foreach (User user in _db.Users.Where(u => u.isDeleted == false))
                {
                    if (user != currentUser)
                    {
                        UserVM uVM = new UserVM
                        {
                            Id = user.Id,
                            Fullname = user.Fullname,
                            Username = user.UserName,
                            userRole = (await _userManager.GetRolesAsync(user))[0],
                            loggedUserRole = userRole
                        };
                        userVM.Add(uVM);
                    }
                }
            }
            return View(userVM);
        }

        public async Task<IActionResult> DeleteUser(string id) 
        {
            if (id == null) return NotFound();

            User deletedUser = await _userManager.FindByIdAsync(id);

            if (deletedUser == await _userManager.GetUserAsync(User)) return NotFound();
            if (deletedUser == null) return NotFound();
            if (deletedUser.isDeleted == true) return NotFound();


            deletedUser.isDeleted = true;
            await _userManager.UpdateAsync(deletedUser);

            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ActivateUser(string id)
        {
            if (id == null) return NotFound();

            User deletedUser = await _userManager.FindByIdAsync(id);

            if (deletedUser == await _userManager.GetUserAsync(User)) return NotFound();
            if (deletedUser == null) return NotFound();
            if (deletedUser.isDeleted == false) return NotFound();

            deletedUser.isDeleted = false;
            await _userManager.UpdateAsync(deletedUser);

            return RedirectToAction("DeletedUsers");
        }
        public async Task<IActionResult> DeletedUsers()
        {
            List<UserVM> userVM = new List<UserVM>();
            User currentUser = await _userManager.GetUserAsync(User);
            string userRole = (await _userManager.GetRolesAsync(currentUser))[0];

            if (userRole == "Moderator")
            {
                foreach (User user in _db.Users.Where(u => u.isDeleted == true))
                {
                    if ((await _userManager.GetRolesAsync(user))[0] == "Teacher" || (await _userManager.GetRolesAsync(user))[0] == "User")
                    {
                        if (user != currentUser)
                        {
                            UserVM uVM = new UserVM
                            {
                                Id = user.Id,
                                Fullname = user.Fullname,
                                Username = user.UserName,
                                userRole = (await _userManager.GetRolesAsync(user))[0],
                                loggedUserRole = userRole
                            };
                            userVM.Add(uVM);
                        }
                    }
                }
            }

            else 
            {
                foreach (User user in _db.Users.Where(u => u.isDeleted == true))
                {
                    if (user != currentUser)
                    {
                        UserVM uVM = new UserVM
                        {
                            Id = user.Id,
                            Fullname = user.Fullname,
                            Username = user.UserName,
                            userRole = (await _userManager.GetRolesAsync(user))[0],
                            loggedUserRole = userRole
                        };
                        userVM.Add(uVM);
                    }
                }
            }
            return View(userVM);
        }

        public async Task<IActionResult> EditUser(string id) 
        {
            if (id == null) return NotFound();

            User currentUser = await _userManager.GetUserAsync(User);
            string currentRole = (await _userManager.GetRolesAsync(currentUser))[0];

            User user = await _userManager.FindByIdAsync(id);
            string userRole = (await _userManager.GetRolesAsync(user))[0];

            if (user == null) return NotFound();

            TempData["currentUserRole"] = currentRole;

            if (currentRole == "Moderator" && userRole == "Admin" || currentRole == "Moderator" && userRole == "Moderator") return NotFound();

            UserVM userVM = new UserVM
            {
                Id = user.Id,
                Fullname = user.Fullname,
                Username = user.UserName,
                userRole = userRole,
                loggedUserRole = currentRole
            };

            return View(userVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("EditUser")]
        public async Task<IActionResult> EditUser(UserVM _user, string id)
        {
            if (id == null) return NotFound();

            User user = await _userManager.FindByIdAsync(id);
            string userRole = (await _userManager.GetRolesAsync(user))[0];

            if (user == null) return NotFound();

            string loggedUserRole = (await _userManager.GetRolesAsync(await _userManager.GetUserAsync(User)))[0];

            _user.loggedUserRole = loggedUserRole;
            _user.userRole = userRole;

            if (!ModelState.IsValid)
            {
                return View(_user);
            }

            user.UserName = _user.Username;

            IdentityResult identityResult = await _userManager.UpdateAsync(user);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                UserVM userVMx = new UserVM
                {
                    Id = id,
                    Fullname = _user.Fullname,
                    Username = user.UserName,
                    userRole = userRole,
                    loggedUserRole = loggedUserRole
                };
                return View(userVMx);
            }


            user.Fullname = _user.Fullname;
            string newRole = Request.Form["roles"].ToString();

            await _userManager.RemoveFromRoleAsync(user, userRole);
            await _userManager.AddToRoleAsync(user, newRole);

            UserVM userVM = new UserVM
            {
                Id = user.Id,
                Fullname = user.Fullname,
                Username = user.UserName,
                userRole = newRole,
                loggedUserRole = loggedUserRole
            };

            return View(userVM);
        }
    }
}

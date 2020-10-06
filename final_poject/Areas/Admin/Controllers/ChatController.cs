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

    [Authorize(Roles = "Admin,Moderator,Teacher")]
    [Area("Admin")]
    public class ChatController : Controller
    {

        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;

        public ChatController(AppDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            User currentUser = await _userManager.GetUserAsync(User);
            List<ChatUser> currentChatUsers = _db.ChatUsers.Where(c => c.UserId == currentUser.Id).ToList();
            List<User> currentChatFriends = new List<User>();
            List<ChatUser> currentChats = new List<ChatUser>();
            foreach (ChatUser cu in currentChatUsers)
            {
                foreach (ChatUser item in _db.ChatUsers.Include(c => c.User).Where(c => c.ChatId == cu.ChatId))
                {
                    if (item.UserId != currentUser.Id)
                    {
                        currentChats.Add(item);
                        currentChatFriends.Add(item.User);
                    }
                }
            }
            List<User> users = new List<User>();
            foreach (User item in _db.Users.Where(u=>u.EmailConfirmed == true && u.isDeleted == false))
            {
                bool hasChat = false;
                if (item != currentUser) 
                {
                    foreach (User user in currentChatFriends)
                    {
                        if (item == user )
                        {
                            hasChat = true;
                        }
                    }
                    if (!hasChat)
                    {
                        users.Add(item);
                    }
                    
                }
                    
                
            }
            ChatVM model = new ChatVM()
            {
                Users = users,
                CurrentChats = currentChats
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateChat()
        {
            string id = Request.Form["friend"];
            if (id == null)
            {
                return BadRequest();
            }
            User currentUser = await _userManager.GetUserAsync(User);
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            Chat chat = new Chat();
            List<ChatUser> chatUsers = new List<ChatUser>();
            chatUsers.Add(new ChatUser
            {
                Chat = chat,
                UserId = id
            });
            chatUsers.Add(new ChatUser
            {
                Chat = chat,
                UserId = currentUser.Id
            });
            chat.ChatUsers = chatUsers;
            _db.Chats.Add(chat);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Chat");
        }

        public async Task<IActionResult> Message(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Chat chat = await _db.Chats.FindAsync(id);
            User currentUser = await _userManager.GetUserAsync(User);
            if (chat == null)
            {
                return NotFound();
            }
            bool chatMember = false;
            foreach (ChatUser item in _db.ChatUsers.Where(c => c.ChatId == id))
            {
                if (item.UserId == currentUser.Id)
                {
                    chatMember = true;
                }
            }
            if (!chatMember)
            {
                return NotFound();
            }
            List<ChatUser> currentChatUsers = _db.ChatUsers.Where(c => c.UserId == currentUser.Id).ToList();
            List<User> currentChatFriends = new List<User>();
            List<ChatUser> currentChats = new List<ChatUser>();
            foreach (ChatUser cu in currentChatUsers)
            {
                foreach (ChatUser item in _db.ChatUsers.Include(c => c.User).Where(c => c.ChatId == cu.ChatId))
                {
                    if (item.UserId != currentUser.Id)
                    {
                        currentChats.Add(item);
                        currentChatFriends.Add(item.User);
                    }
                }
            }
            List<User> users = new List<User>();
            foreach (User item in _db.Users.Where(u => u.EmailConfirmed == true && u.isDeleted == false))
            {
                bool hasChat = false;
                if (item != currentUser)
                {
                    foreach (User user in currentChatFriends)
                    {
                        if (item == user)
                        {
                            hasChat = true;
                        }
                    }
                    if (!hasChat)
                    {
                        users.Add(item);
                    }

                }


            }

            ChatVM model = new ChatVM()
            {
                Users = users,
                CurrentChats = currentChats,
                Messages = _db.Messages.Include(m => m.User).Where(m => m.ChatId == id),
                Chat = chat
            };
            foreach (ChatUser chatUser in _db.ChatUsers.Include(c => c.User).Where(c => c.ChatId == id))
            {
                if (chatUser.UserId != currentUser.Id)
                {
                    User currentChatFriend = chatUser.User;
                    model.CurrentChatUser = currentChatFriend;
                }
            }
            return View(model);
        }
    }
}

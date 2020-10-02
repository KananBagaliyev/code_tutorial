using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using final_poject.DAL;
using final_poject.Hubs;
using final_poject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace final_poject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Moderator,Teacher")]
    [Route("[controller]")]
    [Area("Admin")]
    public class HubHandler : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly IHubContext<ChatHub> _hub;
        public HubHandler(AppDbContext db, UserManager<User> userManager, IHubContext<ChatHub> hub)
        {
            _db = db;
            _userManager = userManager;
            _hub = hub;
        }
        [HttpPost("[action]/{connectionId}/{roomId}")]
        public async Task<IActionResult> JoinRoom(string connectionId, string roomId)
        {
            await _hub.Groups.AddToGroupAsync(connectionId, roomId);
            return Ok();
        }

        [HttpPost("[action]/{connectionId}/{roomId}")]
        public async Task<IActionResult> LeaveRoom(string connectionId, string roomId)
        {
            await _hub.Groups.RemoveFromGroupAsync(connectionId, roomId);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SendMessage(int roomId, string message)
        {
            User currentUser = await _userManager.GetUserAsync(User);
            Message msg = new Message()
            {
                SendingDate = DateTime.Now,
                Text = message,
                ChatId = roomId,
                UserId = currentUser.Id
            };
            _db.Messages.Add(msg);
            await _db.SaveChangesAsync();
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            await _hub.Clients.Group(roomId.ToString()).SendAsync("ReceiveMessage", new
            {
                Text = msg.Text,
                Name = currentUser.UserName,
                Date = msg.SendingDate.ToString("g", culture)
            });
            return Ok();
        }
    }
}

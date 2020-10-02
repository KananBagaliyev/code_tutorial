using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_poject.Models;

namespace final_poject.ViewModels
{
    public class ChatVM
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<ChatUser> CurrentChats { get; set; }
        public User CurrentChatUser { get; set; }
        public IEnumerable<Message> Messages { get; set; }
        public Chat Chat { get; set; }
    }
}

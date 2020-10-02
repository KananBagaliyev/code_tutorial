using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<ChatUser> ChatUsers { get; set; }
    }
}

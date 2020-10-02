using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string Text { get; set; }
        public int ChatId { get; set; }
        public virtual Chat Chat { get; set; }
        public DateTime SendingDate { get; set; }
    }
}

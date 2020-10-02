﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.Models
{
    public class RepliedComment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}

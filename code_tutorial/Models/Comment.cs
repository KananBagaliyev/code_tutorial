using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public ICollection<RepliedComment> RepliedComments { get; set; }
    }
}

using final_poject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.ViewModels
{
    public class ReplyVM
    {
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<RepliedComment> RepliedComments { get; set; }
    }
}

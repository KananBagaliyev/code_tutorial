using code_tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.ViewModels
{
    public class ReplyVM
    {
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<RepliedComment> RepliedComments { get; set; }
    }
}

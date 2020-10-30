using code_tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.ViewModels
{
    public class ComplexArticleVM
    {
        public Subject Subject { get; set; }
        public Article Article { get; set; }
        public IEnumerable<Subject> RelatedSubjects { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<RepliedComment> RepliedComments { get; set; }
    }
}

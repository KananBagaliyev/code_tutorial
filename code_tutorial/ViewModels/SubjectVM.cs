using code_tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.ViewModels
{
    public class SubjectVM
    {
        public IEnumerable<Subject> Subjects { get; set; }
        public Course Course { get; set; }
    }
}

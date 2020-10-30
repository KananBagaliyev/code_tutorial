using code_tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.ViewModels
{
    public class CourseVM
    {
        public Category Category { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}

using code_tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.ViewModels
{
    public class DashboardVM
    {
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Subscriber> Subscribers { get; set; }
    }
}

using final_poject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.ViewModels
{
    public class HomeVM
    {
        public Greeting Greeting { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Subject> FrontSubjects { get; set; }
        public IEnumerable<Subject> BackSubjects { get; set; }
        public IEnumerable<Subject> FavoriteSubjects { get; set; }
    }
}

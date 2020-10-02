using final_poject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.ViewModels
{
    public class EditedSubjectVM
    {
        public IEnumerable<Course> Courses { get; set; }
        public Subject Subject { get; set; }
        public Article Article { get; set; }
        public IEnumerable<EditedSubject> EditedSubjects { get; set; }
    }
}

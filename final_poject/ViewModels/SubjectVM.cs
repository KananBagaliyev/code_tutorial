using final_poject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.ViewModels
{
    public class SubjectVM
    {
        public IEnumerable<Subject> Subjects { get; set; }
        public Course Course { get; set; }
    }
}

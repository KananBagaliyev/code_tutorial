using final_poject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.ViewModels
{
    public class CategoryVM
    {
        public IEnumerable<Course> Courses { get; set; }
        public Category Category { get; set; }
    }
}

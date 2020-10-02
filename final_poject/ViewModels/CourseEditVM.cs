using final_poject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.ViewModels
{
    public class CourseEditVM
    {
        public IEnumerable<Category> Categories;
        public Course Course { get; set; }
        public Category Category { get; set; }
    }
}

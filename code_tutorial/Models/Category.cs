using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız.")]
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
        public bool isDeleted { get; set; }
        public DateTime DeletedTime { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public Category()
        {
            isDeleted = false;
        }
    }
}

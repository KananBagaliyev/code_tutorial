using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız.")]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public bool isDeleted { get; set; }
        public DateTime DeletedTime { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public Course()
        {
            isDeleted = false;
        }
    }
}

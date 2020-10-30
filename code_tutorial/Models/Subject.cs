using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."),MaxLength(35,ErrorMessage = "Maksimum uzunluq 35 simvol ola bilər")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."),MaxLength(80,ErrorMessage = "Maksimum uzunluq 80 simvol ola bilər")]
        public string Definition { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual Article Article { get; set; }
        public bool isDeleted { get; set; }
        public DateTime DeletedTime { get; set; }
        public virtual ICollection<EditedSubject> EditedSubjects { get; set; }
        public virtual ICollection<SavedSubject> SavedSubjects { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public Subject()
        {
            isDeleted = false;
        }
    }
}

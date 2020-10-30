using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.Models
{
    public class SavedSubject
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}

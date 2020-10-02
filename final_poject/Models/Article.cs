using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız.")]
        public string Content { get; set; }
        public DateTime PublishingDate { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<RepliedComment> RepliedComments { get; set; }
    }
}

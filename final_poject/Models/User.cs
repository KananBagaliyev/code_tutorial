using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.Models
{
    public class User:IdentityUser
    {
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), StringLength(100)]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız.")]
        public bool isDeleted { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<EditedSubject> EditedArticles { get; set; }
        public virtual ICollection<Subject> RemovedSubjects { get; set; }
        public virtual ICollection<Course> RemovedCourses { get; set; }
        public virtual ICollection<Category> RemovedCategories { get; set; }
        public virtual ICollection<SavedSubject> SavedSubjects { get; set; }
        public ICollection<Message> Messages  { get; set; }
        public ICollection<ChatUser> ChatUsers { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<RepliedComment> RepliedComments { get; set; }
        public string Image { get; set; }
        public User()
        {
            isDeleted = false;
            Image = "profile-placeholder.png";
        }
    }
}

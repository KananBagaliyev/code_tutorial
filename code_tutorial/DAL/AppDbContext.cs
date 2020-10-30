using code_tutorial.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.DAL
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactGreeting> ContactGreetings { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<EditedSubject> EditedSubjects { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Greeting> Greetings { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<RepliedComment> RepliedComments { get; set; }
        public DbSet<SavedSubject> SavedSubjects { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Greeting>().HasData(new Greeting {Id = 1,Image = "greeting.svg",Header = "Azərbaycanın \"Developer\" portalı" ,Content = "\"Developer\" olmaq istəyirsiniz amma qarşınızda böyük bir problem var? İngiliscə tam anlamırsınız? Narahat olmağa dəyməz. Artıq proqramlaşdırma sahəsinə aid məqalələri öz ana dilimizdə də tapa biləcəksiniz. Sadəcə aşağıdakı axtarış hissəsindən istədiyiniz məqaləni axtarmağınız kifayət edir." });
            builder.Entity<Category>().HasData(new Category { Id = 1, Name = "Front-End" }, new Category { Id = 2, Name = "Back-End" });
            builder.Entity<Course>().HasData(new Course { Id = 1, Name = "HTML", CategoryId = 1 },
                new Course { Id = 2, Name = "CSS", CategoryId = 1 },
                new Course { Id = 3, Name = "Java Script", CategoryId = 1 },
                new Course { Id = 4, Name = "C#", CategoryId = 2 },
                new Course { Id = 5, Name = "MS SQL", CategoryId = 2 },
                new Course { Id = 6, Name = "Asp.net", CategoryId = 2 }
                );
            builder.Entity<Subject>().HasData(new Subject { Id = 1, Name = "List, Table, Link",Definition = "HTML - də list, cədvəl yaratmaq və yönləndirmə ", CourseId = 1 },
                new Subject {Id = 2 , Name = "Loops, Array, Condition",Definition = "C# - da \"Loop\", \"Array\" və \"Condition\" məntiqi",CourseId = 4 }
                );

            builder.Entity<ContactGreeting>().HasData(new ContactGreeting { Id = 1, Image = "contact.svg", Header = "Köməyə ehtiyyacınız var?", Content = "Əgər hər hansı probleminiz və ya saytla bağlı əlavə fikriniz varsa bizimlə əlaqə qura bilərsiniz. Heyyət üzvlərimiz yaxın zamanda cavab verməyə çalışacaq." });
            builder.Entity<Article>().HasData(new Article { Id = 1, Content = "Salam", SubjectId = 1 }, new Article { Id = 2, Content = "Sagol", SubjectId = 2 });
        }


    }
}

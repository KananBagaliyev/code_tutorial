using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), EmailAddress(ErrorMessage = "Xahiş edirik doğru email daxil edəsiniz."), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız.")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız.")]
        public string Message { get; set; }
        public bool isRead { get; set; }
        public DateTime SendingDate { get; set; }
        public bool isDeleted { get; set; }

        public Contact()
        {
            isRead = false;
            isDeleted = false;
        }
    }
}

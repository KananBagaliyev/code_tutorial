using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.Models
{
    public class ContactGreeting
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız.")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."),MaxLength(30,ErrorMessage = "Maksimum uzunluq 30 simvol ola bilər"),MinLength(10,ErrorMessage = "Ən azı 10 simvol olmalıdır")]
        public string Header { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), MaxLength(250, ErrorMessage = "Maksimum uzunluq 250 simvol ola bilər"), MinLength(10, ErrorMessage = "Ən azı 10 simvol olmalıdır")]
        public string Content { get; set; }
    }
}

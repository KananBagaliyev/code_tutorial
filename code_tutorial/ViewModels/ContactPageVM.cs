using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.ViewModels
{
    public class ContactPageVM
    {
        public string prevImage { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), MinLength(10, ErrorMessage = "Ən azı 10 simvol olmalıdır"), MaxLength(30, ErrorMessage = "Maksimum uzunluq 30 simvol ola bilər")]
        public string Header { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), MinLength(10, ErrorMessage = "Ən azı 10 simvol olmalıdır"), MaxLength(250, ErrorMessage = "Maksimum uzunluq 250 simvol ola bilər")]
        public string Content { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.ViewModels
{
    public class HomePageVM
    {
        public string prevImage { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), MinLength(10, ErrorMessage = "Ən azı 10 simvol olmalıdır"), MaxLength(40, ErrorMessage = "Maksimum uzunluq 40 simvol ola bilər")]
        public string Header { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), MinLength(10, ErrorMessage = "Ən azı 10 simvol olmalıdır"), MaxLength(450, ErrorMessage = "Maksimum uzunluq 300 simvol ola bilər")]
        public string Content { get; set; }
    }
}

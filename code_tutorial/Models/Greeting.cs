using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.Models
{
    public class Greeting
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız.")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), MinLength(10,ErrorMessage ="Ən azı 10 simvol olmalıdır"), MaxLength(40,ErrorMessage = "Maksimum uzunluq 40 simvol ola bilər")]
        public string Header { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), MinLength(10, ErrorMessage = "Ən azı 10 simvol olmalıdır"), MaxLength(450, ErrorMessage = "Maksimum uzunluq 450 simvol ola bilər")]
        public string Content { get; set; }

    }
}

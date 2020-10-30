using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), StringLength(100, ErrorMessage = "Maksimum uzunluq 100 simvol ola bilər")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız.")]
        public string Username { get; set; }
        public string userRole { get; set; }
        public string loggedUserRole { get; set; }
    }
}

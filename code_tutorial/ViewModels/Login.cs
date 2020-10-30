using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), DataType(DataType.Password)]
        public string Password { get; set; }
        public bool isChecked { get; set; }
    }
}

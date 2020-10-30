using code_tutorial.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.ViewModels
{
    public class Register
    {
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), MaxLength(150,ErrorMessage = "Maksimum uzunluq 150 simvol ola bilər")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), MaxLength(30,ErrorMessage = "Maksimum uzunluq 30 simvol ola bilər")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), EmailAddress(ErrorMessage = "Xahiş edirik doğru email daxil edəsiniz."), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), Compare(nameof(Password),ErrorMessage = "Təkrarlanmış şifrəniz doğru deyil"), DataType(DataType.Password)]
        public string RepeatPassword { get; set; }
        [Range(typeof(bool), "false", "true", ErrorMessage = "Xahiş edirik qaydalarla tanış olasınız."), MustBeTrue(ErrorMessage = "Xahiş edirik qaydalarla tanış olasınız.")]
        public bool isChecked { get; set; }
    }
}

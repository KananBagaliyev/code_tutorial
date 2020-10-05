using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.ViewModels
{
    public class ResetPasswordVM
    {
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), EmailAddress(ErrorMessage = "Xahiş edirik doğru email daxil edəsiniz."), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), Compare(nameof(Password), ErrorMessage = "Təkrarlanmış şifrəniz doğru deyil"), DataType(DataType.Password)]
        public string RepeatPassword { get; set; }

        public string Token { get; set; }
    }
}

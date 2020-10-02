using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace final_poject.ViewModels
{
    public class SendMessageVM
    {
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), EmailAddress(ErrorMessage = "Xahiş edirik doğru email daxil edəsiniz."), DataType(DataType.EmailAddress)]
        public string To { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız.")]
        public string Subject { get; set; }
        //[EmailAddress(ErrorMessage = "Xahiş edirik doğru email daxil edəsiniz."), DataType(DataType.EmailAddress)]
        //public IEnumerable<string> CC { get; set; }
        //[EmailAddress(ErrorMessage = "Xahiş edirik doğru email daxil edəsiniz."), DataType(DataType.EmailAddress)]
        //public IEnumerable<string> BCC { get; set; }

        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız.")]
        public string Message { get; set; }

    }
}

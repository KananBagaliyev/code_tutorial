using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xahiş edirik bu hissəni doldurasınız."), EmailAddress(ErrorMessage = "Xahiş edirik doğru email daxil edəsiniz."), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime SubscribedDate { get; set; }
    }
}

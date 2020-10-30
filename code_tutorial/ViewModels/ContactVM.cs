using code_tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.ViewModels
{
    public class ContactVM
    {
        public ContactGreeting Greeting { get; set; }
        public Contact Contact { get; set; }
    }
}

using code_tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.ViewModels
{
    public class AdminHeaderVM
    {
        public User User { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Contact> Messages { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officina.Models
{
    public class Workman
    {
        public long WorkmanId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }

        public List<Employement> Employements { get; set; }
    }
}

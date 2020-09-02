using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officina.Models
{
    public class Employement
    {
        public long OperationId { get; set; }
        public Operation Operation { get; set; }

        public long WorkmanId { get; set; }
        public Workman Workman { get; set; }
    }
}

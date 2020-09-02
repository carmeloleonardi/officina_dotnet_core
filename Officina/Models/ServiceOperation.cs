using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officina.Models
{
    public class ServiceOperation
    {
        public long OperationId { get; set; }
        public Operation Operation { get; set; }

        public long ServiceId { get; set; }
        public Service Service{ get; set; }
    }
}

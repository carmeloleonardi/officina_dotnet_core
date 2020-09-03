using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Officina.Models
{
    public class Operation
    {
        public long OperationId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }

        public long CarId { get; set; }
        public Car Car { get; set; }

        public List<Employement> Employements { get; set; }

        public List<PieceOperation> PieceOperations { get; set; }
        
        public List<ServiceOperation> ServiceOperations { get; set; }
    }
}

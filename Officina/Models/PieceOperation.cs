using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officina.Models
{
    public class PieceOperation
    {
        public long PieceId { get; set; }
        public Piece Piece { get; set; }

        public long OperationId { get; set; }
        public Operation Operation { get; set; }
    }
}

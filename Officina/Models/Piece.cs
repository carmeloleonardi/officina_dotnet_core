using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officina.Models
{
    public class Piece
    {
        public long PieceId { get; set; }
        public string Description { get; set; }
        public float Cost { get; set; }

        public List<PieceOperation> PieceOperations { get; set; }

    }
}

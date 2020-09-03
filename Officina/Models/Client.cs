using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Officina.Models
{
    [Table("client")]
    public class Client
    {
        public long ClientId { get; set; }
        //public ClientType ClientType { get; set; }
        public ClientDetail ClientDetail { get; set; }
        public List<Car> Cars { get; set; }

    }
}

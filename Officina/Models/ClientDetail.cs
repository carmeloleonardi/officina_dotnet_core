using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Officina.Models
{
    [Table("client_detail")]
    public class ClientDetail
    {
        public long ClientDetailId { get; set; }

        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }

        public long ClientId { get; set; }
        public Client Client { get; set; }
    }
}

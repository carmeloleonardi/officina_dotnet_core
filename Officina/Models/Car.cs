using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officina.Models
{
    public class Car
    {
        public long CarId { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public float Km { get; set; }

        public CertificateCar CertificateCar { get; set; }

        public Client Client { get; set; }
        
        public List<Operation> Operations { get; set; }
    }
}

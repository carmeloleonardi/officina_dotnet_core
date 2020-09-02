using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officina.Models
{
    public class Car
    {
        public string CarId { get; set; }   //targa
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public float Km { get; set; }

        public Client Client { get; set; }
        public CertificateCar CertificateCar { get; set; }

        public List<Operation> Operations { get; set; }
    }
}

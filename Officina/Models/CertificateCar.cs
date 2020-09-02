using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officina.Models
{
    public class CertificateCar //libretto
    {
        public string CertificateCarId { get; set; }    //Id Libretto
        public string ChassisNumber { get; set; }   //Id Telaio
        public string Year { get; set; }
        public float Kw { get; set; }
        public float EngineDisplacement { get; set; }
        public float EmptyMass { get; set; }

        public string CarId { get; set; }
        public Car Car { get; set; }
    }
}

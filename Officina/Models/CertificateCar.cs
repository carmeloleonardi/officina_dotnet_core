using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officina.Models
{
    public class CertificateCar //libretto
    {
        public long CertificateCarID { get; set; }

        public string CarPlate { get; set; }
        public string ChassisNumber { get; set; }
        public string Year { get; set; }
        public float Kw { get; set; }
        public float EngineDisplacement { get; set; }
        public float EmptyMass { get; set; }

        public long CarId { get; set; }
        public Car Car { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officina.Models
{
    public class Service
    {
        public long ServiceId { get; set; }
        public string Description { get; set; }
        public float Cost { get; set; }

        public List<ServiceOperation> ServiceOperations { get; set; }
    }
}

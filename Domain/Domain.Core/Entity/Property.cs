using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Entity
{
    public class Property
    {
        public string Address { get; set; }
        public string AgencyCode { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}

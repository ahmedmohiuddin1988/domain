using Domain.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.API.Model
{
    public class PropertyComparer
    {
        public Property DatabaseProperty { get; set; }
        public Property AgencyProperty { get; set; }

        public string Provider { get; set; }
    }
}

using Domain.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.API.Model
{
    public class PropertyComparerDTO
    {
        public PropertyDTO DatabaseProperty { get; set; }
        public PropertyDTO AgencyProperty { get; set; }

        public string Provider { get; set; }
    }
}

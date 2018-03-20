using System;
using System.Collections.Generic;
using System.Text;
using Domain.Core.Entity;
using Domain.Core.Util;

namespace Domain.Core.Business.Agency
{
    public class LREAgency : PropertyMatcher
    {
        private const double maxDistanceInMeters = 200;
        public override string AgencyCode
        {
            get
            {
                return "LRE";
            }
        }

        public override bool IsMatch(Property ag_property, Property db_property)
        {
            var distance = Helper.
                GetDistance(ag_property.Latitude, ag_property.Longitude,
                                                    db_property.Latitude, db_property.Longitude);
            return (distance <= maxDistanceInMeters) && (ag_property.AgencyCode == db_property.AgencyCode);
        }
    }
}

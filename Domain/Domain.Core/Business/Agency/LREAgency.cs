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

        public override bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            var distance = Helper.
                GetDistanceByGeoCoordinatesInMeters(agencyProperty.Latitude, agencyProperty.Longitude,
                                                    databaseProperty.Latitude, databaseProperty.Longitude);
            return (distance <= maxDistanceInMeters) && (agencyProperty.AgencyCode == databaseProperty.AgencyCode);
        }
    }
}

using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Util
{
    public static class Helper
    {
        /// <summary>
        /// Get the distance between two Geo Coordinates in Meters
        /// </summary>
        /// <param name="latitude1"></param>
        /// <param name="longitude1"></param>
        /// <param name="latitude2"></param>
        /// <param name="longitude2"></param>
        /// <returns>In meters</returns>
        public static double GetDistanceByGeoCoordinatesInMeters(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            var sCoord = new GeoCoordinate(latitude1, longitude1);
            var eCoord = new GeoCoordinate(latitude1, longitude1);
            return sCoord.GetDistanceTo(eCoord);
        }
    }
}

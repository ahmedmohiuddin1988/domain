using System;
using System.Collections.Generic;
using System.Text;
using GeoCoordinatePortable;

namespace Domain.Core.Util
{
    public static class Helper
    {
        /// <summary>
        /// Get the distance between two Geo Coordinates in Meters
        /// </summary>
        /// <param name="ag_lat"></param>
        /// <param name="ag_long"></param>
        /// <param name="db_lat"></param>
        /// <param name="db_long"></param>
        /// <returns>In meters</returns>
        public static double GetDistance(double ag_lat, double ag_long, double db_lat, double db_long)
        {
            var sCoord = new GeoCoordinate(ag_lat, ag_long);
            var eCoord = new GeoCoordinate(db_lat, db_long);
            return sCoord.GetDistanceTo(eCoord);
        }
    }
}

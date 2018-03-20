using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain.Core.Entity;
using System.Text.RegularExpressions;

namespace Domain.Core.Business.Agency
{
    public class CREAgency : PropertyMatcher
    {
        Regex regex = new Regex(@"\W+", RegexOptions.Compiled);
        public override string AgencyCode
        {
            get
            {
                return "CRE";
            }
        }

        public override bool IsMatch(Property ag_property, Property db_property)
        {
            IEnumerable<string> agencyNameWords = regex.Split(ag_property.Name).Reverse();
            var agencyName = string.Join(" ", agencyNameWords);

            var databaseNameWords = regex.Split(db_property.Name);
            var databaseAgencyName = string.Join(" ", databaseNameWords);

            return agencyName.Equals(databaseAgencyName, StringComparison.OrdinalIgnoreCase);
        }
    }
}

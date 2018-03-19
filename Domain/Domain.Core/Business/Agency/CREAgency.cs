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

        public override bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            IEnumerable<string> agencyNameWords = regex.Split(agencyProperty.Name).Reverse();
            var agencyName = string.Join(" ", agencyNameWords);

            var databaseNameWords = regex.Split(databaseProperty.Name);
            var databaseAgencyName = string.Join(" ", databaseNameWords);

            return agencyName.Equals(databaseAgencyName, StringComparison.OrdinalIgnoreCase);
        }
    }
}

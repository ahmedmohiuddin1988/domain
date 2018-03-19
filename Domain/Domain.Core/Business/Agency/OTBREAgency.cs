using System;
using System.Collections.Generic;
using System.Text;
using Domain.Core.Entity;
using System.Text.RegularExpressions;

namespace Domain.Core.Business.Agency
{
    public class OTBREAgency : PropertyMatcher
    {
        private Regex regx = new Regex(@"[^\w]", RegexOptions.Compiled);
        public override string AgencyCode
        {
            get
            {
                return "OTBRE";
            }
        }
        public override bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            var agencyAddress = regx.Replace(agencyProperty.Address, "");
            var agencyName = regx.Replace(agencyProperty.Name, "");
            var databasAddress = regx.Replace(databaseProperty.Address, "");
            var databasName = regx.Replace(databaseProperty.Name, "");

            return
                agencyAddress.Equals(databasAddress, StringComparison.OrdinalIgnoreCase) &&
                agencyName.Equals(databasName, StringComparison.OrdinalIgnoreCase);
        }
    }
}

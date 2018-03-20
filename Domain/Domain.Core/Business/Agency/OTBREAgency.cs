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
        public override bool IsMatch(Property ag_property, Property db_property)
        {
            var agencyAddress = regx.Replace(ag_property.Address, "");
            var agencyName = regx.Replace(ag_property.Name, "");
            var databasAddress = regx.Replace(db_property.Address, "");
            var databasName = regx.Replace(db_property.Name, "");

            return
                agencyAddress.Equals(databasAddress, StringComparison.OrdinalIgnoreCase) &&
                agencyName.Equals(databasName, StringComparison.OrdinalIgnoreCase);
        }
    }
}

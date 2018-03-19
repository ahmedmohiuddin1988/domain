using System;
using System.Collections.Generic;
using System.Text;
using Domain.Core.Entity;

namespace Domain.Core.Business.Agency
{
    public class CREAgency : PropertyMatcher
    {
        public override string AgencyCode
        {
            get
            {
                return "CRE";
            }
        }

        public override bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            // logic goes here
            return false;
        }
    }
}

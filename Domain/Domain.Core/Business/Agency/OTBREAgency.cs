﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Core.Entity;

namespace Domain.Core.Business.Agency
{
    public class OTBREAgency : PropertyMatcher
    {
        public override string AgencyCode
        {
            get
            {
                return "LRE";
            }
        }
        public override bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            //logic goes here
            return false;
        }
    }
}
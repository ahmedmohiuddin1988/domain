using Domain.Core.Business.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Core.Entity;

namespace Domain.Core.Business
{
    public abstract class PropertyMatcher : IPropertyMatcher
    {
        public abstract string AgencyCode { get; }
        public abstract bool IsMatch(Property agencyProperty, Property databaseProperty);        
    }
}

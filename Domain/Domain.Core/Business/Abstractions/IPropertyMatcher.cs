using Domain.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Business.Abstractions
{
    public interface IPropertyMatcher
    {
        bool IsMatch(Property agencyProperty, Property databaseProperty);
    }

}

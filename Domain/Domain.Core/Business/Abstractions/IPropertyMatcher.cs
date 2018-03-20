using Domain.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Business.Abstractions
{
    public interface IPropertyMatcher
    {
        bool IsMatch(Property ag_property, Property db_property);
    }

}

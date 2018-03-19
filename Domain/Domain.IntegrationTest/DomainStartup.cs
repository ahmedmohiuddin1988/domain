using Domain.API;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IntegrationTest
{
    public class DomainStartup: Startup
    {
        public DomainStartup(IConfiguration env) : base(env)
        {
        }
    }
}

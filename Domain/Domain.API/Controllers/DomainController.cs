using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; 
using Domain.API.Model;
using Domain.Core.Business;
using System.Net;

namespace Domain.API.Controllers
{
    [Route("api/[controller]")]
    public class DomainController : Controller
    {       
        // POST api/values
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult MatchPropert([FromBody]PropertyComparer comparer)
        {
            if (comparer == null)
            {
                return BadRequest();
            }

            if (comparer.AgencyProperty == null || comparer.DatabaseProperty == null || string.IsNullOrEmpty(comparer.Provider))
            {
                return StatusCode((int)HttpStatusCode.NotAcceptable);
            }
            
            var provider = AgencyFactory.GetProvider(comparer.Provider);

            bool result =  provider.IsMatch(comparer.AgencyProperty, comparer.DatabaseProperty);

            return Ok(result);
        }         
    }
}

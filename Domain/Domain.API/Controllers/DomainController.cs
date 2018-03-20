using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; 
using Domain.API.Model;
using Domain.Core.Business;
using System.Net;
using AutoMapper;
using Domain.Core.Entity;
using Microsoft.Extensions.Configuration;

namespace Domain.API.Controllers
{
    [Route("api/[controller]")]
    public class DomainController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public DomainController(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }
        /// <summary>
        /// Match between agency property & database property.
        /// </summary>
        /// <param name="PropertyComparerDTO"></param>   
        /// <returns>bool response with OK status code</returns>
        /// <response code="200">Returns the result</response>
        /// <response code="400">If the propertyComparerDTO or its property is null</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult MatchPropert([FromBody]PropertyComparerDTO comparer)
        {
                if (comparer == null)
                {
                    return BadRequest();
                }

                if (comparer.AgencyProperty == null || comparer.DatabaseProperty == null || string.IsNullOrEmpty(comparer.Provider))
                {
                    return BadRequest();
                }

                var provider = AgencyFactory.GetProvider(comparer.Provider);
                if (provider == null)
                {
                    return BadRequest($"{comparer.Provider} is invalid provider");
                }
                bool result = provider.IsMatch(_mapper.Map<Property>(comparer.AgencyProperty), _mapper.Map<Property>(comparer.DatabaseProperty));

                return Ok(result);
            
        }         
    }
}

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

namespace Domain.API.Controllers
{
    [Route("api/[controller]")]
    public class DomainController : Controller
    {
        private readonly IMapper _mapper;

        public DomainController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult MatchPropert([FromBody]PropertyComparerDTO comparer)
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

            bool result =  provider.IsMatch(_mapper.Map<Property>(comparer.AgencyProperty), _mapper.Map<Property>(comparer.DatabaseProperty));

            return Ok(result);
        }         
    }
}

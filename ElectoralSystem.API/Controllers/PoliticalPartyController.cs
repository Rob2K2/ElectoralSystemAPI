using AutoMapper;
using ElectoralSystem.API.Core.DTOs;
using ElectoralSystem.API.Core.Handlers;
using ElectoralSystem.API.Filter;
using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ElectoralSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PoliticalPartyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PoliticalPartyController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPoliticalParty()
        {
            var middle = new GetAllPoliticalPartyMiddleData();
            var response = await _mediator.Send(middle);
            
            return Ok(response);
        }


        [HttpGet("ID")]
        public async Task<IActionResult> GetIdPoliticalParty(Guid guid)
        {
            var middle = new GetIdPoliticalPartyMiddleData(guid);
            var response = await _mediator.Send(middle);

            return Ok(response);
        }


        [ServiceFilter(typeof(ValidatePoliticalPartyFilter))]
        [HttpPost]
        public async Task<IActionResult> CreatePoliticalParty(PoliticalPartyDto politicalPartyDto)
        {
            PoliticalParty politicalPartyInput = _mapper.Map<PoliticalParty>(politicalPartyDto);
            var middle = new CreatePoliticalPartyMiddleData(politicalPartyInput);
            var response = await _mediator.Send(middle);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePoliticalParty(PoliticalParty politicalParty)
        { 
            var middle = new DeletePoliticalPartyMiddleData(politicalParty);
            var response = await _mediator.Send(middle);
            return Ok(response);
        }
    }
}

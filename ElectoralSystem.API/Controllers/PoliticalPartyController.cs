using AutoMapper;
using ElectoralSystem.API.Core.DTOs;
using ElectoralSystem.API.Core.Handlers;
using ElectoralSystem.API.Filter;
using ElectoralSystem.API.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            var responseDto = _mapper.Map<IEnumerable<PoliticalPartyResponseDto>>(response);
            
            return Ok(responseDto);
        }


        [HttpGet("ID")]
        public async Task<IActionResult> GetIdPoliticalParty(Guid guid)
        {
            var middle = new GetIdPoliticalPartyMiddleData(guid);
            var response = await _mediator.Send(middle);
            var responseDto = _mapper.Map<PoliticalPartyResponseDto>(response);

            return Ok(responseDto);
        }


        [ServiceFilter(typeof(ValidatePoliticalPartyFilter))]
        [HttpPost]
        public async Task<IActionResult> CreatePoliticalParty(CreatePoliticalPartyDto createPoliticalPartyDto)
        {
            var politicalPartyInput = _mapper.Map<PoliticalParty>(createPoliticalPartyDto);
            var middle = new CreatePoliticalPartyMiddleData(politicalPartyInput);
            var response = await _mediator.Send(middle);
            var responseDto = _mapper.Map<PoliticalPartyResponseDto>(response);

            return Ok(responseDto);
        }

        [ServiceFilter(typeof(ValidatePoliticalPartyFilter))]
        [HttpPut]
        public async Task<IActionResult> UpdatePoliticalParty(UpdatePoliticalPartyDto updatePoliticalPartyDto)
        {
            var politicalPartyInput = _mapper.Map<PoliticalParty>(updatePoliticalPartyDto);
            var middle = new UpdatePoliticalPartyMiddleData(politicalPartyInput);
            var response = await _mediator.Send(middle);

            return Ok(new { rowsAffected = response });
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

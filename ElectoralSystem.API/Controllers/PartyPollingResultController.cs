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
    public class PartyPollingResultController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PartyPollingResultController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPartyPollingResult()
        {
            var middle = new GetAllPartyPollingResultMiddleData();
            var response = await _mediator.Send(middle);
            var responseDto = _mapper.Map<IEnumerable<PartyPollingResultResponseDto>>(response);
            
            return Ok(responseDto);
        }


        [HttpGet("ID")]
        public async Task<IActionResult> GetIdPartyPollingResult(Guid guid)
        {
            var middle = new GetIdPartyPollingResultMiddleData(guid);
            var response = await _mediator.Send(middle);
            var responseDto = _mapper.Map<PartyPollingResultResponseDto>(response);

            return Ok(responseDto);
        }


        [ServiceFilter(typeof(ValidatePartyPollingResultFilter))]
        [HttpPost]
        public async Task<IActionResult> CreatePartyPollingResult(CreatePartyPollingResultDto createPartyPollingResultDto)
        {
            var partyPollingResultInput = _mapper.Map<PartyPollingResult>(createPartyPollingResultDto);
            var middle = new CreatePartyPollingResultMiddleData(partyPollingResultInput);
            var response = await _mediator.Send(middle);
            var responseDto = _mapper.Map<PartyPollingResultResponseDto>(response);

            return Ok(responseDto);
        }

        [ServiceFilter(typeof(ValidatePartyPollingResultFilter))]
        [HttpPut]
        public async Task<IActionResult> UpdatePartyPollingResult(UpdatePartyPollingResultDto updatePartyPollingResultDto)
        {
            var partyPollingResultInput = _mapper.Map<PartyPollingResult>(updatePartyPollingResultDto);
            var middle = new UpdatePartyPollingResultMiddleData(partyPollingResultInput);
            var response = await _mediator.Send(middle);

            return Ok(new { rowsAffected = response });
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePartyPollingResult(PartyPollingResult partyPollingResult)
        { 
            var middle = new DeletePartyPollingResultMiddleData(partyPollingResult);
            var response = await _mediator.Send(middle);
            return Ok(response);
        }
    }
}


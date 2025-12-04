using AutoMapper;
using ElectoralSystem.API.Core.DTOs;
using ElectoralSystem.API.Core.Handlers;
using ElectoralSystem.API.Filter;
using ElectoralSystem.API.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectoralSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PollingStationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PollingStationController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPollingStation()
        {
            var middle = new GetAllPollingStationMiddleData();
            var response = await _mediator.Send(middle);
            var responseDto = _mapper.Map<IEnumerable<PollingStationResponseDto>>(response);
            
            return Ok(responseDto);
        }


        [HttpGet("ID")]
        public async Task<IActionResult> GetIdPollingStation(Guid guid)
        {
            var middle = new GetIdPollingStationMiddleData(guid);
            var response = await _mediator.Send(middle);
            var responseDto = _mapper.Map<PollingStationResponseDto>(response);

            return Ok(responseDto);
        }


        [Authorize]
        [ServiceFilter(typeof(ValidatePollingStationFilter))]
        [HttpPost]
        public async Task<IActionResult> CreatePollingStation(CreatePollingStationDto createPollingStationDto)
        {
            var pollingStationInput = _mapper.Map<PollingStation>(createPollingStationDto);
            var middle = new CreatePollingStationMiddleData(pollingStationInput);
            var response = await _mediator.Send(middle);
            var responseDto = _mapper.Map<PollingStationResponseDto>(response);

            return Ok(responseDto);
        }

        [Authorize]
        [ServiceFilter(typeof(ValidatePollingStationFilter))]
        [HttpPut]
        public async Task<IActionResult> UpdatePollingStation(UpdatePollingStationDto updatePollingStationDto)
        {
            var pollingStationInput = _mapper.Map<PollingStation>(updatePollingStationDto);
            var middle = new UpdatePollingStationMiddleData(pollingStationInput);
            var response = await _mediator.Send(middle);

            return Ok(new { rowsAffected = response });
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeletePollingStation(PollingStation pollingStation)
        { 
            var middle = new DeletePollingStationMiddleData(pollingStation);
            var response = await _mediator.Send(middle);
            return Ok(response);
        }
    }
}


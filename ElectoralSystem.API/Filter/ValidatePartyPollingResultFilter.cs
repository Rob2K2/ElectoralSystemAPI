using ElectoralSystem.API.Core.DTOs;
using ElectoralSystem.API.Error;
using ElectoralSystem.API.Error.Bussiness;
using ElectoralSystem.API.Error.Logs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace ElectoralSystem.API.Filter
{
    public class ValidatePartyPollingResultFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public ValidatePartyPollingResultFilter(ILogger logger)
        {
            _logger = logger;
        }
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("createPartyPollingResultDto", out var createValue) && createValue is CreatePartyPollingResultDto createDto)
            {
                if (createDto.PollStationId == Guid.Empty)
                {
                    _logger.Log(Severity.WARNING, "Validation failed: Empty PollStationId when creating a party polling result.");
                    throw new BussinesException("The PollStationId is required.");
                }

                if (createDto.PoliticalPartyId == Guid.Empty)
                {
                    _logger.Log(Severity.WARNING, "Validation failed: Empty PoliticalPartyId when creating a party polling result.");
                    throw new BussinesException("The PoliticalPartyId is required.");
                }

                if (createDto.VotesValid < 0 || createDto.VotesBlank < 0 || createDto.VotesNull < 0)
                {
                    _logger.Log(Severity.WARNING, "Validation failed: Negative votes when creating a party polling result.");
                    throw new BussinesException("Votes cannot be negative.");
                }
            }

            if (context.ActionArguments.TryGetValue("updatePartyPollingResultDto", out var updateValue) && updateValue is UpdatePartyPollingResultDto updateDto)
            {
                if (updateDto.Id == Guid.Empty)
                {
                    _logger.Log(Severity.WARNING, "Validation failed: Empty Id when updating a party polling result.");
                    throw new BussinesException("The Id is required for updating.");
                }

                if (updateDto.PollStationId == Guid.Empty)
                {
                    _logger.Log(Severity.WARNING, "Validation failed: Empty PollStationId when updating a party polling result.");
                    throw new BussinesException("The PollStationId is required.");
                }

                if (updateDto.PoliticalPartyId == Guid.Empty)
                {
                    _logger.Log(Severity.WARNING, "Validation failed: Empty PoliticalPartyId when updating a party polling result.");
                    throw new BussinesException("The PoliticalPartyId is required.");
                }

                if (updateDto.VotesValid < 0 || updateDto.VotesBlank < 0 || updateDto.VotesNull < 0)
                {
                    _logger.Log(Severity.WARNING, "Validation failed: Negative votes when updating a party polling result.");
                    throw new BussinesException("Votes cannot be negative.");
                }
            }
        }
        
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}


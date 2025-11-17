using ElectoralSystem.API.Core.DTOs;
using ElectoralSystem.API.Error;
using ElectoralSystem.API.Error.Bussiness;
using ElectoralSystem.API.Error.Logs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace ElectoralSystem.API.Filter
{
    public class ValidatePoliticalPartyFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public ValidatePoliticalPartyFilter(ILogger logger)
        {
            _logger = logger;
        }
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("createPoliticalPartyDto", out var createValue) && createValue is CreatePoliticalPartyDto createDto)
            {
                if (string.IsNullOrWhiteSpace(createDto.Name) || string.IsNullOrWhiteSpace(createDto.Acronym))
                {
                    _logger.Log(Severity.WARNING, "Validation failed: Empty name or acronym when creating a political party.");

                    throw new BussinesException("The name and acronym are required.");
                }
            }

            if (context.ActionArguments.TryGetValue("updatePoliticalPartyDto", out var updateValue) && updateValue is UpdatePoliticalPartyDto updateDto)
            {
                if (updateDto.Id == Guid.Empty)
                {
                    _logger.Log(Severity.WARNING, "Validation failed: Empty Id when updating a political party.");

                    throw new BussinesException("The Id is required for updating.");
                }

                if (string.IsNullOrWhiteSpace(updateDto.Name) || string.IsNullOrWhiteSpace(updateDto.Acronym))
                {
                    _logger.Log(Severity.WARNING, "Validation failed: Empty name or acronym when updating a political party.");

                    throw new BussinesException("The name and acronym are required.");
                }
            }
        }
        
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}

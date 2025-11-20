using ElectoralSystem.API.Core.DTOs;
using ElectoralSystem.API.Error;
using ElectoralSystem.API.Error.Bussiness;
using ElectoralSystem.API.Error.Logs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace ElectoralSystem.API.Filter
{
    public class ValidatePollingStationFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public ValidatePollingStationFilter(ILogger logger)
        {
            _logger = logger;
        }
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("createPollingStationDto", out var createValue) && createValue is CreatePollingStationDto createDto)
            {
                if (string.IsNullOrWhiteSpace(createDto.Number) || string.IsNullOrWhiteSpace(createDto.Status))
                {
                    _logger.Log(Severity.WARNING, "Validation failed: Empty number or status when creating a polling station.");

                    throw new BussinesException("The number and status are required.");
                }

                if (createDto.RegisteredVoters < 0)
                {
                    _logger.Log(Severity.WARNING, "Validation failed: Negative registered voters when creating a polling station.");

                    throw new BussinesException("Registered voters must be a positive number.");
                }
            }

            if (context.ActionArguments.TryGetValue("updatePollingStationDto", out var updateValue) && updateValue is UpdatePollingStationDto updateDto)
            {
                if (updateDto.Id == Guid.Empty)
                {
                    _logger.Log(Severity.WARNING, "Validation failed: Empty Id when updating a polling station.");

                    throw new BussinesException("The Id is required for updating.");
                }

                if (string.IsNullOrWhiteSpace(updateDto.Number) || string.IsNullOrWhiteSpace(updateDto.Status))
                {
                    _logger.Log(Severity.WARNING, "Validation failed: Empty number or status when updating a polling station.");

                    throw new BussinesException("The number and status are required.");
                }

                if (updateDto.RegisteredVoters < 0)
                {
                    _logger.Log(Severity.WARNING, "Validation failed: Negative registered voters when updating a polling station.");

                    throw new BussinesException("Registered voters must be a positive number.");
                }
            }
        }
        
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}


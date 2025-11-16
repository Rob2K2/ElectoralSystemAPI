using ElectoralSystem.API.Core.DTOs;
using ElectoralSystem.API.Error.Bussiness;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ElectoralSystem.API.Filter
{
    public class ValidatePoliticalPartyFilter : IActionFilter
    {
        private readonly ILogger<ErrorFilter> _logger;

        public ValidatePoliticalPartyFilter(ILogger<ErrorFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("politicalPartyDto", out var value) && value is PoliticalPartyDto dto)
            {
                if (string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.Acronym))
                {
                    _logger.LogWarning("Validation failed: Empty name or acronym when creating a political party.");

                    throw new BussinesException("The name and acronym are required.");
                }
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}

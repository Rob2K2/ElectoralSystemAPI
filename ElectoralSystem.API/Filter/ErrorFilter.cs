namespace ElectoralSystem.API.Filter
{
    using ElectoralSystem.API.Error;
    using ElectoralSystem.API.Error.Bussiness;
    using ElectoralSystem.API.Error.Critical;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    

    public class ErrorFilter : IActionFilter, IExceptionFilter
    {
        private readonly ILogger<ErrorFilter> _logger;

        public ErrorFilter(ILogger<ErrorFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            _logger.LogInformation($"[START] Action: {actionName}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            _logger.LogInformation($"[END] Action: {actionName}");
        }

        public void OnException(ExceptionContext context)
        {
            AbstractException exception;

            if (context.Exception is AbstractException custom)
            {
                exception = custom;

            }
            else
            {
                exception = new CriticalException(context.Exception);
            }

            exception.LogException();

            var statusCode = exception is BussinesException ? 400 : 500;

            context.Result = new ObjectResult(new
            {
                error = exception.FriendlyMessage
            })
            {
                StatusCode = statusCode
            };

            context.ExceptionHandled = true;
        }

    }
}

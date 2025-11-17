namespace ElectoralSystem.API.Filter
{
    using ElectoralSystem.API.Error;
    using ElectoralSystem.API.Error.Bussiness;
    using ElectoralSystem.API.Error.Critical;
    using ElectoralSystem.API.Error.Logs;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    

    public class ErrorFilter : IActionFilter, IExceptionFilter
    {
        private readonly ILogger _logger;

        public ErrorFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            _logger.Log(Severity.INFORMATION, $"[START] Action: {actionName}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            _logger.Log(Severity.INFORMATION, $"[END] Action: {actionName}");
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

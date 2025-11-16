namespace ElectoralSystem.API.Error.Critical
{
    public class CriticalException : AbstractException
    {
        public CriticalException(Exception exception)
            : base("An Internal Error Ocurred", exception, Severity.ERROR) 
        { }

        public override void LogException()
        {
            var currentException = InnerException;
            do
            {
                LogMessage($"Message: {currentException.Message}. trace {currentException.StackTrace}");
                currentException = currentException.InnerException;
            } while (currentException != null);
        }
    }
}

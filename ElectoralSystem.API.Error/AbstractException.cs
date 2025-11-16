using ElectoralSystem.API.Error.Logs;

namespace ElectoralSystem.API.Error
{
    public abstract class AbstractException : Exception
    {
        public string FriendlyMessage { get; protected set; }
        public new Exception InnerException { get; set; }
        protected Severity Severity { get; }
        protected ILogger Logger { get; }

        protected AbstractException(string friendlyMessage, Severity severity)
        {
            FriendlyMessage = friendlyMessage;
            Severity = severity;
            Logger = new Logger();
        }

        protected AbstractException(
            string friendlyMessage,
            Exception innerException,
            Severity severity) : this(friendlyMessage, severity)
        {
            InnerException = innerException;
        }

        public AbstractException(string? message) : base(message)
        {
        }

        protected void LogMessage(string message)
        {
            Logger.Log(Severity, message);
        }

        public abstract void LogException();
    }
}

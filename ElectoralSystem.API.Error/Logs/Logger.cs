using log4net;

namespace ElectoralSystem.API.Error.Logs
{
    public class Logger : ILogger
    {
        private readonly ILog _logger;

        public Logger()
        {
            _logger = LogManager.GetLogger(typeof(Logger));
        }
        public void Log(Severity severity, string message)
        {
            switch (severity)
            {
                case Severity.DEBUG:
                    _logger.Debug(message);
                    break;
                case Severity.INFORMATION:
                    _logger.Info(message);
                    break;
                case Severity.WARNING:
                    _logger.Warn(message);
                    break;
                case Severity.ERROR:
                    _logger.Error(message);
                    break;
                case Severity.FATAL:
                    _logger.Fatal(message);
                    break;
            }
        }
    }
}

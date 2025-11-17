namespace ElectoralSystem.API.Error.Logs
{
    public interface ILogger
    {
        void Log(Severity severity, string message);
    }
}

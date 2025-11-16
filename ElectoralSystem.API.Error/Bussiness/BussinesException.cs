namespace ElectoralSystem.API.Error.Bussiness
{
    public class BussinesException : AbstractException
    {

        public BussinesException(string friendlyMessage) 
            : base(friendlyMessage, Severity.WARNING) { }
        
        public override void LogException()
        {
            LogMessage(FriendlyMessage);
        }


    }
}

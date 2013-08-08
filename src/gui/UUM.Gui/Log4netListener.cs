using Catel.Logging;

public class Log4netListener : LogListenerBase
{
    Catel.Logging.ILog log = Catel.Logging.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
 
    public override void Debug(ILog log, string message)
    {
        log.DebugWithData(message);
    }
 
    public override void Info(ILog log, string message)
    {
        log.InfoWithData(message);
    }
 
    public override void Warning(ILog log, string message)
    {
        log.Warning(message);
    }
 
    public override void Error(ILog log, string message)
    {
        log.ErrorWithData(message);
    }
}
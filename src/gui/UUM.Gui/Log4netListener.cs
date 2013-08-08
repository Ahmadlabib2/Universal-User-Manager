using Catel.Logging;

public class Log4netListener : LogListenerBase
{
    log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
 
    public override void Debug(ILog log, string message)
    {
        Log.Debug(message);
    }
 
    public override void Info(ILog log, string message)
    {
        Log.Info(message);
    }
 
    public override void Warning(ILog log, string message)
    {
        Log.Warn(message);
    }
 
    public override void Error(ILog log, string message)
    {
        Log.Error(message);
    }
}
using Catel.Logging;

namespace UUM.Gui.Logging
{
	public class Log4netListener : LogListenerBase
	{
		private readonly log4net.ILog Log = log4net.LogManager.GetLogger("UUM");
		
		protected override void Debug(ILog log, string message, object extraData)
		{
			Log.Debug(message);
		}
		
		protected override void Info(ILog log, string message, object extraData)
		{
			Log.Info(message);
		}
		
		protected override void Warning(ILog log, string message, object extraData)
		{
			Log.Warn(message);
		}
		
		protected override void Error(ILog log, string message, object extraData)
		{
			Log.Error(message);
		}
	}
}

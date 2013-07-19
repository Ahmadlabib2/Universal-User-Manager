using System.Collections.Generic;
using System.Diagnostics;
using log4net;

namespace CatenaLogic.Diagnostics
{
	public class Log4netTraceListener : TraceListener
	{
	
		private const string ItemsSourceTimingIssueTrace = "ContentAlignment; DataItem=null;";
	

	
		private static readonly ILog _log = LogManager.GetLogger("TraceOutput");
		/// <summary>
		/// Initializes <see cref="Log4netTraceListener"/>class that we added in the app.conf .
		/// </summary>
		public Log4netTraceListener()
		{
			//default values
			Name = "Log4net Trace Listener";
			ActiveTraceLevel = TraceLevel.Info;

			// Create additional trace sources list
			TraceSourceCollection = new List<TraceSource>();

			TraceSourceCollection.Add(PresentationTraceSources.DataBindingSource);
			TraceSourceCollection.Add(PresentationTraceSources.DependencyPropertySource);
			TraceSourceCollection.Add(PresentationTraceSources.MarkupSource);
			TraceSourceCollection.Add(PresentationTraceSources.ResourceDictionarySource);

			// Subscribe to all trace sources
			foreach (TraceSource traceSource in TraceSourceCollection)
			{
				traceSource.Listeners.Add(this);
			}
		}
		private List<TraceSource> TraceSourceCollection { get; set; }

	
		public TraceLevel ActiveTraceLevel { get; set; }
		

	
		public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
		{
			// Call overload
			TraceEvent(eventCache, source, eventType, id, string.Format(format, args));
		}


		public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
		{
			// Should we ignore this line?
			if (message.Contains(ItemsSourceTimingIssueTrace)) return;

			// Check the type
			switch (eventType)
			{
				case TraceEventType.Error:
					if ((ActiveTraceLevel == TraceLevel.Error) ||
						 (ActiveTraceLevel == TraceLevel.Warning) ||
						 (ActiveTraceLevel == TraceLevel.Info) ||
						 (ActiveTraceLevel == TraceLevel.Verbose))
					{
						_log.Error(message);
					}
					break;

				case TraceEventType.Warning:
					if ((ActiveTraceLevel == TraceLevel.Warning) ||
						 (ActiveTraceLevel == TraceLevel.Info) ||
						 (ActiveTraceLevel == TraceLevel.Verbose))
					{
						_log.Warn(message);
					}
					break;

				case TraceEventType.Information:
					if ((ActiveTraceLevel == TraceLevel.Info) ||
						 (ActiveTraceLevel == TraceLevel.Verbose))
					{
						_log.Info(message);
					}
					break;
				default:
					if (ActiveTraceLevel == TraceLevel.Verbose)
					{
						_log.Debug(message);
					}
					break;
			}
		}

		public override void Write(string message)
		{
		
			WriteLine(message);
		}
		public override void WriteLine(string message)
		{
			
			if (ActiveTraceLevel == TraceLevel.Verbose)
			{
				_log.Debug(message);
			}
		}
	
	}
}

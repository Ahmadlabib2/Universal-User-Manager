using System.IO;
using Catel;
using Catel.Logging;

//TODO:
// We want a log4net Listener, which allows the configurability of log4net,
// not just an own file listener
// the backends can be almost everything that is supported by log4net through
// app.config, this is needlessly restricting the operation modi.
// see https://catelproject.atlassian.net/wiki/display/CTL/Log4net

// just a short review on the existing code, needs to be rewritten
// according to the goal explained above.

//TODO: Move to a Services subdirectory
//TODO: Add a proper namespace
public class FileLogListener : LogListenerBase
{
    private readonly TextWriter _textWriter;
 
    public FileLogListener(string fileName)
    {
        Argument.IsNotNullOrWhitespace("fileName", fileName);
        FileName = fileName;
        //TODO: implement IDisposable to dispose this
        _textWriter = new StreamWriter(fileName, true);
    }
 
    public string FileName { get; private set; }
 
    //TODO: is obsolete, use the Write(ILog log, string message, LogEvent logEvent, object extraData) overload
    public override void Write(ILog log, string message, LogEvent logEvent)
    {
        _textWriter.WriteLine(message);
    }
}


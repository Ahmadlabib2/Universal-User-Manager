using System.IO;
using Catel;
using Catel.Logging;

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


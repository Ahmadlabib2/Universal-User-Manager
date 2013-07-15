using System.IO;
using Catel;
using Catel.Logging;

public class FileLogListener : LogListenerBase
{
    private readonly TextWriter _textWriter;
 
    public FileLogListener(string fileName)
    {
        Argument.IsNotNullOrWhitespace("fileName", fileName);
        FileName = fileName;
 
        _textWriter = new StreamWriter(fileName, true);
    }
 
    public string FileName { get; private set; }
 
    public override void Write(ILog log, string message, LogEvent logEvent)
    {
        _textWriter.WriteLine(message);
    }
}


using Logger;

public class Program
{
    private static void Main(string[] args)
    {
        var chainHandler = new InfoLogHandler(new DebugLogHandler(new WarningLogHandler((new ErrorLogHandler(null)))));

        chainHandler.Log(LogHandler.Warning, "It a warning message");
        chainHandler.Log(LogHandler.Info, "info");

    }
}
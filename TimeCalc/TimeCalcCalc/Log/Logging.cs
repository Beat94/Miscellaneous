using System.Dynamic;

namespace TimeCalcCalc.Log;
public class Logging
{
    public List<LogEntry> logEntries = new List<LogEntry>();

    public void newEntry(LogType logType, string Message)
    {
        logEntries.Add(new LogEntry(logType, Message));
    }

    public string getLog()
    {
        string output = "";

        foreach (LogEntry logEntry in logEntries)
        {
            output += logEntry.dateTime + "\t" + logEntry.logType.ToString() + "\t" + logEntry.message + "\n";
        }

        return output;
    }
}
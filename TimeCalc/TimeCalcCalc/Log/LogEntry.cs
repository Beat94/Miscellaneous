namespace TimeCalcCalc.Log;
public class LogEntry
{
    public DateTime dateTime{get;}
    public LogType logType{get;}
    public string message{get;}

    public LogEntry(LogType logType, string message)
    {
        this.dateTime = DateTime.Now;
        this.logType = logType;
        this.message = message;
    }
}
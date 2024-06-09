using TimeCalcCalc.Models;

namespace TimeCalcCalc;

public class OutputHandler
{
    public List<Output> outputList = new List<Output>();
    public void addEntry(string filename, string line, double time)
    {
        outputList.Add(new Output(){
            Filename = filename, 
            Line = line, 
            Time = time});
    }

    public string getEntries()
    {
        string output = "";

        foreach (Output outputOut in outputList)
        {
            output +=  outputOut.Filename + "\t" + outputOut.Line + "\t" + outputOut.Time.ToString() + "\n";
        }

        return output;
    }
}
using TimeCalcCalc.Models;

namespace TimeCalcCalc;

public class OutputHandler
{
    public List<Output> outputList = new List<Output>();

    private int maxSize = 0;

    public void addEntry(string filename, string line, double time)
    {
        outputList.Add(new Output(){
            Filename = filename, 
            Line = line, 
            Time = time});
        
        if(maxSize < line.Length)
        {
            maxSize = line.Length;
        }
    }

    public string getEntries()
    {
        string output = "";

        foreach (Output outputOut in outputList)
        {
            string outFile = outputOut.Line;
            int stringSize = outputOut.Line.Length;
            int stringSizeMax = (maxSize - stringSize)/16;

            for(int i = 0; i < stringSizeMax; i++)
            {
                outFile += "\t\t\t\t";
            }

            output +=  outputOut.Filename + "\t" + outFile + "\t\t" + outputOut.Time.ToString() + "\n";
        }

        return output;
    }
}
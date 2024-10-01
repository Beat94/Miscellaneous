using MermaidCreator.Model;

namespace MermaidCreator;

public class Reader
{
    public string location { get; set; }

    public ClassManager CreateModel()
    {
        ClassManager ClassManagerOutput = new();

        // goes through project and creates Mermaid model using Mermaid Model-Class
        // Filters all files in folder with the ending .cs and puts the result in a string Array
        string[] fileList = Directory.GetFiles(location, "*.cs", SearchOption.AllDirectories);

        foreach (string file in fileList)
        {
            // Opens file and analizes it
            try
            {
                // https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-read-text-from-a-file
                using StreamReader reader = new(file);

                string text = reader.ReadToEnd();

                Console.Write(text);
            }
            catch (IOException e)
            {
                Console.WriteLine("Error on reading File");
                Console.WriteLine(e.Message);
            }
        }

        return ClassManagerOutput;
    }

    public ClassManager AnalyzeFile(string file)
    {
        ClassManager ClassManangerOutput = new();

        // Logic to analyze file

        return ClassManangerOutput;
    }
}

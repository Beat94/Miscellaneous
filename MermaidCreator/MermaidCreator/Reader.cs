using MermaidCreator.Model;

namespace MermaidCreator;

public class Reader
{
    public string location { get; set; }

    public ClassManager CreateModel()
    {
        ClassManager ClassManagerOutput = new();

        // goes through project and creates Mermaid model using Mermaid Model-Class
        string[] fileList = Directory.GetFiles(location, "*.cs", SearchOption.AllDirectories);

        foreach (string file in fileList)
        { 
        
        }


        // Filters all files in folder with the ending .cs

        // Opens file and analizes it

        return ClassManagerOutput;
    }
}

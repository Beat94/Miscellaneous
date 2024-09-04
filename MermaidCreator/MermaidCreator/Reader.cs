using MermaidCreator.Model;

namespace MermaidCreator;

public class Reader
{
    public string location { get; set; }

    public ClassManager CreateModel()
    {
        ClassManager ClassManagerOutput = new();
        // goes through project and creates mermaid model using Mermaid Model-Class

        // Filters all files in folder with the ending .cs

        // Opens file and analizes it

        return ClassManagerOutput;
    }
}

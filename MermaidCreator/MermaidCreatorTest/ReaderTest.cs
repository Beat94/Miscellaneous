using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MermaidCreator;
using MermaidCreator.Model;

namespace MermaidCreatorTest;

public class ReaderTest
{
    [Theory]
    [InlineData("Testcase1Input.cs.txt", "Testcase1Output.json")]
    public void Test1(string input, string output)
    {
        Reader readerInput = new Reader();
        ClassManager ClassManagerInput = readerInput.AnalyzeFile(input);
        ClassManager ClassManagerOutput = JsonSerializer.Deserialize<ClassManager>(output);
        
        Assert.Equal(ClassManagerInput, ClassManagerOutput);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator.Model;

/// <summary>
/// Class to describe variable of a found class
/// </summary>
public class ClassVariable : Option
{
    public string varType { get; set; }

    public string getVariablename() => base.Name;

    public string getVariableWithAccessModifier() => $"{base.getAccessModifier()}{varType} {getVariablename()}";
}

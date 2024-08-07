using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator.Model;

public class Option
{
    public string Name { get; set; }
    public AccessModifier accessModifier { get; set; }

    public string getAccessModifier()
    {
        string output = "";
        if (accessModifier.Equals(AccessModifier.intern))
        {
            output = "#";
        }

        // Is secured correct?
        if (accessModifier.Equals(AccessModifier.privat) || accessModifier.Equals(AccessModifier.secured))
        {
            output = "-";
        }

        if (accessModifier.Equals(AccessModifier.general))
        {
            output = "+";
        }

        if (output.Equals("") == false)
        {
            output += " ";
        }

        return output;
    }
}

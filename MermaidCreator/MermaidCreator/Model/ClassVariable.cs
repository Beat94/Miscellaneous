using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator.Model;

public class ClassVariable : Option
{
    public string getVariablename() => base.Name;

    public string getVariableWithAccessModifier() => base.getAccessModifier() + getVariablename();
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator.Model;

/// <summary>
/// Function-Object - with Name and accessmodifier
/// </summary>
public class ClassFunction : Option
{
    public string getFunctionname() => base.Name + "()";

    public string getFunctionnameWithAccessModifier() => base.getAccessModifier() + getFunctionname();
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator.Model;

public class ClassFunction : Option
{
    public string getFunctionname() => base.Name + "()";

    public string getFunctionnameWithAccessModifier() => base.getAccessModifier() + getFunctionname();
}

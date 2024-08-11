using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator.Model;

public class ClassVariable : Option
{
<<<<<<< HEAD

=======
    public string getVariablename() => base.Name;

    public string getVariableWithAccessModifier() => base.getAccessModifier() + getVariablename();
>>>>>>> e091f3e327b74c8f2bd2fadd22a01af3bbb4b9a1
}

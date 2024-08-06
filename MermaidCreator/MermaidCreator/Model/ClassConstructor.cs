using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator.Model;

public class ClassConstructor
{
    string ClassName { get; }
    IList<Option> Functions = new List<Option>();
    IList<Option> Variables = new List<Option>();
}

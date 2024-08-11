using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator.Model;

public class ClassConstructor
{
    string ClassName { get; }
    IList<ClassFunction> Functions = new List<ClassFunction>();
    IList<ClassVariable> Variables = new List<ClassVariable>();
}

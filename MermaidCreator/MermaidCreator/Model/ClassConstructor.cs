using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator.Model;

public class ClassConstructor
{
    public string ClassName { get; }
    public IList<ClassFunction> Functions = new List<ClassFunction>();
    public IList<ClassVariable> Variables = new List<ClassVariable>();
}

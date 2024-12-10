using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator.Model;

/// <summary>
/// Used to show class. Lists functions and Variables of a function
/// </summary>
public class ClassConstructor
{
    public string ClassName { get; set; }
    public IList<ClassFunction> Functions = new List<ClassFunction>();
    public IList<ClassVariable> Variables = new List<ClassVariable>();
}

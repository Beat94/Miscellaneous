using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator.Model;

/// <summary>
/// This class shows the relationship between classes of analzysed project
/// </summary>
public class ClassRelationship
{
    public ClassConstructor Class1 { get; set; }
    public ClassConstructor Class2 { get; set; }
    public RelationShip Class1ToClass2 { get; set; }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator.Model;

public class ClassRelationship
{
    public ClassConstructor Class1;
    public ClassConstructor Class2;
    public Relationship Class1ToClass2;

    ClassRelationship(ClassConstructor Class1, ClassConstructor Class2, Relationship Class1ToClass2)
    {
        Class1 = Class1;
        Class2 = Class2;
        Class1ToClass2 = Class1ToClass2;
    }
}

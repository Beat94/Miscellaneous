using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator.Model;

public class ClassManaer
{
    IList<ClassConstructor> Classes = new List<ClassConstructor>();
    IList<ClassRelationship> classRelationships = new List<ClassRelationship>();
}

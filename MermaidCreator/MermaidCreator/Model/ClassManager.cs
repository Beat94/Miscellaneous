using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator.Model;
public class ClassManager
{
    public IList<ClassConstructor> Classes = new List<ClassConstructor>();
    public IList<ClassRelationship> ClassRelationships = new List<ClassRelationship>();
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator.Model;

public class ClassMangaer
{
    IList<ClassConstructor> Classes = new List<ClassConstructor>();
    IList<ClassRelationship> ClassRelationships = new List<ClassRelationship>();
}

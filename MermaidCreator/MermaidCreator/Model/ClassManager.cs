using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator.Model;

/// <summary>
/// A helper class to list classes and their relationship
/// </summary>
public class ClassManager
{
    public string DiagramName { get; set; }
    public IList<ClassConstructor> Classes = new List<ClassConstructor>();
    public IList<ClassRelationship> ClassRelationships = new List<ClassRelationship>();

    public void AddClassManage(ClassManager ClassManagerInput)
    {
        foreach(ClassConstructor Klasse in ClassManagerInput.Classes)
        {
            Classes.Add(Klasse);
        }

        foreach (ClassRelationship Relation in ClassManagerInput.ClassRelationships)
        {
            ClassRelationships.Add(Relation);
        }
    }
}

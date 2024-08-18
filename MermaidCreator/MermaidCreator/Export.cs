using MermaidCreator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator;

public class Export
{
    private void addRelation(string class1, string class2, ClassRelationship cr)
    { 
        
    }

    private void addClass()
    { 
    
    }

    public void CreateClassdiagram(ClassManager classManager, string? title)
    {
        string outputString = "";

        if (title != null || title != string.Empty || !String.IsNullOrEmpty(title))
        {
            outputString += $"---\ntitle: {title}\n---\n";
        }

        outputString += "classDiagram\n";

        // Add Relationships
        foreach (ClassRelationship cr in classManager.ClassRelationships)
        { 
            outputString += $"{cr.Class1.ClassName} "
        }

        // Classes
        // Add Class variables

    }

}

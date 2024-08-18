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
            outputString += $"\t{RelationShipWriter(cr.Class1.ClassName, cr.Class1ToClass2, cr.Class2.ClassName)}\n";
        }

        // Classes
        // Add Class variables

    }

    public string RelationShipWriter(string Classname1, RelationShip RelationshipClass1ToClass2, string class2)
    { 
        return $"{Classname1} {RelationshipHelper(RelationshipClass1ToClass2)} {class2}";
    }

    private string RelationshipHelper(RelationShip rl)
    {
        string output = "";

        switch (rl) 
        {
            case RelationShip.Dependency:
                output = "..>";
                break;
            case RelationShip.Association:
                output = "-->";
                break;
            case RelationShip.Aggregation:
                output = "o--";
                break;
            case RelationShip.Composition:
                output = "*--";
                break;
            case RelationShip.Generalisation:
                output = "--|>";
                break;
            default:
                output = "";
                break;
        }

        return output;
    }

}

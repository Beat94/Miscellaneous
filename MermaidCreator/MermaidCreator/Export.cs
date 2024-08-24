using MermaidCreator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator;

public class Export
{
    private string addRelations(ClassManager classManager)
    {
        string output = "";
        foreach (ClassRelationship cr in classManager.ClassRelationships)
        {
            output += $"\t{RelationShipWriter(cr.Class1.ClassName, cr.Class1ToClass2, cr.Class2.ClassName)}\n";
        }

        return output;
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

    private string addClasses(ClassManager classManager)
    {
        string output = "";

        foreach(ClassConstructor klasse in classManager.Classes)
        {
            output += $"\t class {klasse.ClassName}" + "{\n";

            foreach(ClassVariable variable in klasse.Variables)
            {
                output += $"\t\t{variable.getVariablename()}";
            }

            foreach (ClassFunction function in klasse.Functions)
            {
                output += $"\t\t{function.getFunctionnameWithAccessModifier()}";
            }

            output += "\t}";
        }
        

        return output;
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
        outputString += addRelations(classManager);

        // Classes and ClassVariables
        outputString += addClasses(classManager);
    }
}

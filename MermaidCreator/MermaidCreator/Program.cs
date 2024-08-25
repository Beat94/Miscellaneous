﻿using MermaidCreator.Model;
using System.Xml.Schema;

namespace MermaidCreator;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hallo Welt");

        cmTest();
    }

    public static void cmTest()
    {
        ClassManager cm = new()
        { 
            DiagramName = "Test Diagramm"
        };

        ClassConstructor cc = new() { ClassName = "lul" };
        ClassFunction cf = new() { Name = "getter", accessModifier = AccessModifier.general };
        ClassVariable cv = new() { Name = "Name", varType = "String", accessModifier = AccessModifier.privat };

        ClassConstructor cc2 = new() { ClassName = "lul2" };
        ClassFunction cf2 = new() { Name = "getter", accessModifier = AccessModifier.general };
        ClassVariable cv2 = new() { Name = "Name", varType = "String", accessModifier = AccessModifier.privat };

        ClassRelationship cr = new()
        {
            Class1 = cc,
            Class2 = cc2,
            Class1ToClass2 = RelationShip.Aggregation
        };

        cc.Functions.Add(cf);
        cc.Variables.Add(cv);

        cc2.Functions.Add(cf2);
        cc2.Variables.Add(cv2);

        cm.Classes.Add(cc);
        cm.Classes.Add(cc2);
        cm.ClassRelationships.Add(cr);

        Export ex = new();

        Console.WriteLine(ex.CreateClassdiagram(cm));
    }
}
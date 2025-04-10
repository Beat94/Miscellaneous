﻿using MermaidCreator.Model;
using System.Xml.Schema;
using Microsoft.Extensions.Configuration;

namespace MermaidCreator;

public class Program
{
    public static IConfiguration Configuration;

    public static void Main(string[] args)
    {
        Configuration = Toolbox.LoadConfigModule(null, args);

        ReflectionHelper reflectionHelp = new();
        Console.WriteLine("Hallo Welt");
        string ConfigTestMode = "true";

        try
        {
            ConfigTestMode ??= Configuration["Testmode"] ?? "false";
        }
        catch (Exception ex)
        {
            _ = ex;
        }

        // if Testmode then use following two commands
        if (ConfigTestMode.Equals("true", StringComparison.InvariantCultureIgnoreCase))
        { 
            confTest();

            CmTest();

            ClassManager selfReflectionClasses = reflectionHelp.SelfReflection();
            Export ex = new();

            Console.WriteLine(ex.CreateClassdiagram(selfReflectionClasses));
        }
        else
        {
            Console.WriteLine($"This is Testmode {ConfigTestMode}");
        }
    }

    /// <summary>
    /// Lists configuration values - loaded of config-file
    /// </summary>
    public static void confTest()
    {
        if (
            Configuration != null 
            && !Configuration["Folder"].Equals(null))
        {
            Console.WriteLine($"Folder: {Configuration["Folder"]}");
            Console.WriteLine($"Testmode: {Configuration["Testmode"]}");
        }
    }

    /// <summary>
    /// Test of classmanager -> with direct output to cli
    /// </summary>
    public static void CmTest()
    {
        ClassManager cm = new()
        { 
            DiagramName = "Test Diagramm"
        };

        ClassConstructor cc = new("lul");
        ClassFunction cf = new() { Name = "getter", accessModifier = AccessModifier.general };
        ClassVariable cv = new ClassVariable("String") { Name = "Name", accessModifier = AccessModifier.privat };

        ClassConstructor cc2 = new("lul2");
        ClassFunction cf2 = new() { Name = "getter", accessModifier = AccessModifier.general };
        ClassVariable cv2 = new ClassVariable("String") { Name = "Name", accessModifier = AccessModifier.privat };

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

    /// <summary>
    /// Festfunction planned are multiple tests<br/>
    /// Modes:<br/>
    /// 0: ??
    /// </summary>
    /// <param name="mode"></param>
    public static void MultiTestfunction(int mode)
    { 
    
    }
}
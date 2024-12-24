using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MermaidCreator.Model;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.NetworkInformation;
using System.Diagnostics.Contracts;

namespace MermaidCreator;

/// <summary>
/// Used to create class-diagram using reflection
/// </summary>
internal class ReflectionHelper
{
    /// <summary>
    /// Used to create class-diagram of this project using reflection
    /// </summary>
    internal ClassManager SelfReflection()
    {
        ClassManager classManOut = new();

        // https://medium.com/technology-nineleaps/reflection-in-net-a-comprehensive-guide-for-application-development-66841aa6f4b1
        Assembly CurrentAssembly = Assembly.GetExecutingAssembly();
        Type[] classtypesname = GetTypesOfAssembly(CurrentAssembly);
        List<ClassConstructor> cAndF = GetClassesAndFunctions(classtypesname, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance, true);

        classManOut.DiagramName = "TestDiagram";
        classManOut.Classes = cAndF;

        return classManOut;
    }

    internal Type[] GetTypesOfAssembly(Assembly inputAssembly) => inputAssembly.GetTypes();

    internal List<ClassConstructor> GetClassesAndFunctions(Type[] input, BindingFlags bindingFlag, bool withoutGetSet)
    {
        List<ClassConstructor> ClassConstrutorList = new();

        foreach (Type classtype in input)
        {
            ClassConstructor classConstructor = new(classtype.Name);

            Console.WriteLine(classtype.Name);

            // add Property and Field Analyzation
            PropertyInfo[] properties = classtype.GetProperties(bindingFlag); // Variable
            FieldInfo[] fields =  classtype.GetFields(bindingFlag); // Variable
            MethodInfo[] privateMethods = classtype.GetMethods(bindingFlag); // Method


            // TODO
            foreach (PropertyInfo property in properties)
            {
                ClassVariable classVariable = new(property.Name);

                Console.WriteLine(property.Name);
                classConstructor.Variables.Add(classVariable);
            }

            foreach (FieldInfo field in fields)
            {
                ClassVariable classVariable = new(field.Name);

                foreach (string perm in getPermissionsOfFieldInfo(field))
                {
                    Console.Write($"{perm} ");
                    classVariable.accessModifier = (AccessModifier)getPermissionOfFieldInfo(field);
                }

                Console.WriteLine($"{field.Name}");
                classConstructor.Variables.Add(classVariable);
            }

            foreach (MethodInfo privateMethod in privateMethods)
            {
                if (withoutGetSet)
                {
                    // Idea: Flag for look at Getter and Setter
                    // ToDo: add Variable to ouput-Variable
                    if (
                        !privateMethod.Name.StartsWith("get_") 
                        && !privateMethod.Name.StartsWith("set_")
                        && !privateMethod.Name.StartsWith("System.")
                        && !privateMethod.Name.Equals("GetType")
                        && !privateMethod.Name.Equals("MemberwiseClone")
                        && !privateMethod.Name.Equals("Finalize")
                        && !privateMethod.Name.Equals("ToString")
                        && !privateMethod.Name.Equals("Equals")
                        && !privateMethod.Name.Equals("GetHashCode"))
                    {
                        ClassFunction cf = new();

                        // in case of multipe flags write flag directly on line and in the end mothodname
                        // from here to console.writeline after foreach-loop could be deleted
                        List<string> flags = getPermissionsOfMember(privateMethod);
                        foreach (string flag in flags)
                        {
                            Console.Write($"{flag} ");
                        }

                        Console.WriteLine($"{privateMethod.Name}");

                        cf.Name = privateMethod.Name;
                        cf.accessModifier = getPermissionsOfMemberAccessmodifier(privateMethod);
                        // add method to output
                        classConstructor.Functions.Add(cf);
                    }
                }
                else
                {
                    Console.WriteLine(privateMethod.Name);
                }

            }
            Console.WriteLine("----");
        }

        return new List<ClassConstructor>();
    }

    internal AccessModifier getPermissionOfFieldInfo(FieldInfo fieldInfoInput)
    {
        if (fieldInfoInput.IsPublic)
        {
            return AccessModifier.general;
        }

        if (fieldInfoInput.IsPrivate)
        {
            return AccessModifier.privat;
        }

        if (fieldInfoInput.IsFamily)
        {
            return AccessModifier.intern;
        }

        if (fieldInfoInput.IsAssembly)
        {
            return AccessModifier.secured;
        }

        return AccessModifier.intern;
    }

    internal List<string> getPermissionsOfFieldInfo(FieldInfo fieldInfoInput)
    { 
        List<string> permissions = new List<string>();


        if (fieldInfoInput.IsPublic)
        {
            permissions.Add("Public");
        }

        if (fieldInfoInput.IsPrivate)
        {
            permissions.Add("Private");
        }

        if (fieldInfoInput.IsFamily)
        {
            permissions.Add("Protected");
        }

        if (fieldInfoInput.IsAssembly)
        {
            permissions.Add("Internal");
        }

        return permissions;
    }

    internal AccessModifier getPermissionsOfMemberAccessmodifier(MethodBase input)
    { 
        if (input.IsPublic)
        {
            return AccessModifier.general;
        }

        if (input.IsPrivate)
        {
            return AccessModifier.privat;
        }

        if (input.IsFamily)
        {
            return AccessModifier.intern;
        }

        if (input.IsAssembly)
        {
            return AccessModifier.secured;
        }

        return AccessModifier.intern;
    }

    internal List<string> getPermissionsOfMember(MethodBase input)
    {
        List<string> permissions = new List<string>();

        if (input.IsPublic)
        {
            permissions.Add("Public");
        }

        if (input.IsPrivate)
        {
            permissions.Add("Private");
        }

        if (input.IsFamily)
        {
            permissions.Add("Protected");
        }

        if (input.IsAssembly)
        {
            permissions.Add("Internal");
        }

        return permissions;
    }
}

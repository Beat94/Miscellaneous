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

namespace MermaidCreator;

/// <summary>
/// Used to create class-diagram using reflection
/// </summary>
internal class ReflectionHelper
{
    /// <summary>
    /// used to create class-diagram of this project using reflection
    /// </summary>
    internal ClassManager SelfReflection()
    {
        // https://medium.com/technology-nineleaps/reflection-in-net-a-comprehensive-guide-for-application-development-66841aa6f4b1
        Assembly CurrentAssembly = Assembly.GetExecutingAssembly();

        Type[] classtypesname = GetTypesOfAssembly(CurrentAssembly);

        getClassesAndFunctions(classtypesname, BindingFlags.NonPublic | BindingFlags.Instance, true);

        Console.WriteLine("====\nPrivate BindingFlag | And Public \n====");

        getClassesAndFunctions(classtypesname, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance, true);

        return new ClassManager();
    }

    internal Type[] GetTypesOfAssembly(Assembly inputAssembly)
    {

        return inputAssembly.GetTypes();
    }

    internal void getClassesAndFunctions(Type[] input, BindingFlags bindingFlag, bool withoutGetSet)
    {
        foreach (Type classtype in input)
        {
            Console.WriteLine(classtype.Name);

            MethodInfo[] privateMethods = classtype.GetMethods(bindingFlag);
            foreach (MethodInfo privateMethod in privateMethods)
            {
                if (withoutGetSet)
                {
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
                        List<string> flags = getPermissionsOfMember(privateMethod);

                        foreach (string flag in flags)
                        {
                            Console.Write($"{flag} ");
                        }

                        Console.WriteLine($"{privateMethod.Name}");
                    }
                }
                else
                {
                    Console.WriteLine(privateMethod.Name);
                }

            }
            Console.WriteLine("----");
        }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MermaidCreator.Model;
using System.Runtime.InteropServices;

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

        getClassesAndFunctions(classtypesname, BindingFlags.NonPublic | BindingFlags.Instance);

        Console.WriteLine("====\nPrivate BindingFlag | And Public \n====");

        getClassesAndFunctions(classtypesname, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

        return new ClassManager();
    }

    internal Type[] GetTypesOfAssembly(Assembly inputAssembly)
    {
        return inputAssembly.GetTypes();
    }

    internal void getClassesAndFunctions(Type[] input, BindingFlags bindingFlag)
    {
        foreach (Type classtype in input)
        {
            Console.WriteLine(classtype.Name);

            MethodInfo[] privateMethods = classtype.GetMethods(bindingFlag);
            foreach (MethodInfo privateMethod in privateMethods)
            {
                Console.WriteLine(privateMethod.Name);

            }
            Console.WriteLine("----");
        }
    }
}

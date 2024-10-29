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

        foreach (Type classtype in classtypesname)
        { 
            Console.WriteLine(classtype.Name);
            
            MethodInfo[] methods = classtype.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
                method.
            }
            Console.WriteLine("----");
        }

        return new ClassManager();
    }

    internal Type[] GetTypesOfAssembly(Assembly inputAssembly)
    {
        return inputAssembly.GetTypes();
    }
}

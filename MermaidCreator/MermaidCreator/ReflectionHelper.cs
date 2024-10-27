using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MermaidCreator.Model;

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



        return new ClassManager();
    }
}

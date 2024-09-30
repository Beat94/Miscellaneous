using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator;

internal class Toolbox
{
    public static IConfiguration LoadConfigModule()
    {
        ConfigLoader configLoader = new();
        return configLoader.loadConfig();
    }

    /// <summary>
    /// Load Config with link or start-values
    /// </summary>
    /// <param name="link"></param>
    /// <param name="args"></param>
    /// <returns>IConfiguration</returns>
    public static IConfiguration LoadConfigModule(string? link, string[]? args)
    {
        ConfigLoader configLoader = new();
        return configLoader.loadConfig(link, args);
    }
}

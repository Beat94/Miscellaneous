using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator;

internal class Toolbox
{
    public static IConfiguration loadConfigModule()
    {
        ConfigLoader configLoader = new();
        return configLoader.loadConfig();
    }

    public static IConfiguration loadConfigModule(string? link, string[]? args)
    {
        ConfigLoader configLoader = new();
        return configLoader.loadConfig(link, args);
    }
}

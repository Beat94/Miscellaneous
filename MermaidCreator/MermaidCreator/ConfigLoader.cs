using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MermaidCreator;

internal class ConfigLoader
{
    IConfiguration config;

    string link { get; set; }

    internal IConfiguration loadConfig(string? link, string[]? args)
    {
        string linkConfig;

        if (link != null 
            || !link.Equals("", StringComparison.InvariantCultureIgnoreCase) 
            || !link.Equals("", StringComparison.InvariantCultureIgnoreCase))
        {
            linkConfig = link;
        }
        else if (args.FirstOrDefault() != null 
            || !args.FirstOrDefault().Equals("", StringComparison.InvariantCultureIgnoreCase) 
            || !args.FirstOrDefault().Equals("", StringComparison.InvariantCultureIgnoreCase))
        { 
            linkConfig = args.FirstOrDefault();
        }
        if (this.link != null
            || !this.link.Equals("", StringComparison.InvariantCultureIgnoreCase)
            || !this.link.Equals("", StringComparison.InvariantCultureIgnoreCase))
        {
            linkConfig = link;
        }
        else
        {
            linkConfig = Directory.GetCurrentDirectory();
        }

        var configBuidler = new ConfigurationBuilder().SetBasePath(linkConfig).AddJsonFile("appsettings.json");

        config = configBuidler.Build();

        return config;
    }

    internal IConfigurationSection getConfigByString(string section)
    { 
        return config.GetSection(section);
    }
    
    /*
    public void cl()
    {
        var builder = new ConfigurationBuilder();

        IConfiguration config = builder.Build();

        var appSettings = config.GetSection<AppSettings>();
    }
    */
}

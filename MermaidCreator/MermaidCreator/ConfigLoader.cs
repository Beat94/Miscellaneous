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

    internal string? link = null;

    internal IConfiguration loadConfig()
    {
        return loadConfig(null, null);
    }

    internal IConfiguration loadConfig(string? link, string[]? args)
    {
        string linkConfig;
        try
        {
            if (link != null)
            {
                linkConfig = link;
            }
            else if (args.FirstOrDefault() != null)
            {
                linkConfig = args.FirstOrDefault();
            }
            if (this.link != null)
            {
                linkConfig = link;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Data);
        }
        finally
        {
            linkConfig = Directory.GetCurrentDirectory();
        }

        try
        {
            var configBuidler = new ConfigurationBuilder().SetBasePath(linkConfig).AddJsonFile("appsettings.json");
            config = configBuidler.Build();
        }
        catch (Exception ex)
        {
            _ = ex;
        }

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

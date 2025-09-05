using ADOScripter.Models;
using Microsoft.Extensions.Configuration;

namespace ADOScripter;

public class ConfigLoader
{
    public IConfiguration configuration { get; }

    public ConfigLoader()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory() + "//..//..//..//")
            .AddJsonFile("Configuration.json", optional: false, reloadOnChange: true);

        configuration = builder.Build();
    }

    public ConfigModel getConfig()
    {
        ConfigModel configModel = new();

        configModel.Organization = configuration["Organization"];
        configModel.Project = configuration["Project"];
        configModel.Pat = configuration["Pat"];
        configModel.Debug = bool.Parse(configuration["Debug"] ?? "false");
        configModel.InputFile = configuration["InputFile"];
        configModel.AreaPath = configuration["AreaPath"];
        configModel.IterationPath = configuration["IterationPath"];
        configModel.ShortMode = bool.Parse(configuration["ShortMode"] ?? "false");

        return configModel;
    }
}

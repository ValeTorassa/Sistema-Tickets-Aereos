using System.IO;
using Microsoft.Extensions.Configuration;

public static class ConfigurationHelper
{
    public static IConfigurationRoot GetConfiguration(string fileName)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(fileName, optional: true, reloadOnChange: true);

        return builder.Build();
    }
}
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace AzureAppConfigAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            
            builder.AddAzureAppConfiguration(Environment.GetEnvironmentVariable("ConnectionString"));

            var config = builder.Build();
            Console.WriteLine(config["api-connstring-dev"] ?? "Hello world!");
        }
    }
}

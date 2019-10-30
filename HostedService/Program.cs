using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace HostedService
{
    /// <summary>
    /// Example of Hosted Services with Generic Hosts
    /// .NET CORE 2.2
    /// Extra Packages Installed: Microsoft.AspNetCore.App to use Extensions.Hosting -> HostBuilder
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            MainTaskAsync(args).Wait();
        }


        static async Task MainTaskAsync(string[] args) => await CreateHostBuilder(args).RunAsync();

        /// <summary>
        /// Create a host using HostBuilder
        /// Services configuration in Startup
        /// </summary>
        public static IHost CreateHostBuilder(string[] args) =>
            new HostBuilder()
                .ConfigureAppConfiguration(AppConfiguration)
                .ConfigureServices(Startup.ConfigureServices)
                .Build();
        private static void AppConfiguration(HostBuilderContext hostContext, IConfigurationBuilder config) =>
            config
                .SetBasePath(Environment.CurrentDirectory)
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", optional: false);
    }
}

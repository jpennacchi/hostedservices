using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HostedService
{
    /// <summary>
    /// Example of Hosted Services with Generic Hosts
    /// .NET CORE 2.2
    /// Extra Packages Installed: Microsoft.AspNetCore.App to use Extensions.Hosting -> HostBuilder
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            MainTaskAsync(args).Wait();
        }

        static async Task MainTaskAsync(string[] args)
        {
            #region RunConsoleAsync
            //RunConsoleAsync enables console support, builds and starts the host, and waits for Ctrl+C/SIGINT or SIGTERM to shut down.
            await CreateHostBuilder(args).RunConsoleAsync(); 

            #endregion

            #region RunAsync
            //RunAsync runs the app and returns a Task that completes when the cancellation token or shutdown is triggered
            //IHost host = CreateHostBuilder(args).Build();
            //await host.RunAsync();
            #endregion

            #region StartAsync and StopAsync
            //Start starts the host synchronously.
            //StopAsync attempts to stop the host within the provided timeout

            //IHost host = CreateHostBuilder(args).Build();

            //using (host)
            //{
            //    await host.StartAsync();
            //    await host.StopAsync();
            //}
            #endregion
        }

        /// <summary>
        /// Create a host using HostBuilder
        /// Services configuration in Startup
        /// </summary>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            new HostBuilder()
                .ConfigureAppConfiguration(AppConfiguration)
                .ConfigureLogging(Logging)
                .ConfigureServices(Startup.ConfigureServices)
                .UseConsoleLifetime();

        private static void AppConfiguration(HostBuilderContext hostContext, IConfigurationBuilder config) =>
            config
                .SetBasePath(Environment.CurrentDirectory)
                .AddEnvironmentVariables()
                .AddJsonFile(
                    $"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json",
                    optional: true)
                .AddJsonFile("appsettings.json", optional: true);

        private static void Logging(HostBuilderContext hostContext, ILoggingBuilder logBuilder) =>
            logBuilder
                .AddConsole()
                .AddDebug();
    }
}

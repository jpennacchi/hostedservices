using HostedService.Domain.Services;
using HostedService.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HostedService
{
    public static class Startup
    {
        public static void ConfigureServices(HostBuilderContext hostBuilderContext, IServiceCollection services)
        {
            //example add singleton from appsettings.json
            //services.AddSingleton(hostBuilderContext.Configuration.GetSection("mySectionInJson").Get<MySectionClass>());

            services.Configure<HostOptions>(option =>
            {
                option.ShutdownTimeout = System.TimeSpan.FromSeconds(20);
            });

            services.AddSingleton<ICommonService, MyService>();
            services.AddHostedService<MyHostedService>();
        }
    }
}

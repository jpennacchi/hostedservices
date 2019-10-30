using HostedService.Domain.Services;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace HostedService
{
    public class MyHostedService : BackgroundService
    {
        private readonly MyService _myService;

        //public MyHostedService(MyService myService)
        //{
        //    _myService = myService;
        //}

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _myService.StartAsync(stoppingToken);
        }
    }
}

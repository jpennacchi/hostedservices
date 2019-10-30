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
        public MyHostedService()
        {
            //_myService = myService;
            _myService = new MyService();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _myService.StartAsync(stoppingToken);
        }
    }
}

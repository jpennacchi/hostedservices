using HostedService.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HostedService.Domain.Services
{
    public class MyService : ICommonService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Service working...");

            await Task.Delay(1000);
        }
    }
}

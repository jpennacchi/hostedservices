using System.Threading;
using System.Threading.Tasks;

namespace HostedService.Interfaces
{
    public interface ICommonService
    {
        Task StartAsync(CancellationToken cancellationToken);
    }
}

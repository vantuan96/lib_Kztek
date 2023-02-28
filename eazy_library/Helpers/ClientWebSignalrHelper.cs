using System;
using System.Threading;
using System.Threading.Tasks;
using eazy_library.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;

namespace eazy_library.Helpers
{
    public class ClientWebSignalrHelper: IHostedService, IDisposable
    {
        public static IHubContext<ClientWebHub> ClientWebHub;

        public ClientWebSignalrHelper(IHubContext<ClientWebHub> _ClientWebHub)
        {
            ClientWebHub = _ClientWebHub;
        }

        public void Dispose()
        {
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

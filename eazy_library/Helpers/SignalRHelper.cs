using System;
using System.Threading;
using System.Threading.Tasks;
using eazy_library.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;

namespace eazy_library.Helpers
{
    public class SignalRHelper: IHostedService, IDisposable
    {
        public static IHubContext<ServerHub> ServerHub;

        public SignalRHelper(IHubContext<ServerHub> _ServerHub)
        {
            ServerHub = _ServerHub;
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

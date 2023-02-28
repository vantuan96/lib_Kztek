using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using eazy_library.Helpers;
using eazy_library.Models;
using Microsoft.AspNetCore.SignalR;

namespace eazy_library.Hubs
{
    public class ClientWebHub : Hub
    {
        public static ConcurrentDictionary<string, string> _users = new ConcurrentDictionary<string, string>();

        //Called when a client is connected
        public override Task OnConnectedAsync()
        {
            _users.TryAdd(Context.ConnectionId, Context.User.Identity.Name);

            Clients.Client(Context.ConnectionId).SendAsync("Connected", Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        //Called when a client is disconnected
        public override Task OnDisconnectedAsync(Exception exception)
        {
            string userName;
            _users.TryRemove(Context.ConnectionId, out userName);

            return base.OnDisconnectedAsync(exception);
        }
    }
}

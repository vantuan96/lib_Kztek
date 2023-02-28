using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using eazy_library.Helpers;
using Microsoft.AspNetCore.SignalR;

namespace eazy_library.Hubs
{
    public class ServerHub : Hub
    {
        public static ConcurrentDictionary<string, string> _users = new ConcurrentDictionary<string, string>();

        /// <summary>
        /// Đăng ký truy cập từ local về server
        /// </summary>
        /// <param name="connectionid"></param>
        /// <param name="pcid"></param>
        /// <returns></returns>
        public async Task RegisterAccess(string connectionid, string pcid)
        {
            var mess = new List<string>();

            try
            {
                _users[connectionid] = pcid;

                //Cập nhật db
                var command = string.Format("UPDATE dbo.[ACCESS_PC] SET ConnectionId = '{0}' WHERE Id = '{1}'", connectionid, pcid);

                var connect = await AppSettingHelper.GetStringFromAppSetting("ConnectionStrings:DefaultConnection");

                SqlHelper.ExcuteCommandToMesageReport(connect, command);

                mess.Add("Connected at " + DateTime.Now);
                await Clients.Client(connectionid).SendCoreAsync("Connected", mess.ToArray());
            }
            catch (System.Exception ex)
            {
                mess.Add("Error: " + ex.Message);
                await Clients.Client(connectionid).SendCoreAsync("Connected", mess.ToArray());
            }
        }

        //Called when a client is connected
        public override Task OnConnectedAsync()
        {
            _users.TryAdd(Context.ConnectionId, Context.User.Identity.Name);

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
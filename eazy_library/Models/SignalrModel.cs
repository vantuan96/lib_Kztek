using System;
namespace eazy_library.Models
{
    public class SignalrModel
    {
        public string Id { get; set; }

        public string AccountId { get; set; } //Id tài khoản nào => cần mapping.

        public string ClientId { get; set; } //Id thiết bị để signalr gửi được thông báo.

        public string Platform { get; set; }
    }
}

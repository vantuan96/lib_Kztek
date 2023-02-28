using System;

namespace eazy_library.Cores.Models
{
    public class MessageReport
    {
        public bool isSuccess { get; set; }

        public string Message { get; set; }

        public string Detail { get; set; }

        public MessageReport()
        {

        }

        public MessageReport(bool isSuccess, string Message)
        {
            this.isSuccess = isSuccess;
            this.Message = Message;
        }

        public static implicit operator MessageReport(string v)
        {
            throw new NotImplementedException();
        }
    }
    public class MessageReportCustom
    {
        public bool isSuccess { get; set; }

        public string Message { get; set; }
        public string CardNumber { get; set; }
    }
}
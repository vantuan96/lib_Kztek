using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using RestSharp;
using RestSharp.Authenticators;
using eazy_library.Models;

namespace eazy_library.Helpers
{
    public class MailService
    {
        public static async Task SendMessage(AccountInfoModel Sender, List<AccountInfoModel> Recipients, string Subject, string Content, bool IsBodyHtml = true, bool IsAPI = false, string Tag = "EazyERP")
        {
            try
            {
                if (Recipients != null && Recipients.Count > 0)
                {
                    //await SendMessageSmtp(Sender, Recipients, Subject, Content, IsBodyHtml);
                    var result = (await SendMessageAPI(Sender, Recipients, Subject, Content, IsBodyHtml, Tag)).Content.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Sử dụng giao thức API (Nhanh hơn so với gửi Smtp gấp 3 lần)
        public static async Task<IRestResponse> SendMessageAPI(AccountInfoModel Sender, List<AccountInfoModel> Recipients, string Subject, string Content, bool IsBodyHtml = true, string Tag = "EazyERP")
        {
            var Domain = await AppSettingHelper.GetStringFromAppSetting("Email:MailGun:Domain");
            var API_Key = await AppSettingHelper.GetStringFromAppSetting("Email:MailGun:API_Key");
            var BaseUrl = await AppSettingHelper.GetStringFromAppSetting("Email:MailGun:BaseUrl");

            RestClient client = new RestClient();
            client.BaseUrl = new Uri(BaseUrl);

            client.Authenticator = new HttpBasicAuthenticator("api", API_Key);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", Domain, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";

            // Người gửi
            request.AddParameter("from", String.Format("{0} <{1}>", Sender.FullName, Sender.Email));

            // Người nhận
            if (Recipients.Any())
            {
                foreach (var item in Recipients)
                {
                    request.AddParameter("to", String.Format("{0} <{1}>", item.FullName, item.Email));
                }
            }

            // Subject
            request.AddParameter("subject", Subject);

            // Nội dung email
            if(IsBodyHtml)
                request.AddParameter("html", Content);
            else
                request.AddParameter("text", Content);

            // Thiết lập thêm tham số
            request.AddParameter("o:tag", Tag);

            request.Method = Method.POST;

            return client.Execute(request);
        }

        // Sử dụng giao thức Smtp
        public static async Task SendMessageSmtp(AccountInfoModel Sender, List<AccountInfoModel> Recipients, string Subject, string Content, bool IsBodyHtml = true)
        {
            try
            {
                if (Recipients == null || Recipients.Count == 0)
                    return;

                // Compose a message
                MimeMessage mail = new MimeMessage();
                mail.From.Add(new MailboxAddress(Sender.FullName, Sender.Email));
                if (Recipients.Any())
                {
                    foreach (var item in Recipients)
                    {
                        mail.To.Add(new MailboxAddress(item.FullName, item.Email));
                    }
                }
                mail.Subject = Subject;
                mail.Body = new BodyBuilder()
                {
                    HtmlBody = IsBodyHtml ? Content : null,
                    TextBody = IsBodyHtml ? null : Content,
                }.ToMessageBody();

                // Send it!
                using (var client = new SmtpClient())
                {
                    // XXX - Should this be a little different?
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect("smtp.mailgun.org", 587, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    var UserName = await AppSettingHelper.GetStringFromAppSetting("Email:MailGun:UserName");
                    var Password = await AppSettingHelper.GetStringFromAppSetting("Email:MailGun:Password");
                    client.Authenticate(UserName, Password);

                    client.Send(mail);
                    client.Disconnect(true);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
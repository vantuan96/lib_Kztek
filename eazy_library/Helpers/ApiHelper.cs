using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using eazy_library.Cores.Security;
using eazy_library.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace eazy_library.Helpers
{
    public class ApiHelper
    {
        public static IWebHostEnvironment _environment;
        public static HttpClient client;

        static ApiHelper()
        {
            client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(30);
        }

        public static string GenerateJSON_MobileToken(string userid, string issuer)
        {
            //
            var now = DateTime.Now;
            var expire = now.AddMonths(1);

            //
            var Issuer = issuer;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityModel.Mobile_Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                Issuer,
                Issuer,
                new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userid),
                },
                expires: expire,
                signingCredentials: credentials);

            var mo = new TokenModel()
            {
                Identifier = userid,
                Expires_In = (int)(expire - now).TotalMinutes,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return JsonConvert.SerializeObject(mo);
        }
        

        public static string GenerateJSON_MobileToken(string userid)
        {
            //
            var now = DateTime.Now;
            var expire = now.AddMonths(1);

            //
            var Issuer = AppSettingHelper.GetStringFromFileJson("appsettings", "Jwt:Issuer_Mobile").Result;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityModel.Mobile_Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                Issuer,
                Issuer,
                new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userid),
                },
                expires: expire,
                signingCredentials: credentials);

            var mo = new TokenModel()
            {
                Identifier = userid,
                Expires_In = (int)(expire - now).TotalMinutes,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return JsonConvert.SerializeObject(mo);
        }
        
        public static TokenModel GenerateJSON_WebToken(string accountid, bool isRemember = true)
        {
            //
            var now = DateTime.Now;
            var expire = now.AddDays(isRemember ? 7 : 1);

            //
            var Issuer = "Private";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityModel.Web_Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                Issuer,
                Issuer,
                new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, accountid),
                },
                expires: expire,
                signingCredentials: credentials);

            var mo = new TokenModel()
            {
                Identifier = accountid,
                Expires_In = (int)(expire - now).TotalMinutes,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
            };

            return mo;
        }

        public static Task<T> ConvertResponse<T>(HttpResponseMessage response)
        {
            if (response != null && response.IsSuccessStatusCode)
            {
                var t = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                return Task.FromResult(t);
            }

            return null;
        }

        // Kiểm tra 1 file có tồn tại trên máy chủ hay không
        public static bool CheckIsExistFile(string filePath)
        {
            if (filePath != null && filePath != "")
            {
                var path = string.Format("{0}/{1}", Directory.GetCurrentDirectory(), filePath);
                return System.IO.File.Exists(path);
            }
            else
                return false;
        }    

        public static async Task<HttpResponseMessage> HttpGet(string url, string token = "")
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                return await client.GetAsync(url);
            }
            catch (System.Exception ex)
            {
                var re = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message)
                };

                return await Task.FromResult(re);
            }
        }

        public static async Task<HttpResponseMessage> HttpPost<T>(string url, T obj, string token = "")
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var content = JsonConvert.SerializeObject(obj);

                var data = new StringContent(content, Encoding.UTF8, "application/json");

                return await client.PostAsync(url, data);
            }
            catch (System.Exception ex)
            {
                var re = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message)
                };

                return await Task.FromResult(re);
            }
        }

        public static async Task<HttpResponseMessage> HttpPut<T>(string url, T obj, string token = "")
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var content = JsonConvert.SerializeObject(obj);

                var data = new StringContent(content, Encoding.UTF8, "application/json");

                return await client.PutAsync(url, data);
            }
            catch (System.Exception ex)
            {
                var re = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message)
                };

                return await Task.FromResult(re);
            }

        }

        public static async Task<HttpResponseMessage> HttpDelete(string url, string token = "")
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                return await client.DeleteAsync(url);
            }
            catch (System.Exception ex)
            {
                var re = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message)
                };

                return await Task.FromResult(re);
            }
        }
    }
}

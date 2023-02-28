using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using eazy_library.Configs;
using eazy_library.Cores.Models;
using eazy_library.Cores.Security;
using eazy_library.Functions;
using eazy_library.Models;
using eazy_library.Security;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace eazy_library.Helpers
{


    public class AuthHelper
    {

       
        /// <summary>
        /// Kiểm tra quyền trong view
        /// </summary>
        /// <param name="controller">Tên controller</param>
        /// <param name="context"></param>
        /// <param name="appcode">Mã ứng dụng</param>
        /// <returns></returns>
        public static async Task<AuthActionModel> CheckAuthAction(string controller, HttpContext context, string appcode = "")
        {
            var Auth = new AuthActionModel();

            var objAccount = await SessionCookieHelper.CurrentAccount(context);
            if (objAccount != null)
            {
                //Nếu là admin pass qua hết
                if (objAccount.IsAdmin)
                {
                    Auth.Create_Auth = 1;
                    Auth.Update_Auth = 1;
                    Auth.Delete_Auth = 1;
                    Auth.MultiDelete_Auth = 1;
                    
                }
     

                else
                {
                    //Lấy token trong cookie
                    var objToken = await SessionCookieHelper.CurrentTokenAuth(context);

                    //Lấy danh sách menu theo account, appcode...
                    var menufunctions = Permissions(await AppSettingHelper.GetStringFromAppSetting("Web:APi"), new AccountPermissionModel()
                    {
                        AccountId = objAccount.Id,
                        AppCode = appcode,
                        isAdmin = objAccount.IsAdmin
                    }, context, objToken != null ? objToken.Token : "").Result;

                    if(menufunctions.Any())
                    {
                        if (menufunctions.Any(n => n.ControllerName == controller && n.ActionName == "Create"))
                        {
                            Auth.Create_Auth = 1;
                        }

                        if (menufunctions.Any(n => n.ControllerName == controller && (n.ActionName == "Update" || n.ActionName == "UpdateApprove" || n.ActionName == "UpdateAccept")))
                        {
                            Auth.Update_Auth = 1;
                        }

                        if (menufunctions.Any(n => n.ControllerName == controller && n.ActionName == "Delete"))
                        {
                            Auth.Delete_Auth = 1;
                        }

                        if (menufunctions.Any(n => n.ControllerName == controller && n.ActionName == "MultiDelete"))
                        {
                            Auth.MultiDelete_Auth = 1;
                        }
                    }
                }
            }


            return await Task.FromResult(Auth);
        }

        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="model"></param>
        /// <param name="url">api url</param>
        /// <param name="appcode">mã ứng dụng</param>
        /// <returns></returns>
        public static async Task<AccountData> SignIn(AuthModel model, string url, string appcode)
        {
            var result = new AccountData();

            var obj = new AccountAuthModel()
            {
                Username = model.Username,
                Password = model.Password,
                IsRemember = model.isRemember,
                AppCode = appcode
            };

            var response = await ApiHelper.HttpPost<AccountAuthModel>(url, obj, "");

            if (response.IsSuccessStatusCode)
            {
                return await ApiHelper.ConvertResponse<AccountData>(response);
            }
            else
            {
                result.Report = new MessageReport(false, "Mã lỗi: " + response.StatusCode +  " - Chi tiết: " + response.Content.ReadAsStringAsync().Result);
                return await Task.FromResult(result);
            }
        }

        /// <summary>
        /// Lưu lại cookie sau khi sign in thành công
        /// </summary>
        /// <param name="model"></param>
        /// <param name="appcode">Mã úng dụng</param>
        /// <param name="isRemember">Cho lưu không ? không lưu thì chỉ có hạn 60m</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<MessageReport> SaveTokenCookie(AccountData model, string appcode, bool isRemember, HttpContext context)
        {
            var result = new MessageReport(false, "error");

            try
            {
                //Mã hóa
                var encryptToken = CryptoHelper.EncryptToken(JsonConvert.SerializeObject(model.Token));
                var encryptInfo = CryptoHelper.EncryptSessionCookie_User(JsonConvert.SerializeObject(model.Info));

                //Lưu vào cookie isRemember == false => 60m
                var option = new CookieOptions();
                option.Expires = DateTime.Now.AddMinutes(isRemember ? model.Token.Expires_In : 60);
                context.Response.Cookies.Append(CookieConfig.Kz_TokenCookie, encryptToken);
                context.Response.Cookies.Append(CookieConfig.Kz_AccountInfoCookie, encryptInfo);

                //Lưu vào cache isRemember == false => 60m
                var identify = string.Format(CacheConfig.Kz_User_MenuFunctionCache_Key, model.Info.Id, SecurityModel.Cache_Key);

                CacheFunction.Add<List<MenuFunctionModel>>(context, identify, model.Permissions, isRemember ? model.Token.Expires_In : 60);

                result = new MessageReport(true, "Hoàn thành");
            }
            catch (System.Exception ex)
            {
                result = new MessageReport(false, ex.Message);
            }

            return await Task.FromResult(result);
        }



        /// <summary>
        /// Lưu lại bộ lọc khi tìm kiếm
        /// </summary>
        /// <param name="model"></param>
        /// <param name="appcode">Mã úng dụng</param>
        /// <param name="isRemember">Cho lưu không ? không lưu thì chỉ có hạn 60m</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<MessageReport> SaveSearchCookie(TableModel model,string appcode, bool isMoreSearch,  HttpContext context)
        {
            var result = new MessageReport(false, "error");

            try
            {



                //Mã hóa
                // var encryptToken = CryptoHelper.EncryptToken(JsonConvert.SerializeObject(model.));
            //    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                //var json = serializer.Serialize(user);
                //var encryptInfo = JsonConvert.SerializeObject(model);
                //Lưu vào cookie isRemember == false => 60m
                var option = new CookieOptions();
                option.Expires = DateTime.Now.AddMinutes(isMoreSearch ? 15 : 60);
             //   context.Response.Cookies.Append(CookieConfig.Kz_ContractCookie, model.MoreSearch);
                context.Response.Cookies.Append(CookieConfig.Kz_ContractCookie, model.MoreSearch);
                result = new MessageReport(true, "Hoàn thành");
            }
            catch (System.Exception ex)
            {
                result = new MessageReport(false, ex.Message);
            }

            return await Task.FromResult(result);
        }

        /// <summary>
        /// Lưu lại bộ lọc khi tìm kiếm
        /// </summary>
        /// <param name="model"></param>
        /// <param name="appcode">Mã úng dụng</param>
        /// <param name="isRemember">Cho lưu không ? không lưu thì chỉ có hạn 60m</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<MessageReport> SaveSearchCookie1(string more, string appcode, bool isMoreSearch, HttpContext context)
        {
            var result = new MessageReport(false, "error");

            try
            {



                //Mã hóa
                // var encryptToken = CryptoHelper.EncryptToken(JsonConvert.SerializeObject(model.));
                //    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                //var json = serializer.Serialize(user);
                //var encryptInfo = JsonConvert.SerializeObject(model);
                //Lưu vào cookie isRemember == false => 60m
                var option = new CookieOptions();
                option.Expires = DateTime.Now.AddMinutes(isMoreSearch ? 86400 : 60);
                //   context.Response.Cookies.Append(CookieConfig.Kz_ContractCookie, model.MoreSearch);
                context.Response.Cookies.Append(CookieConfig.Kz_ContractCookie1,more);
                result = new MessageReport(true, "Hoàn thành");
            }
            catch (System.Exception ex)
            {
                result = new MessageReport(false, ex.Message);
            }

            return await Task.FromResult(result);
        }
        /// <summary>
        /// <summary>
        /// Danh sách quyền
        /// </summary>
        /// <param name="url">Địa chỉ api</param>
        /// <param name="model"></param>
        /// <param name="context"></param>
        /// <param name="token">Mã token từ sign in</param>
        /// <returns></returns>
        public static async Task<List<MenuFunctionModel>> Permissions(string url, AccountPermissionModel model, HttpContext context, string token = "")
        {
            var identify = string.Format(CacheConfig.Kz_User_MenuFunctionCache_Key, model.AccountId, SecurityModel.Cache_Key);

            var permissions = new List<MenuFunctionModel>();

            //Kiểm tra tồn tại
            var existed = CacheFunction.TryGet<List<MenuFunctionModel>>(context, identify, out permissions);
            if (existed == false)
            {
                permissions = new List<MenuFunctionModel>();

                var response = await ApiHelper.HttpPost<AccountPermissionModel>(url, model, token);

                if (response.IsSuccessStatusCode)
                {
                    permissions = await ApiHelper.ConvertResponse<List<MenuFunctionModel>>(response);

                    //Save lạ vào cache
                    CacheFunction.Add<List<MenuFunctionModel>>(context, identify, permissions, CacheConfig.Kz_User_MenuFunctionCache_Time);

                    return permissions;
                }
                else
                {
                    return permissions;
                }
            }

            return permissions;
        }

        /// <summary>
        /// Lấy danh sách úng dụng mà tk của tk
        /// </summary>
        /// <param name="url">api url</param>
        /// <param name="model"></param>
        /// <param name="context"></param>
        /// <param name="token">mã token từ api sign in</param>
        /// <returns></returns>
        public static async Task<List<MenuFunctionModel>> AppFunctions (string url, AccountPermissionModel model, HttpContext context, string token = "")
        {
            var identify = string.Format(CacheConfig.Kz_User_AppFunctionCache_Key, model.AccountId, SecurityModel.Cache_Key);

            var permissions = new List<MenuFunctionModel>();

            //Kiểm tra tồn tại
            var existed = CacheFunction.TryGet<List<MenuFunctionModel>>(context, identify, out permissions);
            if (existed == false)
            {
                permissions = new List<MenuFunctionModel>();

                var response = await ApiHelper.HttpPost<AccountPermissionModel>(url, model, token);

                if (response.IsSuccessStatusCode)
                {
                    permissions = await ApiHelper.ConvertResponse<List<MenuFunctionModel>>(response);

                    //Save lạ vào cache
                    CacheFunction.Add<List<MenuFunctionModel>>(context, identify, permissions, CacheConfig.Kz_User_MenuFunctionCache_Time);

                    return permissions;
                }
                else
                {
                    return permissions;
                }
            }

            return permissions;
        }

        /// <summary>
        /// Lấy thông tin tk theo url api
        /// </summary>
        /// <param name="url">địa chỉ api</param>
        /// <param name="token">Mã token</param>
        /// <returns></returns>
        public static async Task<AccountInfoModel> AccountInfo(string url, string token)
        {
            var response = await ApiHelper.HttpGet(url, token);

            if (response.IsSuccessStatusCode)
            {
                return await ApiHelper.ConvertResponse<AccountInfoModel>(response);
            }
            else
            {
                return await Task.FromResult(new AccountInfoModel());
            }
        }

        /// <summary>
        /// Cập nhật tk theo api
        /// </summary>
        /// <param name="url">api</param>
        /// <param name="model"></param>
        /// <param name="token">mã token</param>
        /// <returns></returns>
        public static async Task<MessageReport> UpdateAccountInfo(string url, AccountInfoModel model, string token)
        {
            var response = await ApiHelper.HttpPut<AccountInfoModel>(url, model, token);

            if (response.IsSuccessStatusCode)
            {
                return await ApiHelper.ConvertResponse<MessageReport>(response);
            }
            else
            {
                return await Task.FromResult(new MessageReport(false, "Mã lỗi: " + response.StatusCode + " - Chi tiết: " + await response.Content.ReadAsStringAsync()));
            }
        }

        /// <summary>
        /// Lưu, hiển thị các cột của table cấu hình theo account
        /// </summary>
        /// <param name="url">địa chỉ api</param>
        /// <param name="model"></param>
        /// <param name="token">Mã token</param>
        /// <returns></returns>
        public static async Task<List<DisplayModel>> DisplayInfo(string url, AccountColumnModel model, string token)
        {
            var response = await ApiHelper.HttpPost<AccountColumnModel>(url, model, token);

            if (response.IsSuccessStatusCode)
            {
                return await ApiHelper.ConvertResponse<List<DisplayModel>>(response);
            }
            else
            {
                return await Task.FromResult(new List<DisplayModel> ());
            }
        }

        /// <summary>
        /// Lưu sự kiện của hệ thống
        /// </summary>
        /// <param name="actiontype">Mã hành động</param>
        /// <param name="tablename">Tên bảng</param>
        /// <param name="recordid">Id bản ghi</param>
        /// <param name="content">Nội dung bản ghi serialize</param>
        /// <param name="context"></param>
        /// <param name="appcode">mã ứng dụng</param>
        /// <returns></returns>
        public static async Task<MessageReport> EventLog(string actiontype, string tablename, string recordid, string content, HttpContext context, string appcode)
        {
            var result = new MessageReport(false, "error");

            var url = await AppSettingHelper.GetStringFromAppSetting("WebApi:EventLog");

            //Lấy người dùng hiện tại
            var objToken = await SessionCookieHelper.CurrentTokenAuth(context);

            //Lấy địa chỉ IP
            var pcname =Dns.GetHostEntry(context.Connection.RemoteIpAddress).HostName;

            //Lấy plaform kh
            var userAgent = context.Request.Headers["User-Agent"].FirstOrDefault();

            //Mapping
            var model = new AccountEventLog()
            {
                ActionType = actiontype,
                TableName = tablename,
                RecordId = recordid,
                Content = content,

                AccountId = objToken != null ? objToken.Identifier : "",
                AppCode = appcode,

                UserAgent = !string.IsNullOrWhiteSpace(userAgent) ? userAgent : "",
                Address = !string.IsNullOrWhiteSpace(pcname) ? pcname : ""
            };

            var response = await ApiHelper.HttpPost<AccountEventLog>(url, model, objToken != null ? objToken.Token : "");

            if (response.IsSuccessStatusCode)
            {
                result = await ApiHelper.ConvertResponse<MessageReport>(response);
                return result;
            }
            else
            {
                var re = new MessageReport(false, "Mã lỗi: " + response.StatusCode + " - Chi tiết: " + await response.Content.ReadAsStringAsync());

                return await Task.FromResult(re);
            }
        }

        /// <summary>
        /// Trả lại sidebar của tài khoản
        /// </summary>
        /// <param name="appcode">Mã ứng dụng</param>
        /// <param name="controllername">Tên controller</param>
        /// <param name="actionname">Tên action</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<SidebarModel> GetSidebar(string appcode, string controllername, string actionname, HttpContext context)
        {
            return null; // Tam thời trả về null, xử lý lại hàm này sau

            var model = new SidebarModel()
            {
                ControllerName = controllername,
                ActionName = actionname,
            };

            //Lấy token từ cookie
            var objToken = await SessionCookieHelper.CurrentTokenAuth(context);

            if (objToken != null)
            {
                //Lấy thông tin trên cookie
                model.AccountInfo = await SessionCookieHelper.CurrentAccount(context);

                //Lấy danh sách menu
                model.Data = await AuthHelper.Permissions(await AppSettingHelper.GetStringFromAppSetting("WebApi:Permissions"), new AccountPermissionModel()
                {
                    AccountId = objToken.Identifier,
                    AppCode = appcode,
                    isAdmin = model.AccountInfo != null ? model.AccountInfo.IsAdmin : false
                }, context, objToken.Token);

                //Lấy danh sách app của tk
                var funcs = await AuthHelper.AppFunctions(await AppSettingHelper.GetStringFromAppSetting("WebApi:AppFunctions"), new AccountPermissionModel()
                {
                    AccountId = objToken.Identifier,
                    AppCode = appcode,
                    isAdmin = model.AccountInfo != null ? model.AccountInfo.IsAdmin : false
                }, context, objToken.Token);

                //Mã ứng dụng hiện tại
                var rootApp = funcs.FirstOrDefault(n => n.AppCode == appcode);
                if (rootApp != null)
                {
                    model.RootAppId = rootApp.Id;
                }

                //View hiện tại
                model.CurrentView = model.Data.FirstOrDefault(n => n.ControllerName.Equals(controllername) && n.ActionName.Equals(actionname));

                //Trả lại breadcrumb 
                model.Breadcrumb = model.CurrentView != null ? !string.IsNullOrWhiteSpace(model.CurrentView.Breadcrumb) ? model.CurrentView.Breadcrumb : "" : "";

            }

            return model;
        }
    }
}
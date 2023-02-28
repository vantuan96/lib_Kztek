using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eazy_library.Configs;
using eazy_library.Models;
using eazy_library.Security;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace eazy_library.Helpers
{
    public class SessionCookieHelper
    {
        public static Task<SessionModel> CurrentUser(HttpContext HttpContext)
        {
            var model = new SessionModel();

            //Lấy session
            var sessionValue = HttpContext.Session.GetString(SessionConfig.Kz_UserSession);

            //Kiểm tra tồn tại => chuyển sang lấy cookie
            if (string.IsNullOrWhiteSpace(sessionValue))
            {
                //Kiểm tra cookie
                var cookieValue = HttpContext.Request.Cookies[CookieConfig.Kz_UserCookie];

                if (string.IsNullOrWhiteSpace(cookieValue))
                {
                    model = null;
                }
                else
                {
                    //Giải mã
                    var decryptModel = CryptoHelper.DecryptSessionCookie_User(cookieValue);

                    if (!string.IsNullOrWhiteSpace(decryptModel))
                    {
                        model = JsonConvert.DeserializeObject<SessionModel>(decryptModel);

                        //Lưu lại thằng session, mã hóa lại thông tin
                        var encryptModel = CryptoHelper.EncryptSessionCookie_User(JsonConvert.SerializeObject(model));

                        HttpContext.Session.SetString(SessionConfig.Kz_UserSession, encryptModel);
                    }
                    else
                    {
                        model = null;
                    }
                }
            }
            else
            {
                //Giải mã
                var decryptModel = CryptoHelper.DecryptSessionCookie_User(sessionValue);

                if (!string.IsNullOrWhiteSpace(decryptModel))
                {
                    model = JsonConvert.DeserializeObject<SessionModel>(decryptModel);
                }
                else
                {
                    model = null;
                }


            }

            return Task.FromResult(model);
        }

        public static Task<SessionModel> CurrentAdmin(HttpContext HttpContext)
        {
            var model = new SessionModel();

            //Lấy session
            var sessionValue = HttpContext.Session.GetString(SessionConfig.Kz_AdminSession);

            //Kiểm tra tồn tại => null
            if (string.IsNullOrWhiteSpace(sessionValue))
            {
                model = null;
            }
            else
            {
                //Giải mã
                var decryptModel = CryptoHelper.DecryptSessionCookie_Admin(sessionValue);

                if (!string.IsNullOrWhiteSpace(decryptModel))
                {
                    model = JsonConvert.DeserializeObject<SessionModel>(decryptModel);
                }
                else
                {
                    model = null;
                }
            }

            return Task.FromResult(model);
        }

        public static Task<string> CurrentArea(HttpContext HttpContext)
        {
            var AreaCode = "";

            //Kiểm tra cookie
            var cookieValue = HttpContext.Request.Cookies[CookieConfig.Kz_AreaCookie];

            AreaCode = string.IsNullOrWhiteSpace(cookieValue) ? "Parking" : cookieValue;

            return Task.FromResult(AreaCode);
        }

        public static Task<TokenModel> CurrentTokenAuth(HttpContext HttpContext)
        {
            var model = new TokenModel();

            //
            var cookieValue = HttpContext.Request.Cookies[CookieConfig.Kz_TokenCookie];

            if (string.IsNullOrWhiteSpace(cookieValue))
            {
                model = null;
            }
            else
            {
                //Giải mã 
                var decryptModel = CryptoHelper.DecryptToken(cookieValue);

                if (!string.IsNullOrWhiteSpace(decryptModel))
                {
                    model = JsonConvert.DeserializeObject<TokenModel>(decryptModel);
                }
                else
                {
                    model = null;
                }
            }

            return Task.FromResult(model);
        }

        public static Task<AccountInfoModel> CurrentAccount(HttpContext HttpContext)
        {
            var model = new AccountInfoModel();

            //
            ///
            var cookieValue = HttpContext.Request.Cookies[CookieConfig.Kz_AccountInfoCookie];

            if (string.IsNullOrWhiteSpace(cookieValue))
            {
                model = null;
            }
            else
            {
                //Giải mã
                var decryptModel = CryptoHelper.DecryptSessionCookie_User(cookieValue);

                if (!string.IsNullOrWhiteSpace(decryptModel))
                {
                    model = JsonConvert.DeserializeObject<AccountInfoModel>(decryptModel);
                    //check tổn tại ảnh
                    if (ApiHelper.CheckIsExistFile(model.Avatar))
                    {
                        model.ImagePath = model.ImagePath;
                    }
                    else
                    {
                        model.ImagePath = "";
                        model.Avatar = "";
                    }
                }
                else
                {
                    model = null;
                }
            }

            return Task.FromResult(model);
        }

        public static AccountInfoModel GetCurrentAccount(HttpContext HttpContext)
        {
            var model = new AccountInfoModel();

            //
            ///
            var cookieValue = HttpContext.Request.Cookies[CookieConfig.Kz_AccountInfoCookie];

            if (string.IsNullOrWhiteSpace(cookieValue))
            {
                model = null;
            }
            else
            {
                //Giải mã
                var decryptModel = CryptoHelper.DecryptSessionCookie_User(cookieValue);

                if (!string.IsNullOrWhiteSpace(decryptModel))
                {
                    model = JsonConvert.DeserializeObject<AccountInfoModel>(decryptModel);
                    //check tổn tại ảnh
                    if (ApiHelper.CheckIsExistFile(model.Avatar))
                    {
                        model.ImagePath = model.ImagePath;
                    }
                    else
                    {
                        model.ImagePath = "";
                        model.Avatar = "";
                    }
                }
                else
                {
                    model = null;
                }
            }

            return model;
        }


        public static Task<List<string>> SessionOnUse_ReturnIds(SelectListModel_Table_Id_Selected Model, HttpContext HttpContext)
        {
            var identify = string.Format("{0}_{1}_{2}", SessionConfig.Kz_TableSession, Model.ControllerName, Model.SessionType);

            var sessionValue = HttpContext.Session.GetString(identify);

            if (string.IsNullOrWhiteSpace(sessionValue))
            {
                HttpContext.Session.SetString(identify, JsonConvert.SerializeObject(Model.Ids));
            }
            else
            {
                var ids = JsonConvert.DeserializeObject<List<string>>(sessionValue);

                switch (Model.ActionType)
                {
                    case "ADD":

                        foreach (var item in Model.Ids)
                        {
                            if (!ids.Any(n => n == item))
                            {
                                ids.Add(item);
                            }
                        }

                        break;

                    case "REMOVE":

                        foreach (var item in Model.Ids)
                        {
                            if (ids.Any(n => n == item))
                            {
                                ids.Remove(item);
                            }
                        }

                        break;
                }

                Model.Ids = ids;

                HttpContext.Session.SetString(identify, JsonConvert.SerializeObject(Model.Ids));
            }

            return Task.FromResult(Model.Ids);
        }

        public static Task<List<DisplayModel>> SessionOnUse_ReturnTableDisplay(string ControllerName, List<string> NewConfigs, HttpContext HttpContext, string appcode)
        {
            var url = AppSettingHelper.GetStringFromAppSetting("WebApi:Displays").Result;

            var objToken = CurrentTokenAuth(HttpContext).Result;

            var ids = new List<DisplayModel>();

            var identify = string.Format("{0}_{1}_{2}_{3}", SessionConfig.Kz_TableSession, ControllerName, "Displays", objToken != null ? objToken.Identifier : "");

            var sessionValue = HttpContext.Session.GetString(identify);

            if (string.IsNullOrWhiteSpace(sessionValue))
            {
                //Kiểm tra có lưu cấu hình không
                var fromDBIds = AuthHelper.DisplayInfo(
                    url,
                    new AccountColumnModel()
                    {
                        AccountId = objToken != null ? objToken.Identifier : "",
                        AppCode = appcode,
                        ControllerName = ControllerName,
                        newconfigs = NewConfigs
                    },
                    objToken != null ? objToken.Token : "").Result;

                //Chưa có thì lấy từ gốc
                if (fromDBIds.Any() == false)
                {
                    //Lấy dữ liệu gốc
                    ids = ColumnStaticList.Default_Display(ControllerName);

                    //foreach (var item in ids)
                    //{
                    //    var obj = fromDBIds.FirstOrDefault(n => n.FieldName == item.FieldName);
                    //    if (obj != null)
                    //    {
                    //        item.IsDisplay = obj.IsDisplay;
                    //        item.IsDefault = obj.IsDefault;
                    //        item.IsSortable = obj.IsSortable;
                    //    }
                    //}
                }
                else
                {
                    ids = fromDBIds;
                }

                HttpContext.Session.SetString(identify, JsonConvert.SerializeObject(ids));
            }
            else
            {
                ids = JsonConvert.DeserializeObject<List<DisplayModel>>(sessionValue);

                if (NewConfigs.Any())
                {
                    //foreach (var item in NewConfigs)
                    //{
                    //    var values = item.Split('#', System.StringSplitOptions.RemoveEmptyEntries);

                    //    var obj = ids.FirstOrDefault(n => n.FieldName == values[0]);
                    //    if (obj != null)
                    //    {
                    //        obj.IsDisplay = Convert.ToBoolean(values[1]);
                    //    }
                    //}

                    ids = AuthHelper.DisplayInfo(
                    url,
                    new AccountColumnModel()
                    {
                        AccountId = objToken != null ? objToken.Identifier : "",
                        AppCode = appcode,
                        ControllerName = ControllerName,
                        newconfigs = NewConfigs
                    },
                    objToken != null ? objToken.Token : "").Result;

                    //if (ids.Any() == false)
                    //{
                    //    ids = ColumnStaticList.Default_Display(ControllerName);
                    //}
                }

                HttpContext.Session.SetString(identify, JsonConvert.SerializeObject(ids));
            }

            return Task.FromResult(ids);
        }

        public static async Task<string> Session_Language(HttpContext context, string selected = "en")
        {
            //Lấy tài khoản hiện tại
            var currentAccount = await CurrentAccount(context);

            var lang = "";

            try
            {
                //Lấy identify
                var identify = string.Format("{0}_{1}", SessionConfig.Kz_LanguageSession, currentAccount.Id);

                //Lấy dữ liệu
                var sessionValue = context.Session.GetString(identify);

                if (string.IsNullOrWhiteSpace(sessionValue))
                {
                    lang = selected;
                    context.Session.SetString(identify, selected);
                }
                else
                {
                    lang = sessionValue;
                }
            }
            catch
            {
                lang = "vi";
            }

            return await Task.FromResult(lang);
        }

   
        public static Task<List<DisplayModel>> SessionOnUse_ReturnTableDisplayV1(string ControllerName, List<DisplayModel> DefaultDisplays, List<string> NewConfigs, HttpContext HttpContext)
        {
            var ids = new List<DisplayModel>();

            var identify = string.Format("{0}_{1}_{2}", SessionConfig.Kz_TableSession, ControllerName, "Displays");

            var sessionValue = HttpContext.Session.GetString(identify);

            if (string.IsNullOrWhiteSpace(sessionValue))
            {
                ids = DefaultDisplays;

                HttpContext.Session.SetString(identify, JsonConvert.SerializeObject(ids));
            }
            else
            {
                ids = JsonConvert.DeserializeObject<List<DisplayModel>>(sessionValue);

                if (NewConfigs.Any())
                {
                    foreach (var item in NewConfigs)
                    {
                        var values = item.Split('#', System.StringSplitOptions.RemoveEmptyEntries);

                        var obj = ids.FirstOrDefault(n => n.FieldName == values[0]);
                        if (obj != null)
                        {
                            obj.IsDisplay = Convert.ToBoolean(values[1]);
                        }
                    }
                }

                HttpContext.Session.SetString(identify, JsonConvert.SerializeObject(ids));
            }

            return Task.FromResult(ids);
        }
        public static Task<List<DisplayModel>> SessionOnUse_ReturnTableDisplayV2(string ControllerName, List<DisplayModel> DefaultDisplays, List<string> NewConfigs, HttpContext HttpContext)
        {
            var ids = new List<DisplayModel>();

            var identify = string.Format("{0}_{1}_{2}", SessionConfig.Kz_TableSession, ControllerName, "Displays");

            var sessionValue = HttpContext.Session.GetString(identify);

            if (string.IsNullOrWhiteSpace(sessionValue))
            {
                ids = DefaultDisplays;

                HttpContext.Session.SetString(identify, JsonConvert.SerializeObject(ids));
            }
            else
            {
                ids = JsonConvert.DeserializeObject<List<DisplayModel>>(sessionValue);

                if (NewConfigs.Any())
                {
                    foreach (var item in NewConfigs)
                    {
                        var values = item.Split('#', System.StringSplitOptions.RemoveEmptyEntries);

                        var obj = ids.FirstOrDefault(n => n.FieldName == values[0]);
                        if (obj != null)
                        {
                            obj.IsDisplay = Convert.ToBoolean(values[1]);
                        }
                    }
                }

                HttpContext.Session.SetString(identify, JsonConvert.SerializeObject(ids));
            }

            return Task.FromResult(ids);
        }
    }
}
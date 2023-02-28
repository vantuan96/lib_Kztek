using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using eazy_library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace eazy_library.Helpers
{
    public class LanguageHelper
    {
        public static async Task<string> GetLanguageText(string path)
        {
            var region = await AppSettingHelper.GetStringFromAppSetting("Languages");
            path = $"{path}:{region}";
            var text = await AppSettingHelper.GetStringFromFileJson("Languages/languages", path);

            text = string.IsNullOrWhiteSpace(text) ? "" : text;

            return text;
        }

        public static async Task<string> GetMenuLanguageText(string path)
        {
            var region = await AppSettingHelper.GetStringFromAppSetting("Languages");
            path = $"{path}:{region}";
            var text = await AppSettingHelper.GetStringFromFileJson("Languages/menu-languages", path);

            text = string.IsNullOrWhiteSpace(text) ? "" : text;

            return text;
        }

        public static class MESSAGES
        {
            public static async Task<string> CREATE_SUCCESS(HttpContext context)
            {
                var lang = await GetCurrentLanguage(context);
                var file = string.Format("lang-{0}.json", lang);
                var value = GetValueFromFileJson(file, "MESSAGES:ACTIONS:CREATE:SUCCESS");

                return value;
            }

            public static async Task<string> UPDATE_SUCCESS(HttpContext context)
            {
                var lang = await GetCurrentLanguage(context);
                var file = string.Format("lang-{0}.json", lang);
                var value = GetValueFromFileJson(file, "MESSAGES:ACTIONS:UPDATE:SUCCESS");

                return value;
            }

            public static async Task<string> DELETE_SUCCESS(HttpContext context)
            {
                var lang = await GetCurrentLanguage(context);
                var file = string.Format("lang-{0}.json", lang);
                var value = GetValueFromFileJson(file, "MESSAGES:ACTIONS:DELETE:SUCCESS");

                return value;
            }
        }

        public static class FIELDS
        {
            public static async Task<string> Name(HttpContext context, string classname = "", string fieldname = "")
            {
                var lang = await GetCurrentLanguage(context);
                var file = string.Format("lang-{0}.json", lang);
                var value = GetValueFromFileJson(file, "FIELDS:" + classname + ":" + fieldname);

                return value;
            }
        }

        public static class TITLES
        {
            public static async Task<string> Name(HttpContext context, string classname = "", string type = "")
            {
                var lang = await GetCurrentLanguage(context);
                var file = string.Format("lang-{0}.json", lang);
                var value = GetValueFromFileJson(file, "TITLES:" + classname + ":" + type);

                return value;
            }
        }

        public static class PLACEHOLDERS
        {
            public static async Task<string> Name(HttpContext context, string classname = "", string type = "")
            {
                var lang = await GetCurrentLanguage(context);
                var file = string.Format("lang-{0}.json", lang);
                var value = GetValueFromFileJson(file, "PLACEHOLDERS:" + classname + ":" + type);

                return value;
            }
        }

        public static class BUTTONS
        {
            public static async Task<string> Name(HttpContext context, string key = "")
            {
                var lang = await GetCurrentLanguage(context);
                var file = string.Format("lang-{0}.json", lang);
                var value = GetValueFromFileJson(file, "BUTTONS:" + key);

                return value;
            }
        }

        public static class MENUS
        {
            public static async Task<string> Name(HttpContext context, string controllername = "", string actionname = "")
            {
                var lang = await GetCurrentLanguage(context);
                var file = string.Format("lang-{0}.json", lang);
                var value = GetValueFromFileJson(file, "MENUS:" + controllername + ":" + actionname);

                return value;
            }
        }

        public static class TABLES
        {
            public static async Task<string> Name(HttpContext context, string controllername = "", string fieldname = "")
            {
                var lang = await GetCurrentLanguage(context);
                var file = string.Format("lang-{0}.json", lang);
                var value = GetValueFromFileJson(file, "TABLES:" + controllername + ":" + fieldname);

                return value;
            }
        }

        public static class SELECTS
        {
            public static async Task<string> Name(HttpContext context, string key = "")
            {
                var lang = await GetCurrentLanguage(context);
                var file = string.Format("lang-{0}.json", lang);
                var value = GetValueFromFileJson(file, "SELECTS:" + key);

                return value;
            }
        }

        public static class APIS
        {
            public static async Task<string> Name(string lang, string key = "")
            {
                var file = string.Format("lang-{0}.json", lang);
                var value = GetValueFromFileJson(file, "APIS:" + key);

                return await Task.FromResult(value);
            }
        }

        private static async Task<string> GetCurrentLanguage(HttpContext context)
        {
            var account = await SessionCookieHelper.CurrentAccount(context);
            var lang = await SessionCookieHelper.Session_Language(context, account != null ? "" : "vi");

            lang = !string.IsNullOrWhiteSpace(lang) ? lang : await AppSettingHelper.GetStringFromAppSetting("Web:Default-Language");

            return lang;
        }

        private static string GetValueFromFileJson(string file, string key)
        {
            var value = "";

            try
            {
                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/langs/" + file);
                configurationBuilder.AddJsonFile(path, false);

                var root = configurationBuilder.Build();
                value = root[key];
            }
            catch (Exception ex)
            {
                value = ex.Message;
            }

            return value;
        }
    
    }
}

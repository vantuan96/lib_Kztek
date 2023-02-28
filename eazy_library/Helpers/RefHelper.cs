using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eazy_library.Models;
using Microsoft.AspNetCore.Http;

namespace eazy_library.Helpers
{
    public class RefHelper
    {
        public static class Account
        {
            public static async Task<List<AccountInfoModel>> GetByIds(string url, List<string> ids, HttpContext context)
            {
                var objToken = await SessionCookieHelper.CurrentTokenAuth(context);

                var response = await ApiHelper.HttpPost<List<string>>(url, ids, objToken != null ? objToken.Token : "");

                if (response.IsSuccessStatusCode)
                {
                    return await ApiHelper.ConvertResponse<List<AccountInfoModel>>(response);
                }
                else
                {
                    return await Task.FromResult(new List<AccountInfoModel>());
                }
            }

            public static async Task<List<AutoCompleteModel>> SuggestionList(string url, string key, HttpContext context)
            {
                var objToken = await SessionCookieHelper.CurrentTokenAuth(context);

                var response = await ApiHelper.HttpGet(url + "?key=" + key, objToken != null ? objToken.Token : "");

                if (response.IsSuccessStatusCode)
                {
                    return await ApiHelper.ConvertResponse<List<AutoCompleteModel>>(response);
                }
                else
                {
                    return await Task.FromResult(new List<AutoCompleteModel>());
                }
            }

            public static async Task<List<AccountInfoModel>> DataAccountsByAccountId(string url, string accountid, HttpContext context)
            {
                var objToken = await SessionCookieHelper.CurrentTokenAuth(context);

                var response = await ApiHelper.HttpGet(url + "/" + accountid, objToken != null ? objToken.Token : "");

                if (response.IsSuccessStatusCode)
                {
                    return await ApiHelper.ConvertResponse<List<AccountInfoModel>>(response);
                }
                else
                {
                    return await Task.FromResult(new List<AccountInfoModel>());
                }
            }

            public static async Task<List<AccountInfoModel>> DataAccountsByOrganizationId(string url, string organizationid, string locationid, HttpContext context)
            {
                var objToken = await SessionCookieHelper.CurrentTokenAuth(context);

                var response = await ApiHelper.HttpGet(url + "/" + organizationid + "?locationid=" + locationid, objToken != null ? objToken.Token : "");

                if (response.IsSuccessStatusCode)
                {
                    return await ApiHelper.ConvertResponse<List<AccountInfoModel>>(response);
                }
                else
                {
                    return await Task.FromResult(new List<AccountInfoModel>());
                }
            }
        }

        public static class Location
        {
            public static async Task<SelectListModel_Chosen> SelectList(string url, HttpContext context)
            {
                var objToken = await SessionCookieHelper.CurrentTokenAuth(context);

                var response = await ApiHelper.HttpGet(url, objToken != null ? objToken.Token : "");

                if (response.IsSuccessStatusCode)
                {
                    return await ApiHelper.ConvertResponse<SelectListModel_Chosen>(response);
                }
                else
                {

                    return await Task.FromResult(new SelectListModel_Chosen());
                }
            }

            public static async Task<LocationModel> GetById(string url, HttpContext context)
            {
                var objToken = await SessionCookieHelper.CurrentTokenAuth(context);

                var response = await ApiHelper.HttpGet(url, objToken != null ? objToken.Token : "");

                if (response.IsSuccessStatusCode)
                {
                    return await ApiHelper.ConvertResponse<LocationModel>(response);
                }
                else
                {

                    return await Task.FromResult(new LocationModel());
                }
            }
        }

        public static class DashboardStage
        {
            public static async Task<SelectListModel_Chosen> SelectList(string url, HttpContext context)
            {
                var objToken = await SessionCookieHelper.CurrentTokenAuth(context);

                var response = await ApiHelper.HttpGet(url, objToken != null ? objToken.Token : "");

                if (response.IsSuccessStatusCode)
                {
                    return await ApiHelper.ConvertResponse<SelectListModel_Chosen>(response);
                }
                else
                {

                    return await Task.FromResult(new SelectListModel_Chosen());
                }
            }

            public static async Task<List<KanbanModel>> KanbanList(string url, HttpContext context)
            {
                var objToken = await SessionCookieHelper.CurrentTokenAuth(context);

                var response = await ApiHelper.HttpGet(url, objToken != null ? objToken.Token : "");

                if (response.IsSuccessStatusCode)
                {
                    return await ApiHelper.ConvertResponse<List<KanbanModel>>(response);
                }
                else
                {

                    return await Task.FromResult(new List<KanbanModel>());
                }
            }

            public static async Task<List<Sortable_BoardModel>> SortableList(string url, HttpContext context)
            {
                var objToken = await SessionCookieHelper.CurrentTokenAuth(context);

                var response = await ApiHelper.HttpGet(url, objToken != null ? objToken.Token : "");

                if (response.IsSuccessStatusCode)
                {
                    return await ApiHelper.ConvertResponse<List<Sortable_BoardModel>>(response);
                }
                else
                {

                    return await Task.FromResult(new List<Sortable_BoardModel>());
                }
            }

            public static async Task<List<Sortable_BoardModel>> SortableList(string url, string token)
            {
                var response = await ApiHelper.HttpGet(url, token);

                if (response.IsSuccessStatusCode)
                {
                    return await ApiHelper.ConvertResponse<List<Sortable_BoardModel>>(response);
                }
                else
                {

                    return await Task.FromResult(new List<Sortable_BoardModel>());
                }
            }
        }

        public static class Bank
        {
            public static async Task<string> Account(string url, HttpContext context)
            {
                var objToken = await SessionCookieHelper.CurrentTokenAuth(context);

                var response = await ApiHelper.HttpGet(url, objToken != null ? objToken.Token : "");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return await Task.FromResult("");
                }
            }
        }

        public static class Organization
        {
            public static async Task<List<OrganizationModel>> ListData(string url, HttpContext context)
            {
                var objToken = await SessionCookieHelper.CurrentTokenAuth(context);

                var response = await ApiHelper.HttpGet(url, objToken != null ? objToken.Token : "");

                if (response.IsSuccessStatusCode)
                {
                    return await ApiHelper.ConvertResponse<List<OrganizationModel>>(response);
                }
                else
                {

                    return await Task.FromResult(new List<OrganizationModel>());
                }
            }

            public static async Task<SelectListModel_Chosen> SelectList(string url, HttpContext context)
            {
                var objToken = await SessionCookieHelper.CurrentTokenAuth(context);

                var response = await ApiHelper.HttpGet(url, objToken != null ? objToken.Token : "");

                if (response.IsSuccessStatusCode)
                {
                    return await ApiHelper.ConvertResponse<SelectListModel_Chosen>(response);
                }
                else
                {

                    return await Task.FromResult(new SelectListModel_Chosen());
                }
            }

            public static async Task<OrganizationModel> GetById(string url, HttpContext context)
            {
                var objToken = await SessionCookieHelper.CurrentTokenAuth(context);

                var response = await ApiHelper.HttpGet(url, objToken != null ? objToken.Token : "");

                if (response.IsSuccessStatusCode)
                {
                    return await ApiHelper.ConvertResponse<OrganizationModel>(response);
                }
                else
                {

                    return await Task.FromResult(new OrganizationModel());
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace eazy_library.Models
{
    public class SidebarModel
    {
        public string Id { get; set; } = "";

        public string ControllerName { get; set; } = "";

        public string ActionName { get; set; } = "";

        public List<MenuFunctionModel> Data { get; set; } = new List<MenuFunctionModel>();

        public List<MenuFunctionModel> Data_Child { get; set; } = new List<MenuFunctionModel>();
       
        public MenuFunctionModel CurrentView { get; set; } = null;

        public string Breadcrumb { get; set; } = "";

        public string RootAppId { get; set; } = "";

        public AccountInfoModel AccountInfo { get; set; }

        public string ParentId { get; set; }

        public string CurrentParentId { get; set; }
    }
}

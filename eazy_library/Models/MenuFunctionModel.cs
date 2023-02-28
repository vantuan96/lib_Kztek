using System;
namespace eazy_library.Models
{
    public class MenuFunctionModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string AppCode { get; set; }

        public string MenuType { get; set; }

        public string ParentId { get; set; }

        public string Icon { get; set; }

        public bool Active { get; set; }

        public string Breadcrumb { get; set; }

        public int Dept { get; set; }

        public int SortOrder { get; set; }
    }
}

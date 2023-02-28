using System;

namespace eazy_library.Models
{
    public class AuthPartialModel
    {
        public AuthActionModel Auth_Value { get; set; }

        public object model { get; set; }

        public string ControllerName { get; set; } = "";

        public string ActionName { get; set; } = "";

        public string RecordId { get; set; } = "";

        public string FunctionName { get; set; } = "Index";

        public bool IsUsingAjax { get; set; } = false;

        public string AjaxUrl { get; set; } = "";

        public string UrlReturnPage { get; set; } = "";

        public bool IsEdit { get; set; } = true;
    }
}

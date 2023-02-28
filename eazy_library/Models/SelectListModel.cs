using System.Collections.Generic;

namespace eazy_library.Models
{
    public class SelectListModel
    {
        public string ItemValue { get; set; }

        public string ItemText { get; set; }
    }

    public class SelectListModel_Breadcrumb
    {
        public string MenuName { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public bool isFolder { get; set; }
    }

    public class SelectListModel_Print_Header
    {
        public string ItemText { get; set; }
    }

    public class SelectListModel_Print_Column_Header
    {
        public string ItemText { get; set; }
    }

    public class SelectListModel_Chosen
    {
        public string IdSelectList { get; set; }

        public List<SelectListModel> Data { get; set; }

        public string Selecteds { get; set; }

        public bool isMultiSelect { get; set; } = false;

        public string Placeholder { get; set; }

        public bool IsDisable { get; set; } = false;
    }

    public class SelectListModel_Multi
    {
        public string IdSelectList { get; set; }

        public List<SelectListModel> Data { get; set; }

        public string Selecteds { get; set; }

        public string Placeholder { get; set; }
    }

    public class SelectListModel_MenuGroup
    {
        public string ItemValue { get; set; }

        public string ItemText { get; set; }

        public int ItemIndex { get; set; }

        public string ItemCode { get; set; }

        public string Icon { get; set; }

        public string Color { get; set; }

        public string AreaName { get; set; }

        public string Layout { get; set; }

        public string Label { get; set; } = "";
    }

    public class SelectListModel_Communication
    {
        public int ItemValue { get; set; }

        public string ItemText { get; set; }
    }
    public class SelectListModel_Communication1
    {
        public string ItemValue { get; set; }

        public string ItemText { get; set; }
    }
    public class SelectListModel_Communication2
    {
        public int ItemValue { get; set; }

        public int ItemText { get; set; }
    }
    public class SelectListModelAutocomplete
    {
        //Id
        public string id { get; set; }

        //Tên tìm thêm
        public string name { get; set; }

        //Tên hiển thị
        public string value { get; set; }
    }

    public class SelectListModel_FileUpload
    {
        public string FileUploadName { get; set; }

        public string BoxRenderId { get; set; }

        public string Base64String { get; set; }

        public string FilePath { get; set; }

        public string ObjectID { get; set; }
    }

    public class SelectListModel_Date
    {
        public string fromdate { get; set; }

        public string todate { get; set; }
    }

    public class SelectListModel_Table_Id_Selected
    {
        public string ControllerName { get; set; } //Trên chức năng nào

        public string SessionType { get; set; } //Lưu cho cái gì

        public List<string> Ids { get; set; }

        public string ActionType { get; set; } //ADD - REMOVE
    }

    public class SelectListModel_Form_Multi
    {
        public string Name { get; set; }

        public SelectListModel_Chosen Data { get; set; }

        public bool IsDatetimeSelect { get; set; } = false;
    }

    public class SelectListModel_Input
    {
        public string Input_Name { get; set; }

        public string Input_Text { get; set; }

        public string Input_Value { get; set; }
    }

    public class SelectListModel_Slide
    {
        public string Div_Id { get; set; }

        public string Div_Name { get; set; }

        //public int MinValue { get; set; }

        // public int MaxValue { get; set; }

        //public int FromValue { get; set; }

        public string Div_hidFromValue { get; set; }

        //public int ToValue { get; set; }

        public string Div_hidToValue { get; set; }

        public bool IsUsing { get; set; }
    }

    public class SelectListModel_AutoComplete
    {
        public string Name { get; set; } //Hiển thị

        public string Input_Name { get; set; } //input name

        public string Input_Display { get; set; } //Hiển thị => email

        public string Input_Hidden { get; set; } //Giá trị ẩn

        public string Input_Placeholder { get; set; } //Hiển thị mô tả

        public string Url { get; set; } //Url hiển thị ajax xử lý auto
    }

    public class SelectListModel_InvoiceStatus
    {
        public string ItemValue { get; set; }

        public string ItemText { get; set; }

        public string ItemColor { get; set; }
    }

    public class SelectListModel_ProjectStatus
    {
        public string ItemValue { get; set; }

        public string ItemText { get; set; }

        public string ItemColor { get; set; }

        public string ColumnColor { get; set; }

        public string ButtonColor { get; set; }
    }

    public class SelectListModel_Kanban
    {
        public string ItemValue { get; set; }

        public string ItemText { get; set; }

        public string ItemColor { get; set; }

        public string ColumnColor { get; set; }

        public string ButtonColor { get; set; }
    }

    public class SelectListModel_Chosen_Kanban
    {
        public string IdSelectList { get; set; }

        public string Selected { get; set; }

        public List<SelectListModel_Kanban> Data { get; set; }
    }
}
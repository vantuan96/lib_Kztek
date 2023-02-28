using System;
using System.Collections.Generic;
using System.Data;

namespace eazy_library.Models
{
    public class TableModel
    {
        public DataTable Content { get; set; } //Nội dung của bảng dạng Datatable

        public List<DisplayModel> Displays { get; set; } = new List<DisplayModel>(); //Danh sách hiển thị các cột

        public int PageIndex { get; set; } = 1; //Trang hiện tại

        public int PageSize { get; set; } = 10; //Bao nhiêu bản ghi trên một trang

        public int TotalPage { get; set; } = 0; //Bao nhiểu trang

        public int TotalItem { get; set; } = 0; //Tổng số bản ghi

        public string ControllerName { get; set; } = ""; //Controller mà sử dụng

        public string ActionName { get; set; } = ""; //Action, thường là Index

        public string KeySearch { get; set; } = ""; //Từ khóa tìm kiếm

        public string UrlFormSubmit { get; set; } = ""; //Url để khi ấn submit sẽ trỏ tới đâu

        public string UrlUpdate { get; set; } = ""; //Url trang update

        public string UrlDelete { get; set; } = ""; //Url xóa, ajax

        public string UrlMultiDelete { get; set; } = ""; //Url xóa, ajax

        public string UrlReloadPage { get; set; } = ""; //Url load lại trang

        public string Sort { get; set; } = ""; //Cột đang sort format Column$desc/asc

        public bool IsFullScreen { get; set; } = false; //Chế đọ toàn màn hình

        public bool IsImport { get; set; } = false; //Có chức năng import excel

        public bool IsExport { get; set; } = false; //Có chức năng xuất excel

        public bool IsPrint { get; set; } = false; //Có chức năng xuất pdf

        public bool IsCopyData { get; set; } = false; //Có chức năng copy data tạo ra mới => tùy từng nghiệp vụ mà copy sẽ khác nhau

        public bool IsHaveQuickDetail { get; set; } = false; //Có chức năng xem nhanh, khi ấn hiển thị ngay bên dưới

        public List<string> SelectedIds { get; set; } = new List<string>();//Danh sách Id đã chọn, lưu vào session

        public AuthActionModel AuthAction { get; set; } //Danh sách quyền đi theo chức năng này

        public bool IsAdvanceSearch { get; set; } //Có dùng bảng tìm kiếm nâng cao

        public List<SelectListModel_Form_Multi> SelectList_Multi { get; set; } //Danh sách các select tìm kiếm

        public List<SelectListModel_Input> List_Input { get; set; } //Danh sách ô tìm kiếm dạng input

        public string MoreSearch { get; set; } = ""; //Lưu lại dữ liệu search nâng cao

        public string TimeSearch { get; set; } = ""; //Lưu lại dữ liệu search nâng cao - đinh dạng time

        public string RangeSearch { get; set; } = ""; //Lưu lại dữ liệu search nâng cao - đinh dạng range, tìm theo khoảng

        public string AppCode { get; set; } = ""; //mã ứng dụng

        public bool IsDisplayMultiDeleteButton { get; set; } = false; //Có hiển thị nút xóa nhiều

        public bool IsHaveModalPreview { get; set; } = false; //Có chức năng hiển thị chi tiết dạng modal

        public string UrlModalPreview { get; set; } = ""; //Url để dùng cho việc lấy thông tin

        public string ModalDetailId { get; set; } = ""; //Id modal detail trên để jquery gọi được.

        public string UrlQuickPreview { get; set; } = "";

        public bool IsDisplayFunctionCog { get; set; } = true; //Có hiển thị chức năng cập nhật, xóa

        public bool IsDisplayFunctionCogUpdate { get; set; } = false; //hiện thị nút cập nhật

     
        public string ModalImportId { get; set; } = ""; //Modal dùng cho việc import data

        public string ModalImportUrl { get; set; } = ""; //Url để gọi render modal

        public string ModalCopyId { get; set; } = ""; //Modal dùng cho việc copy data

        public string ModalCopyUrl { get; set; } = ""; //Url để gọi render modal

        public List<SelectListModel_Slide> Slide_Input { get; set; }

        public string AutoCompleteSearch { get; set; } = "";

        public List<SelectListModel_AutoComplete> AutoComplete_Input { get; set; }

        public bool IsDisplayColumnsSelectedButton { get; set; } = false; // Có hiển thị cho phép hiển thị các trường hay không?

        public bool IsShowDownloadButton { get; set; } = false;

        public bool IsDisplayDetailContentView { get; set; } = false; //hiện thị nút xem
    }

    public class THeadModel
    {
        public List<DisplayModel> Displays { get; set; } = new List<DisplayModel>();

        public bool IsExcel { get; set; } = false;

        public bool IsPrint { get; set; } = false;
    }

    public class TBodyModel
    {
        public DataTable Content { get; set; }

        public List<DisplayModel> Displays { get; set; } = new List<DisplayModel>();

        public string UrlData { get; set; } = "";

        public string UrlUpdate { get; set; } = "";

        public string UrlDelete { get; set; } = "";

        public bool IsHaveQuickDetail { get; set; } = false;
    }

    public class TFooterModel
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public int TotalPage { get; set; } = 0;

        public int TotalItem { get; set; } = 0;

        public string Paging_Controller { get; set; } = "";

        public string Paging_Action { get; set; } = "";
    }

    public class DisplayModel
    {
        public string FieldName { get; set; } = "";

        public string DisplayName { get; set; } = "";

        public bool IsDisplay { get; set; } = false;

        public bool IsDefault { get; set; } = false;

        public bool IsSortable { get; set; } = true;

        public bool IsUTC { get; set; } = false; //true => date dạng utc
    }
}

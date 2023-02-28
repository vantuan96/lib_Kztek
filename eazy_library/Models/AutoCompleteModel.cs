using System;
namespace eazy_library.Models
{
    public class AutoCompleteModel
    {
        public string value { get; set; } // Giá trị hiển thị ngoài giao diện

        public string data { get; set; } // Id đi theo value => cho on select
    }

    public class AutoCompleteModel_Component
    {
        public string InputPlaceholder { get; set; } //mô tả input

        public string UrlReturnData { get; set; } //Url lấy dữ liệu trả về từ input nhập vào

        public string UrlSelected { get; set; } //Gửi id chọn được từ autocomplete => tới chức năng nào

        public string UrlRemove { get; set; } //Gửi xóa sự bản ghi

        public string BoxRender { get; set; } //Dữ liệu load ra hiển thị chỗ nào
    }
}

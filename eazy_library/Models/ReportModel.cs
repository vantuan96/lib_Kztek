using System;
using System.Collections.Generic;

namespace eazy_library.Models
{
    public class ReportModel
    {
        public string DashboardId { get; set; }

        public string DashboardName { get; set; }

        public string DashboardColor { get; set; }

        public decimal EstimateValue { get; set; }

        public double Percent { get; set; }
    }

    public class ReportModel_Sales_Department
    {
        public string AccountId { get; set; }

        public string AccountName { get; set; }

        public List<ReportModel_Sales_Department_Detail> Details { get; set; }
    }

    public class ReportModel_Sales_Department_Detail
    {
        public string Id { get; set; } //Khóa chính

        public string AccountId { get; set; } //Thuộc người dùng nào

        public List<string> AccountIds { get; set; } //Người liên quan

        public DateTime DateCreated { get; set; } //Ngày tạo

        public DateTime DateEnd { get; set; } //Ngày kết thúc

        public string Title { get; set; } //Tên dự án

        public string SALES_EnterpriseId { get; set; } //Tổ chức => khách hàng, cty

        public string SALES_EnterpriseName { get; set; } //Tổ chức => khách hàng, cty

        public string SALES_ContactId { get; set; } //Liên hệ => lấy tên

        public string SALES_ContactName { get; set; } //Liên hệ => lấy tên

        public string SALES_ProjectType { get; set; } //Quan tâm tới || nội dung thực thiện

        public string SALES_ProjectTypeName { get; set; } //Quan tâm tới || nội dung thực thiện

        public List<ReportModel_WORK_Task_Dl> SALES_ProjectTypeNames { get; set; }

        public string SALES_ProjectStatus { get; set; } //Trạng thái công việc => theo list mới

        public string SALES_ProjectStatusName { get; set; } //Trạng thái công việc => theo list mới

        public decimal SALES_EstimateValue { get; set; } //Giá trị ước tính

        public string Reason { get; set; } //Lý do thắng/bại

        public decimal SALES_CustomerPercentBack { get; set; } //Hoa hồng khách hàng

        public string Note { get; set; } //Ghi chú
    }

    public class ReportModel_WORK_Project_Detail
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; } //Sắp xếp

        public List<ReportModel_WORK_Task_Stage> Stages { get; set; }

        public string Note { get; set; }
    }

    public class ReportModel_WORK_Task_Stage
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public List<ReportModel_WORK_Task_Detail> Tasks { get; set; }
    }

    public class ReportModel_WORK_Task_Detail
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string ProjectId { get; set; }

        public string DashboardStageId { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }
    }

    public class ReportModel_WORK_Task_Dl
    {
        public string Title { get; set; }

        public string AccountId { get; set; } //Tài khoản tạo
    }
}
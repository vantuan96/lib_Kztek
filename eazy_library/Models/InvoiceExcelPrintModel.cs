using System;
using System.Collections.Generic;

namespace eazy_library.Models
{
    public class InvoiceExcelPrintModel
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Note { get; set; }

        public string ProjectAddress { get; set; }

        public string ShippingAddress { get; set; }

        public string InvoiceAddress { get; set; }

        public string ContactId { get; set; }

        public string ContactName { get; set; }

        public string ContactEmail { get; set; }

        public string ContactPhone { get; set; }

        public string ContactFax { get; set; }

        public string ContactAddress { get; set; }

        public string AccountId { get; set; }

        public string AccountName { get; set; }

        public string AccountEmail { get; set; }

        public string AccountPhone { get; set; }

        public string AccountFax { get; set; }

        public string LocationId { get; set; }

        public string LocationName { get; set; }

        public decimal Amount { get; set; }

        public double TaxRate { get; set; }

        public decimal Tax { get; set; }

        public decimal Discount { get; set; }

        public string DiscountType { get; set; }

        public decimal Total { get; set; }

        public List<InvoiceExcelPrintModel_Group> Groups { get; set; } = new List<InvoiceExcelPrintModel_Group>();

        public List<InvoiceExcelPrintModel_Detail> Details { get; set; } = new List<InvoiceExcelPrintModel_Detail>();

        public DateTime DateNow { get; set; }

        public string ProjectType { get; set; }

        public string ProjectTypeNames { get; set; }

        public string BankAccount { get; set; } = "";

        public string Condition { get; set; } = "";
    }

    public class InvoiceExcelPrintModel_Group
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public int SortOrder { get; set; }

        public string InvoiceId { get; set; }
    }

    public class InvoiceExcelPrintModel_Detail
    {
        public string Id { get; set; }

        public string InvoiceId { get; set; }

        public string ProductId { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal Amount { get; set; }

        public decimal LaborAmount { get; set; }

        public decimal Discount { get; set; }

        public string DiscountType { get; set; }

        public decimal Total { get; set; }

        public string GroupId { get; set; }

        //public string SupplierId { get; set; }

        public string Supplier { get; set; } //Nhà cung cấp

        //public string CountryId { get; set; }

        public string CountryName { get; set; } //Quốc gia

        //public string UnitId { get; set; }

        public string UnitName { get; set; } //Đơn vị

        //Một sản phẩm tùy theo yêu cầu sẽ có phần labor => 1 sp => 1 labor thôi

        public string LaborId { get; set; } //Lấy từ bảng sản phẩm => với loại là nhân công

        public string LaborCode { get; set; } //Lấy từ bảng sản phẩm => với loại là nhân công

        public string LaborName { get; set; } //Lấy từ bảng sản phẩm => với loại là nhân công

        public string LaborDescription { get; set; } //Lấy từ bảng sản phẩm => với loại là nhân công

        public decimal LaborPrice { get; set; }

        public bool IsSoftware { get; set; }
    }
}

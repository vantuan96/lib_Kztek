using System;
using System.Collections.Generic;

namespace eazy_library.Models
{
    public class InvoiceDetailJS
    {
        public string InvoiceId { get; set; }

        public string Products { get; set; }

        public string IsLabor { get; set; } = "0";

        public string AddToProductId { get; set; } = "";
    }

    public class InvoiceProductJS
    {
        public string id { get; set; }

        public string code { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public bool issoftware { get; set; }

        public bool islabor { get; set; }
    }

    public class InvoiceRemoveJS
    {
        public string InvoiceId { get; set; }

        public string ProductId { get; set; }

        public string LaborId { get; set; }
    }

    public class InvoiceProductCalculatorJS
    {
        public string Price { get; set; }

        public string LaborPrice { get; set; }

        public int Quantity { get; set; }

        public string Record { get; set; }

        public string Records { get; set; }

        public string Tax { get; set; }

        public string Discount { get; set; }

        public string DiscountType { get; set; }
    }

    public class InvoiceDiscountCalculatorJS
    {
        public string InvoiceId { get; set; }

        public string Amount { get; set; }

        public string Tax { get; set; }

        public string Discount { get; set; }

        public string DiscountType { get; set; }
    }

    public class InvoiceStatusJS
    {
        public string InvoiceId { get; set; }

        public string Status { get; set; }
    }

    public class ProjectStatusJS
    {
        public string ProjectId { get; set; }

        public string Status { get; set; }
    }

    public class ProjectStageJS
    {
        public string ProjectId { get; set; }

        public string StageId { get; set; }
    }

    public class ProjectNoteJS
    {
        public string Id { get; set; }

        public string ProjectId { get; set; }

        public string Note { get; set; }
    }

    public class InvoiceProductDescriptionJS
    {
        public string InvoiceId { get; set; }

        public string Description { get; set; }
    }

    public class InvoiceGroupJS
    {
        public string InvoiceId { get; set; }

        public string GroupName { get; set; }

        public List<string> ProductIds { get; set; }
    }
}

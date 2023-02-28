using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace eazy_library.Models
{
    public class ImportModel
    {
        public ImportModel()
        {
        }
    }

    public class ImportModel_Product
    {
        public string Unit { get; set; }
        public int VAT { get; set; }
        public string EnterpriseID { get; set; }

        public string ProductCategoryID { get; set; }

        public List<string> ProductTypeIDs { get; set; }

        public List<string> Countries { get; set; }

        public IFormFile FileImport { get; set; }
    }

    public class ImportModel_Customer
    {
        public string CustomerCategoryID { get; set; }

        public string CustomerGroupID { get; set; }

        public bool IsVendor { get; set; }

        public bool IsCustomer { get; set; }

        public IFormFile FileImport { get; set; }
    }

    public class ImportModel_InvoiceProduct
    {
        public string InvoiceId { get; set; }

        public IFormFile FileImport { get; set; }
    }

    public class ImportModel_DataProduct
    {
        public string product_id { get; set; } = "";
        public string product_code { get; set; } = "";
        public string product_name { get; set; } = "";
        public string product_desc { get; set; } = "";
        public string product_unit { get; set; } = "";
        public string product_origin { get; set; } = "";
        public string product_countries { get; set; } = "";
        public string product_supplier { get; set; } = "";
        public string product_types { get; set; } = "";
        public string product_status { get; set; } = "";
        public string product_category { get; set; } = "";

        public double FOBUSD { get; set; }
        public double FOBVND { get; set; }
        public double FeeVND { get; set; }

        public double PriceAtStore { get; set; }

        public double SellPrice1 { get; set; }
        public double SellPrice2 { get; set; }
        public double SellPrice3 { get; set; }
        public double SellPrice4 { get; set; }
    }
}

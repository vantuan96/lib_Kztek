using System.Collections.Generic;
using System.Data;

namespace eazy_library.Cores.Models
{
    public class GridModel<T> where T : class
    {
        public List<T> Data { get; set; }

        public int TotalPage { get; set; }

        public int TotalIem { get; set; }

        public int PageIndex { get; set; }
        public int monthId { get; set; }
        public int PageSize { get; set; }

        public double TotalMoney { get; set; }

        public double TotalMoneyFree { get; set; }
    }
    public class GridModelCustom<T> where T : class
    {
        public List<T> Data { get; set; }

        public int TotalPage { get; set; }

        public int TotalIem { get; set; }

        public int PageIndex { get; set; }
      
        public int PageSize { get; set; }

      
    }
    public class GridModelDataTable
    {
        public DataTable Data { get; set; }

        public int TotalPage { get; set; }

        public int TotalIem { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public double TotalMoney { get; set; }

        public double TotalMoneyFree { get; set; }
    }
}
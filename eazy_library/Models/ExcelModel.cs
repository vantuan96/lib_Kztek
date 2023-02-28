using System;
using System.Collections.Generic;
using System.Data;

namespace eazy_library.Models
{
    public class ExcelModel
    {
        public DataTable Data { get; set; }

        public List<DisplayModel> Displays { get; set; }
    }
}

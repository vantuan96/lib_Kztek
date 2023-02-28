using eazy_library.Cores.Models;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Text;

namespace eazy_library.Helpers
{
  public  class GridModelHelpers<T> where T : class
    {
        public static GridModelCustom<T> GetPage(List<T> list, int currentPage, int itemPerPage, int TotalItemCount)
        {
            var PageCount = TotalItemCount > 0
                        ? (int)Math.Ceiling(TotalItemCount / (double)itemPerPage)
                        : 0;

            var PageModel = new GridModelCustom<T>
            {
                Data = list,
                PageIndex = currentPage,
                PageSize = itemPerPage,
                TotalPage = PageCount,
                TotalIem = TotalItemCount,
            };

            return PageModel;
        }

      
    }
}

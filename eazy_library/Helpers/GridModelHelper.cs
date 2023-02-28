using System;
using System.Collections.Generic;
using System.Data;
using eazy_library.Cores.Models;

namespace eazy_library.Helpers
{
    public class GridModelHelper<T> where T : class
    {
        public static GridModel<T> GetPage(List<T> list, int currentPage, int itemPerPage, int TotalItemCount)
        {
            var PageCount = TotalItemCount > 0
                        ? (int)Math.Ceiling(TotalItemCount / (double)itemPerPage)
                        : 0;

            var PageModel = new GridModel<T>
            {
                Data = list,
                PageIndex = currentPage,
                PageSize = itemPerPage,
                TotalPage = PageCount,
                TotalIem = TotalItemCount,
            };

            return PageModel;
        }


        public static GridModel<T> GetPage(List<T> list, int currentPage, int itemPerPage, int TotalItemCount, int PageCount)
        {

            var PageModel = new GridModel<T>
            {
                Data = list,
                PageIndex = currentPage,
                PageSize = itemPerPage,
                TotalPage = PageCount,
                TotalIem = TotalItemCount,
            };

            return PageModel;
        }

        public static GridModel<T> GetPage(List<T> list, int currentPage, int itemPerPage, int TotalItemCount,double TotalMoney)
        {
            var PageCount = TotalItemCount > 0
                        ? (int)Math.Ceiling(TotalItemCount / (double)itemPerPage)
                        : 0;

            var PageModel = new GridModel<T>
            {
                Data = list,
                PageIndex = currentPage,
                PageSize = itemPerPage,
                TotalPage = PageCount,
                TotalIem = TotalItemCount,
                TotalMoney = TotalMoney
            };

            return PageModel;
        }

        public static GridModel<T> GetPage(List<T> list, int currentPage, int itemPerPage, int TotalItemCount, double TotalMoney, double TotalMoneyFree)
        {
            var PageCount = TotalItemCount > 0
                        ? (int)Math.Ceiling(TotalItemCount / (double)itemPerPage)
                        : 0;

            var PageModel = new GridModel<T>
            {
                Data = list,
                PageIndex = currentPage,
                PageSize = itemPerPage,
                TotalPage = PageCount,
                TotalIem = TotalItemCount,
                TotalMoney = TotalMoney,
                TotalMoneyFree = TotalMoneyFree
            };

            return PageModel;
        }

        public static GridModelDataTable GetPage(DataTable data, int currentPage, int itemPerPage, int TotalItemCount)
        {
            var PageCount = TotalItemCount > 0
                        ? (int)Math.Ceiling(TotalItemCount / (double)itemPerPage)
                        : 0;

            var PageModel = new GridModelDataTable
            {
                Data = data,
                PageIndex = currentPage,
                PageSize = itemPerPage,
                TotalPage = PageCount,
                TotalIem = TotalItemCount,
            };

            return PageModel;
        }
    }
}
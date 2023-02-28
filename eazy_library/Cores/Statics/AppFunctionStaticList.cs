using System;
using System.Collections.Generic;
using eazy_library.Helpers;

namespace eazy_library.Cores.Statics
{
    public class AppFunctionStaticList
    {
        private static string admin = AppSettingHelper.GetStringFromAppSetting("Host:Admin").Result;
        private static string url = AppSettingHelper.GetStringFromAppSetting("Host:Main").Result;

        public static List<AppFunctionStatic> AppFunctionList()
        {
            var list = new List<AppFunctionStatic>
            {
                
                // Công việc, dự án (quản lý theo kiểu Trello)
                new AppFunctionStatic()
                {
                    Code = AppFunctionConfig.WORK,
                    Color = "light",
                    Icon = "fa fa-tasks",
                    Name = "Công việc",
                    Active = true,
                    Url = "/WORK/Dashboard/MyDashboard"
                },
                
                // Chấm công
                new AppFunctionStatic()
                {
                    Code = AppFunctionConfig.TIME,
                    Color = "light",
                    Icon = "fa fa-clock",
                    Name = "Chấm công",
                    Active = true,
                    Url = "/WORK/WORK_TimeAttendance"
                },
               
                // Sổ tay (tài liệu, sổ tay nhân sự, hướng dẫn kỹ thuật) -> Chế độ View
                new AppFunctionStatic()
                {
                    Code = AppFunctionConfig.HANDBOOK,
                    Color = "light",
                    Icon = "fa fa-book-reader",
                    Name = "Sổ tay",
                    Active = true,
                    Url = "/HANDBOOK"
                },

                // Quản lý sổ tay -> Chế độ quản lý thêm/sửa/xóa
                new AppFunctionStatic()
                {
                    Code = AppFunctionConfig.LIB,
                    Color = "light",
                    Icon = "fa fa-book-open",
                    Name = "QL sổ tay",
                    Active = true,
                    Url = "/LIB/LIB_Document"
                },

                // Nhân sự 
                new AppFunctionStatic()
                {
                    Code = AppFunctionConfig.HRM,
                    Color = "light",
                    Icon = "fa fa-users",
                    Name = "Nhân sự",
                    Active = true,
                    Url = "/HRM/EmployeeList"
                },

                // Bán hàng (quản lý hợp đồng, báo giá, báo cáo doanh thu)
                new AppFunctionStatic()
                {
                    Code = AppFunctionConfig.SALES,
                    Color = "light",
                    Icon = "fa fa-balance-scale-left",
                    Name = "Bán hàng",
                    Active = true,
                    Url = "/SALES"
                },

                // Mua hàng (quản lý hợp đồng, báo giá, đơn hàng)
                new AppFunctionStatic()
                {
                    Code = AppFunctionConfig.PURCHASE,
                    Color = "light",
                    Icon = "fa fa-shopping-cart",
                    Name = "Mua hàng",
                    Active = true,
                    Url = "/PURCHASE"
                },

                // Kế toán
                //new AppFunctionStatic()
                //{
                //    Code = AppFunctionConfig.ACCOUNTANT,
                //    Color = "light",
                //    Icon = "fa fa-money-check-alt",
                //    Name = "Kế toán",
                //    Active = true,
                //    Url = url + AppFunctionConfig.ACCOUNTANT
                //},

                // Dịch vụ bảo hành, bảo trì, chăm sóc khách hàng
                new AppFunctionStatic()
                {
                    Code = AppFunctionConfig.SERVICE,
                    Color = "light",
                    Icon = "fa fa-toolbox",
                    Name = "Kỹ thuật",
                    Active = true,
                    Url = "/SERVICE/"
                },

                // Sản phẩm
                new AppFunctionStatic()
                {
                    Code = AppFunctionConfig.PRODUCT,
                    Color = "light",
                    Icon = "fa fa-cubes",
                    Name = "Hàng hóa",
                    Active = true,
                    Url = "/PRODUCT/PriceList"
                },

                //// Thiết bị kiểm soát vào ra và chấm công
                //new AppFunctionStatic()
                //{
                //    Code = AppFunctionConfig.ACCESS,
                //    Color = "light",
                //    Icon = "fa fa-tools",
                //    Name = "Access Control",
                //    Active = true,
                //    Url = url + AppFunctionConfig.ACCESS
                //},

                // Ngân hàng
                new AppFunctionStatic()
                {
                    Code = AppFunctionConfig.BANK,
                    Color = "light",
                    Icon = "fa fa-university",
                    Name = "Ngân hàng",
                    Active = true,
                    Url = "/BANK"
                },


                // Quản lý khách hàng, nhà cung cấp
                new AppFunctionStatic()
                {
                    Code = AppFunctionConfig.CUSTOMER,
                    Color = "light",
                    Icon = "fa fa-address-card",
                    Name = "Đối tác",
                    Active = true,
                    Url = "/CUSTOMER/Customer/Index"
                },

                // Quản trị hệ thống
                new AppFunctionStatic()
                {
                    Code = AppFunctionConfig.ADMIN,
                    Color = "light",
                    Icon = "fa fa-user-cog",
                    Name = "Hệ thống",
                    Active = true,
                    Url = "/ADMIN/Account/Index"
                },
            };

            return list;
        }
    }
}

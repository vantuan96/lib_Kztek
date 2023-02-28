using System;
using System.Collections.Generic;
using eazy_library.Models;

namespace eazy_library.Helpers
{
    public class ColumnStaticList
    {
        /// <summary>
        /// Hiển thị table các cột theo controller
        /// </summary>
        /// <param name="controllername">Tên controller</param>
        /// <returns></returns>
        public static List<DisplayModel> Default_Display(string controllername)
        {

            switch (controllername)
            {
                //ADMIN
                case "Location":
                    return Location_Display();

                case "Role":
                    return Role_Display();

                case "Account":
                    return Account_Display();

                case "AccountGroup":
                    return AccountGroup_Display();

                case "Duty":
                    return Duty_Display();

                case "DashboardStage":
                    return DashboardStage_Display();

                case "Bank":
                    return Bank_Display();

                case "BankAccount":
                    return BankAccount_Display();

                //SALES
                case "SALES_Enterprise":

                    return SALES_Enterprise_Display();

                case "SALES_Contact":

                    return SALES_Contact_Display();

                case "SALES_Product":

                    return SALES_Product_Display();

                case "SALES_ProductType":

                    return SALES_ProductType_Display();

                case "SALES_ProductUnit":

                    return SALES_ProductUnit_Display();

                case "SALES_PriceList":

                    return SALES_PriceList_Display();

                case "SALES_PriceListPreview":

                    return SALES_Product_Display();

                case "SALES_Invoice":

                    return SALES_Invoice_Display();

                case "SALES_Project":

                    return SALES_Project_Display();

                case "SALES_Project_Status":

                    return SALES_Project_Status_Display();

                //WORK
                case "WORK_Project":

                    return WORK_Project_Display();

                case "WORK_Task":

                    return WORK_Task_Display();

                case "WORK_AccountGroup":

                    return WORK_AccountGroup_Display();

                //TIME
                case "TIME_AccountAccess":

                    return TIME_AccountAccess_Display();

                case "TIME_EmployeeDayOff":

                    return TIME_EmployeeDayOff_Display();

                case "TIME_EmployeeDayOff_Approve":

                    return TIME_EmployeeDayOff_Approve_Display();

                case "TIME_EmployeeOvertimeRegister":

                    return TIME_EmployeeOvertimeRegister_Display();

                case "TIME_EmployeeOvertimeReport":

                    return TIME_EmployeeOvertimeReport_Display();

                case "TIME_EmployeeOvertimeReport_Approve":

                    return TIME_EmployeeOvertimeReport_Approve_Display();

                case "TIME_TimeAttendance":

                    return TIME_TimeAttendance_Display();

                //HR
                case "HR_EmployeeConfig":
                    return HR_EmployeeConfig_Display();

                case "HR_EmployeeSalary":

                    return HR_EmployeeSalary_Display();

                case "HR_EmployeeSalaryReport":

                    return HR_EmployeeSalaryReport_Display();

                case "HR_EmployeeSalaryReport_Approve":

                    return HR_EmployeeSalaryReport_Approve_Display();

                //ACCESS
                case "ACCESS_PC":

                    return ACCESS_PC_Display();

                case "ACCESS_Line":

                    return ACCESS_Line_Display();

                case "ACCESS_HwController":

                    return ACCESS_HwController_Display();

                case "ACCESS_Door":

                    return ACCESS_Door_Display();

                case "ACCESS_Timezone":

                    return ACCESS_Timezone_Display();

                case "ACCESS_Level":

                    return ACCESS_Level_Display();

                //CONTRACT
                case "CONTRACT_ContractInfo":

                    return CONTRACT_ContractInfo_Display();

                case "CONTRACT_ContractStatus":

                    return CONTRACT_ContractStatus_Display();

                case "CONTRACT_ContractType":

                    return CONTRACT_ContractType_Display();

                //LIB
                case "LIB_Document":

                    return LIB_Document_Display();

                //SERVICE
                case "Maintenance":

                    return Maintenance_Display();

                case "Warranty":

                    return Warranty_Display();

                case "SERVICE_License":

                    return SERVICE_License_Display();

                case "SERVICE_KeySecurity":

                    return SERVICE_KeySecurity_Display();

                default:
                    return new List<DisplayModel>();
            }
        }

        public static List<DisplayModel> Location_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Địa chỉ", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
                                    };
            return list;
        }

        public static List<DisplayModel> Role_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên quyền", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
                                    };
            return list;
        }
        public static List<DisplayModel> Role_Display1()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "RoleID", DisplayName = "RoleID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "RoleCode", DisplayName = "Mã vai trò", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên quyền", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Bắt đầu", IsDefault = false, IsDisplay = false},
            new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày chỉnh sửa", IsDefault = false, IsDisplay = false },
                                    };
            return list;
        }
        public static List<DisplayModel> Account_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "FullName", DisplayName = "Họ tên", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "FirstName", DisplayName = "Họ tên đệm", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "LastName", DisplayName = "Tên", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Email", DisplayName = "Email", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Mobile", DisplayName = "Số điện thoại", IsDefault = false, IsDisplay = false},
                 new DisplayModel { FieldName = "isAdmin", DisplayName = "Quản trị hệ thống", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Roles", DisplayName = "Quyền hạn", IsDefault = false, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "AccountStatus", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true, IsSortable = true},
                                    };
            return list;
        }
        public static List<DisplayModel> Contact_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "ContactID", DisplayName = "ContactID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "FullName", DisplayName = "Họ tên", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Mobile", DisplayName = "Điện thoại", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Email", DisplayName = "Email", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Cơ quan", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "EmployeeFullName", DisplayName = "Người quản lý", IsDefault = false, IsDisplay = true},
            };

            return list;
        }
        public static List<DisplayModel> FileContract_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "ContractID", DisplayName = "ContractID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "ContractNo", DisplayName = "Số HĐ", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Khách hàng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "ContractSubject", DisplayName = "Nội dung", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TotalContractAmount", DisplayName = "Hợp đồng(VNĐ)", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TotalFinishAmount", DisplayName = "Thanh lý(VNĐ)", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TotalReceiptAmount", DisplayName = "Thực thu (VNĐ)", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TotalRemainAmount", DisplayName = "Còn lại (VNĐ)", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "ContractStatusName", DisplayName = "Tình trạng", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "EmployeeFullName1", DisplayName = "CBKD", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "FileStatus", DisplayName = "Trạng thái", IsDefault = false, IsDisplay = true},

            };

            return list;
        }
        public static List<DisplayModel> Technical_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "ContractID", DisplayName = "ContractID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "ContractNo", DisplayName = "Số HĐ", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Khách hàng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "ContractSubject", DisplayName = "Nội dung", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TechnicalFromDate", DisplayName = "Ngày thi công", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "ContractValidFromDate", DisplayName = "Ngày ký", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TotalDay", DisplayName = "Số ngày", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "EmployeeFullName1", DisplayName = "CBKD", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "IsTechnical", DisplayName = "Chuyển thi công", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "ContractStatusName", DisplayName = "Tình trạng thi công", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "TechnicalStatus", DisplayName = "Trạng thái", IsDefault = false, IsDisplay = true},

                };

            return list;
        }
        public static List<DisplayModel> Contract_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "ContractID", DisplayName = "ContractID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "ContractNo", DisplayName = "Số HĐ", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Khách hàng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "ContractSubject", DisplayName = "Nội dung", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "ContractValidFromDate", DisplayName = "Từ ngày", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "ContractValidToDate", DisplayName = "Đến ngày", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TotalDay", DisplayName = "Thời gian (tháng)", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "TotalContractAmount", DisplayName = "Hợp đồng (VNĐ)", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TotalFinishAmount", DisplayName = "Thanh lý(VNĐ)", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "TotalReceiptAmount", DisplayName = "Thực thu (VNĐ)", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TotalRemainAmount", DisplayName = "Còn lại (VND)", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "EmployeeFullName1", DisplayName = "CBKD", IsDefault = false, IsDisplay = true}
            };

            return list;
        }
        public static List<DisplayModel> Work_Task_Report_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Title", DisplayName = "Tên nhiệm vụ", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Miêu tả", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "DateStart", DisplayName = "Ngày bắt đầu", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "DateEnd", DisplayName = "Kết thúc", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "IsCompleted", DisplayName = "Trạng thái", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "CreatedBy", DisplayName = "Người tạo", IsDefault = false, IsDisplay = true},

            };

            return list;
        }
        public static List<DisplayModel> BankCredit_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "BankCreditID", DisplayName = "BankCreditID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Account", DisplayName = "Tài khoản", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Khách hàng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Nội dung", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "BankCreditTypeID", DisplayName = "Loại tín dụng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Money1", DisplayName = "Vay/Bảo lãnh", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Money2", DisplayName = "Ký quỹ", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TotalAmountPayment", DisplayName = "Đã thanh toán", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "InterestRate", DisplayName = "Lãi suất", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "InterestMoney", DisplayName = "Tiền lãi", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Tenor", DisplayName = "Thời gian", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "ToDate", DisplayName = "Ngày hết hạn", IsDefault = false, IsDisplay = true},

            };

            return list;
        }


        public static List<DisplayModel> Invoice_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "InvoiceID", DisplayName = "InvoiceID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "InvoiceNo", DisplayName = "Số báo giá", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Khách hàng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "ProjectName", DisplayName = "Tên dự án", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Miêu tả", IsDefault = false, IsDisplay = false},
                //new DisplayModel { FieldName = "ProductCategoryName", DisplayName = "Loại hàng hóa", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TotalInvoiceAmount", DisplayName = "Giá trị (VNĐ)", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "InvoiceStatusName", DisplayName = "Tình trạng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "CustomerSignedDate", DisplayName = "Thời gian", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "FullName", DisplayName = "NV mua hàng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "InvoiceResult", DisplayName = "Kết quả", IsDefault = false, IsDisplay = true},
            };

            return list;
        }
        public static List<DisplayModel> Purchase_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "PUContractID", DisplayName = "PUContractID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "PUContractNo2", DisplayName = "Số HĐ", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "PUContractSubject", DisplayName = "Nội dung", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Nhà cung cấp", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "ContractSubject", DisplayName = "Hợp đồng đầu ra", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Description", DisplayName = "Miêu tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Amount", DisplayName = "Giá trị HĐ", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "CloseAmount", DisplayName = "Thanh lý", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "PaidAmount", DisplayName = "Đã thanh toán", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "RemainAmount", DisplayName = "Còn lại", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Status", DisplayName = "Tình trạng", IsDefault = false, IsDisplay = true},

            };

            return list;
        }


        public static List<DisplayModel> Contract_Display1()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "ContractID", DisplayName = "ContractID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "ContractNo", DisplayName = "Số HĐ", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Khách hàng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "ContractSubject", DisplayName = "Nội dung", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TotalContractAmount", DisplayName = "Hợp đồng(VND)", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TotalFinishAmount", DisplayName = "Thanh lý(VND)", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TotalReceiptAmount", DisplayName = "Thực thu (VND)", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TotalRemainAmount", DisplayName = "Còn lại (VND)", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "IsMaintenanceContract", DisplayName = "Trạng thái bảo trì", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "IsWarranty", DisplayName = "Trạng thái bảo hành", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "EmployeeFullName1", DisplayName = "CBKD", IsDefault = false, IsDisplay = true},
            };

            return list;
        }

        public static List<DisplayModel> InvoiceStatus_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "InvoiceStatusID", DisplayName = "InvoiceStatusID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "InvoiceStatusName", DisplayName = "Tình trạng thực hiện", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "SortOrder", DisplayName = "Stt", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = true},

            };

            return list;
        }

        public static List<DisplayModel> InvoiceType_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "InvoiceTypeID", DisplayName = "InvoiceTypeID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "InvoiceTypeName", DisplayName = "Phân loại báo giá", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "SortOrder", DisplayName = "Stt", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = true},

            };

            return list;
        }

        public static List<DisplayModel> KPI_Sales_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "KPI_SalesID", DisplayName = "KPI_SalesID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Year", DisplayName = "Năm", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "FullName", DisplayName = "Kinh doanh", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Target", DisplayName = "Mục tiêu (VNĐ)", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Miêu tả", IsDefault = false, IsDisplay = true},
            };

            return list;
        }

        public static List<DisplayModel> ContractStatus_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "ContractStatusID", DisplayName = "ContractStatusID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "SortOrder", DisplayName = "Thự tự", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "ContractStatusName", DisplayName = "Tình trạng thực hiện", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Diễn giải", IsDefault = false, IsDisplay = true},
            };

            return list;
        }
        public static List<DisplayModel> Contractcategory_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "ContractCategoryID", DisplayName = "ContractCategoryID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "SortOrder", DisplayName = "Thự tự", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "ContractCategoryName", DisplayName = "Loại hợp đồng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Diễn giải", IsDefault = false, IsDisplay = true},
            };

            return list;
        }
        public static List<DisplayModel> ProductCategory_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "ProductCategoryID", DisplayName = "ProductCategoryID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "SortOrder", DisplayName = "Thự tự", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "ProductCategoryName", DisplayName = "Loại hàng hóa", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Diễn giải", IsDefault = false, IsDisplay = true},
            };

            return list;
        }
        public static List<DisplayModel> JobCostType_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "JobCostTypeID", DisplayName = "JobCostTypeID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "SortOrder", DisplayName = "Thự tự", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "JobCostTypeName", DisplayName = "Loại khoản chi", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Diễn giải", IsDefault = false, IsDisplay = true},
            };

            return list;
        }
        public static List<DisplayModel> Receipt_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "ReceiptID", DisplayName = "ReceiptID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "ReceiptDate", DisplayName = "Ngày thu", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Amount", DisplayName = "Số tiền", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Diễn giải", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Khách hàng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "ContractSubject", DisplayName = "Hợp đồng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Title", DisplayName = "Tên phụ lục", IsDefault = false, IsDisplay = true},
            };

            return list;
        }
        public static List<DisplayModel> Warranty_Display1()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "ContractID", DisplayName = "ContractID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "ContractNo", DisplayName = "Số HĐ", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Khách hàng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "ContractSubject", DisplayName = "Nội dung", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "WarrantyFromDate", DisplayName = "Từ ngày", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "WarrantyToDate", DisplayName = "Đến ngày", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "WarrantyMonth", DisplayName = "Thời gian (tháng)", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "EmployeeFullName1", DisplayName = "CBKD", IsDefault = false, IsDisplay = true}
            };

            return list;
        }
        public static List<DisplayModel> Customer_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "EnterpriseID", DisplayName = "EnterpriseID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "EnterpriseAlias", DisplayName = "Mã", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Tên đối tác", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Tel", DisplayName = "Điện thoại", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Email", DisplayName = "Email", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Address", DisplayName = "Địa chỉ", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "OwnerID", DisplayName = "Người quản lý", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "CreatedBy", DisplayName = "Người tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "CreatedDate", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "ModifiedBy", DisplayName = "Người quản lý", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "ModifiedDate", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Inactive", DisplayName = "Trạng thái", IsDefault = false, IsDisplay = false},
            };

            return list;
        }
        public static List<DisplayModel> CustomerCategory_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "EnterpriseCategoryID", DisplayName = "EnterpriseCategoryID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "EnterpriseCategoryName", DisplayName = "Phân loại đối tác", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "IsVendor", DisplayName = "Đối tác", IsDefault = false, IsDisplay = false},
            };

            return list;
        }
        public static List<DisplayModel> CustomerGroup_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "EnterpriseGroupID", DisplayName = "EnterpriseGroupID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "EnterpriseGroupName", DisplayName = "Nhóm đối tác", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = true},
            };

            return list;
        }
        public static List<DisplayModel> OverTimeReport()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "OverTimeID", DisplayName = "OverTimeID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "EmployeeID", DisplayName = "EmployeeID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Datetime", DisplayName = "Datetime", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "YYYYMMDD", DisplayName = "YYYYMMDD", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "TimeOT", DisplayName = "Bắt đầu", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TimeDone", DisplayName = "Kết thúc", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "DiffOT", DisplayName = "DiffOT", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "EnterpriseID", DisplayName = "EnterpriseID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "ContractID", DisplayName = "ContractID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "RemarkOT", DisplayName = "Ghi chú", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "RemarkDone", DisplayName = "Ghi chú 1", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "LocationOT", DisplayName = "Vị trí", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "LocationDone", DisplayName = "vị trí hoàn thành", IsDefault = false, IsDisplay = false},
            };

            return list;
        }
        public static List<DisplayModel> ContactCategory_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "ContactCategoryID", DisplayName = "ContactCategoryID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "ContactCategoryName", DisplayName = "Loại liên hệ", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = true},
            };

            return list;
        }

        public static List<DisplayModel> Bonus_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "BonusID", DisplayName = "BonusID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "BonusName", DisplayName = "Nội dung", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TotalBonus", DisplayName = "Tổng tiền thưởng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Datetime", DisplayName = "Thời gian", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "UserName", DisplayName = "Người tạo", IsDefault = false, IsDisplay = true},

            };

            return list;
        }
        public static List<DisplayModel> Holiday_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "HolidayID", DisplayName = "HolidayID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "HolidayCode", DisplayName = "Ngày lễ", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "HolidayName", DisplayName = "Mô tả", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "FromDate", DisplayName = "Từ ngày", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "ToDate", DisplayName = "Đến ngày", IsDefault = false, IsDisplay = true},

            };

            return list;
        }
        public static List<DisplayModel> RegisterHoliday_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "RegisterHolidayID", DisplayName = "RegisterHolidayID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Datetime", DisplayName = "Ngày", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "FullName", DisplayName = "Họ tên", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Remark", DisplayName = "Ghi chú", IsDefault = true, IsDisplay = true},


            };

            return list;
        }

        public static List<DisplayModel> Paysheet_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "PaySheetID", DisplayName = "PaySheetID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "PaySheetMonth", DisplayName = "Tháng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "PaySheetYear", DisplayName = "Năm", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "StandardWorkingDays", DisplayName = "Ngày công chuẩn", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "TotalNetPay", DisplayName = "Tổng lương", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TotalAdvance", DisplayName = "Tạm ứng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TotalDebt", DisplayName = "CĐ,BH,Nợ Phạt", IsDefault = false, IsDisplay = true},

                new DisplayModel { FieldName = "TotalPay", DisplayName = "Còn lại", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "PaySheetName", DisplayName = "Nội dung", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Datetime", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "UserName", DisplayName = "Người tạo tạo", IsDefault = false, IsDisplay = true},



            };

            return list;
        }
        public static List<DisplayModel> JobDescript_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "JobDescriptionID", DisplayName = "JobDescriptionID", IsDefault = false, IsDisplay = false},
                  new DisplayModel { FieldName = "SortOrder", DisplayName = "Thứ tự", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "JobName", DisplayName = "Công việc", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "OrganizationUnitName", DisplayName = "Trực thuộc", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả công việc", IsDefault = false, IsDisplay = true},



            };

            return list;
        }
        public static List<DisplayModel> EmployeeList_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "EmployeeId", DisplayName = "EmployeeId", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "FullName", DisplayName = "Họ tên", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Mobile", DisplayName = "Điện thoại", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TelExt", DisplayName = "Số lẻ", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Email", DisplayName = "Email", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "OrganizationUnitName", DisplayName = "Phòng ban", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "JobPositionName", DisplayName = "Vị trí", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "BasicPay", DisplayName = "Lương cơ bản", IsDefault = false, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "Allowance1", DisplayName = "Phụ cấp", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Allowance2", DisplayName = "Phụ cấp trách nhiệm", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Insurance", DisplayName = "Bảo hiểm", IsDefault = true, IsDisplay = true},
            };

            return list;
        }
        public static List<DisplayModel> JobPositon_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "JobDescriptionID", DisplayName = "JobDescriptionID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "JobName", DisplayName = "Vị trí công việc", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "OrganizationUnitName", DisplayName = "Trực thuộc phòng ban", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = true},

            };

            return list;
        }

        public static List<DisplayModel> JobPosition_Display1()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "JobPositionID", DisplayName = "JobPositionID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "JobPositionName", DisplayName = "Tên vị trí công việc", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "OrganizationUnitName", DisplayName = "Tổ chức", IsDefault = false, IsDisplay = true},

            };

            return list;
        }
        public static List<DisplayModel> Account_Display1()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "EmployeeId", DisplayName = "EmployeeId", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "FullName", DisplayName = "Họ tên", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "FirstName", DisplayName = "Họ tên đệm", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "LastName", DisplayName = "Tên", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Email", DisplayName = "Email", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Mobile", DisplayName = "Số điện thoại", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "isAdmin", DisplayName = "Quản trị hệ thống", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Roles", DisplayName = "Quyền hạn", IsDefault = false, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "AccountStatus", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
            };

            return list;
        }
        public static List<DisplayModel> Duty_Display1()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "TitleID", DisplayName = "TitleID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "TitleCode", DisplayName = "Mã chức vụ", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "TitleName", DisplayName = "Tên chức vụ", IsDefault = false, IsDisplay = true},
            };

            return list;
        }
        public static List<DisplayModel> AccountGroup_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên nhóm", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
            };

            return list;
        }

        public static List<DisplayModel> Duty_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên chức vụ", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "SortOrder", DisplayName = "STT", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
            };

            return list;
        }

        public static List<DisplayModel> DashboardStage_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên giai đoạn", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "AppCode", DisplayName = "Dành cho app", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "ControllerName", DisplayName = "Chức năng", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "SortOrder", DisplayName = "STT", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
            };

            return list;
        }

        public static List<DisplayModel> Bank_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "BankCode", DisplayName = "Mã ngân hàng", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "BankName", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
            };

            return list;
        }
        public static List<DisplayModel> Payment_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "PaymentID", DisplayName = "PaymentID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "PaymentDate", DisplayName = "Ngày thanh toán", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Amount", DisplayName = "Số tiền", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = true},                
                new DisplayModel { FieldName = "PUContractNo2", DisplayName = "Số hợp đồng", IsDefault = false, IsDisplay = true},
               
            };

            return list;
        }
        public static List<DisplayModel> BankCreditPayment_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "BankCreditPaymentID", DisplayName = "BankCreditPaymentID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "BankCreditPaymentDate", DisplayName = "Ngày thanh toán", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Amount", DisplayName = "Số tiền", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Account", DisplayName = "Tài khoản", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Khách hàng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "BankCreditDescription", DisplayName = "Diễn giải", IsDefault = false, IsDisplay = true},

            };

            return list;
        }
        public static List<DisplayModel> InsertPay_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "InterestPaymentID", DisplayName = "InterestPaymentID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "InterestPaymentDate", DisplayName = "Ngày thanh toán", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Amount", DisplayName = "Số tiền", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Account", DisplayName = "Tài khoản", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Khách hàng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "BankCreditDescription", DisplayName = "Diễn giải", IsDefault = false, IsDisplay = true},

            };

            return list;
        }
        public static List<DisplayModel> Price_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "ProductID", DisplayName = "ProductID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "ProductCode", DisplayName = "Mã", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "ProductName", DisplayName = "Tên", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "UnitPriceSales", DisplayName = "Giá bán đại lý", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "UnitPriceSales1", DisplayName = "Giá bán dự án", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Hãng sản xuất", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "OriginCountry", DisplayName = "Xuất xứ", IsDefault = false, IsDisplay = true},

            };

            return list;
        }
        public static List<DisplayModel> Product_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "ProductID", DisplayName = "ProductID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "ProductCode", DisplayName = "Mã", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "ProductName", DisplayName = "Tên", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Unit", DisplayName = "Đơn vị", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "UnitPrice", DisplayName = "Giá nhập", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "UnitPriceSales", DisplayName = "Giá đại lý", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "UnitPriceSales1", DisplayName = "Giá dự án", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Hãng sản xuất", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "OriginCountry", DisplayName = "Xuất xứ", IsDefault = false, IsDisplay = true},

            };

            return list;
        }
        public static List<DisplayModel> tblBank_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "BankID", DisplayName = "BankID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "BankCode", DisplayName = "Mã ngân hàng", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "BankName", DisplayName = "Tên ngân hàng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "BankNameEngLish", DisplayName = "Tên tiếng anh", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Address", DisplayName = "Địa chỉ", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "IsHasServiceOnline", DisplayName = "Dich vụ online", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Address", DisplayName = "Địa chỉ", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Icon", DisplayName = "Icon", IsDefault = true, IsDisplay = false},
                new DisplayModel { FieldName = "Inactive", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
            };

            return list;
        }
        public static List<DisplayModel> BankAccount_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Bank", DisplayName = "Ngân hàng", IsDefault = true, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "BankNumber", DisplayName = "Số tài khoản", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "BankAddress", DisplayName = "Chi nhánh", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
            };

            return list;
        }
        public static List<DisplayModel> CreditCard_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "CreditCardID", DisplayName = "CreditCardID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "CreditCardNo", DisplayName = "Số thẻ", IsDefault = true, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "CreditCardType", DisplayName = "Loại thẻ", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "OwnerCard", DisplayName = "Chủ thẻ", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "BankName", DisplayName = "Tên ngân hàng", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "BankCode", DisplayName = "Mã ngân hàng", IsDefault = false, IsDisplay = true},
            };

            return list;


        }
        public static List<DisplayModel> BankAccount_Display1()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "BankAccountID", DisplayName = "BankAccountID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Bank", DisplayName = "Ngân hàng", IsDefault = true, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "BankAccount", DisplayName = "Số tài khoản", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Address", DisplayName = "Chi nhánh", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "UserLogOn", DisplayName = "Người đăng nhập", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Password", DisplayName = "Mật khẩu", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "IsUsePasswordAtOne", DisplayName = "Chỉ sử dụng một mật khẩu", IsDefault = true, IsDisplay = false},
                new DisplayModel { FieldName = "Inactive", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
                 new DisplayModel { FieldName = "CreditLimitAll", DisplayName = "Giới hạn tín dụng", IsDefault = true, IsDisplay = true},
                  new DisplayModel { FieldName = "CreditLimitPayment", DisplayName = "Giới hạn thanh toán", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = true, IsDisplay = false },
                new DisplayModel { FieldName = "BankBranchName", DisplayName = "Tên ngân hàng chi nhánh", IsDefault = true, IsDisplay = false },
            };

            return list;


        }
        public static List<DisplayModel> SALES_Enterprise_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên tổ chức", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "TaxCode", DisplayName = "MST", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Address", DisplayName = "Địa chỉ", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
            };

            return list;
        }

        public static List<DisplayModel> SALES_Contact_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên người liên hệ", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Mobile", DisplayName = "Số điện thoại", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Email", DisplayName = "Email", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Enterprise", DisplayName = "Thuộc tổ chức", IsDefault = false, IsDisplay = false, IsSortable = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
            };

            return list;
        }

        public static List<DisplayModel> SALES_Product_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Code", DisplayName = "Mã sản phẩm", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên sản phẩm", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Note", DisplayName = "Ghi chú", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
            };

            return list;
        }

        public static List<DisplayModel> SALES_ProductType_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên loại", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
            };

            return list;
        }

        public static List<DisplayModel> SALES_ProductUnit_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên đơn vị", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
            };

            return list;
        }

        public static List<DisplayModel> SALES_PriceList_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên bảng giá", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
            };

            return list;
        }

        public static List<DisplayModel> SALES_Invoice_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Title", DisplayName = "Tiêu đề", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "ContactName", DisplayName = "Khách hàng", IsDefault = true, IsDisplay = true, IsSortable = false },
                new DisplayModel { FieldName = "Total", DisplayName = "Giá", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false },
                new DisplayModel { FieldName = "InvoiceStatus", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
            };

            return list;
        }

        public static List<DisplayModel> SALES_Project_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Title", DisplayName = "Tên dự án", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Khách hàng", IsDefault = true, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "SALES_EstimateValue", DisplayName = "Giá dự kiến", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "ProjectStatusName", DisplayName = "Trạng thái công việc", IsDefault = true, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> SALES_Project_Status_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên trạng thái", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> WORK_Project_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Title", DisplayName = "Tên dự án", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateStart", DisplayName = "Bắt đầu", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateEnd", DisplayName = "Kết thúc", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "EstimateBudget", DisplayName = "Ngân sách dự kiến", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "IsStore", DisplayName = "Đã lưu trữ", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "EmployeeFullName", DisplayName = "Người tạo", IsDefault = true, IsDisplay = true},

            };

            return list;
        }

        public static List<DisplayModel> WORK_Task_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Title", DisplayName = "Tên nhiệm vụ", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateStart", DisplayName = "Bắt đầu", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateEnd", DisplayName = "Kết thúc", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "IsCompleted", DisplayName = "Hoàn thành", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "CreatedBy", DisplayName = "Người tạo", IsDefault = false, IsDisplay = true},

            };

            return list;
        }

        public static List<DisplayModel> WORK_AccountGroup_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên nhóm", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> TIME_AccountAccess_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "LastName", DisplayName = "Họ", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "FirstName", DisplayName = "Tên", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "UserId", DisplayName = "Mã id", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> TIME_EmployeeDayOff_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Note", DisplayName = "Lý do", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "FromDate", DisplayName = "Từ thời điểm", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "ToDate", DisplayName = "Tới thời điểm", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DayOffStatus", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> TIME_EmployeeDayOff_Approve_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "AccountName", DisplayName = "Tài khoản", IsDefault = true, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "Note", DisplayName = "Lý do", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "FromDate", DisplayName = "Từ thời điểm", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "ToDate", DisplayName = "Tới thời điểm", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DayOffStatus", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> TIME_EmployeeOvertimeRegister_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Note", DisplayName = "Lý do", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCheckIn", DisplayName = "Từ thời điểm", IsDefault = true, IsDisplay = true, IsUTC = true},
                new DisplayModel { FieldName = "DateCheckOut", DisplayName = "Tới thời điểm", IsDefault = true, IsDisplay = true, IsUTC = true},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> TIME_EmployeeOvertimeReport_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Title", DisplayName = "Tiêu đề", IsDefault = true, IsDisplay = true},
                 new DisplayModel { FieldName = "Total", DisplayName = "Tổng giờ", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "OTReportStatus", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> TIME_EmployeeOvertimeReport_Approve_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "AccountName", DisplayName = "TK", IsDefault = true, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "Title", DisplayName = "Tiêu đề", IsDefault = true, IsDisplay = true},
                 new DisplayModel { FieldName = "Total", DisplayName = "Tổng giờ", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "OTReportStatus", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> TIME_TimeAttendance_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateCheckIn", DisplayName = "Giờ chấm công", IsDefault = true, IsDisplay = true, IsSortable = false, IsUTC = true},
                new DisplayModel { FieldName = "AccountName", DisplayName = "Nhân viên", IsDefault = true, IsDisplay = true},
            };

            return list;
        }

        public static List<DisplayModel> HR_EmployeeConfig_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "LastName", DisplayName = "Họ", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "FirstName", DisplayName = "Tên", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Email", DisplayName = "Email", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DayStartWork", DisplayName = "Ngày vào làm", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> HR_EmployeeSalary_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Year", DisplayName = "Năm", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Month", DisplayName = "Tháng", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Total", DisplayName = "Tổng", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> HR_EmployeeSalaryReport_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Title", DisplayName = "Tiêu đề", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Year", DisplayName = "Năm", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Month", DisplayName = "Tháng", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Total", DisplayName = "Tổng", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "IsApproved", DisplayName = "Duyệt", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> HR_EmployeeSalaryReport_Approve_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "AccountName", DisplayName = "Người tạo", IsDefault = true, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "Title", DisplayName = "Tiêu đề", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Year", DisplayName = "Năm", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Month", DisplayName = "Tháng", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Total", DisplayName = "Tổng", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "IsApproved", DisplayName = "Duyệt", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> ACCESS_PC_Display()
        {
            var list = new List<DisplayModel>
            {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên máy tính", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "IPAddress", DisplayName = "Địa chỉ", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }



        public static List<DisplayModel> ACCESS_Line_Display()
        {
            var list = new List<DisplayModel>
            {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên máy tính", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "PCName", DisplayName = "Máy tính", IsDefault = true, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> ACCESS_HwController_Display()
        {
            var list = new List<DisplayModel>
            {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Bộ điều khiển", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "LineName", DisplayName = "Line", IsDefault = true, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> ACCESS_Door_Display()
        {
            var list = new List<DisplayModel>
            {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên cửa", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "ReaderIndex", DisplayName = "Địa chỉ", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> ACCESS_Timezone_Display()
        {
            var list = new List<DisplayModel>
            {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên khung giờ", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "TimezoneId", DisplayName = "Mã Id(int)", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> ACCESS_Level_Display()
        {
            var list = new List<DisplayModel>
            {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên quyền", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> CONTRACT_ContractStatus_Display()
        {
            var list = new List<DisplayModel>
            {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên trạng thái", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> CONTRACT_ContractType_Display()
        {
            var list = new List<DisplayModel>
            {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên loại", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> CONTRACT_ContractInfo_Display()
        {
            var list = new List<DisplayModel>
            {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Code", DisplayName = "Số HĐ", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Khách hàng", IsDefault = true, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "Title", DisplayName = "Nội dung", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "TotalContractAmount", DisplayName = "Giá trị HD (VND)", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "TotalFinishAmount", DisplayName = "Giá trị TL (VND)", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "TotalReceiptAmount", DisplayName = "Thực thu (VND)", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "TotalRemainAmount", DisplayName = "Còn lại (VND)", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "AccountSaleName", DisplayName = "CBKD", IsDefault = true, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "ContractStatusName", DisplayName = "Trạng thái", IsDefault = false, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> LIB_Document_Display()
        {
            var list = new List<DisplayModel>
            {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Title", DisplayName = "Tiêu đề", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "CategoryName", DisplayName = "Nhóm tài liệu", IsDefault = true, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "Active", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "CreatedBy", DisplayName = "Người tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "UpdatedBy", DisplayName = "Người cập nhật", IsDefault = true, IsDisplay = true},
            };

            return list;
        }

        public static List<DisplayModel> Maintenance_Display()
        {
            var list = new List<DisplayModel>
            {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Code", DisplayName = "Số HĐ", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Khách hàng", IsDefault = true, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "Title", DisplayName = "Nội dung", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "ContractStatusName", DisplayName = "Tình trạng HD", IsDefault = true, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> Warranty_Display()
        {
            var list = new List<DisplayModel>
            {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Code", DisplayName = "Số HĐ", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "EnterpriseName", DisplayName = "Khách hàng", IsDefault = true, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "Title", DisplayName = "Nội dung", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "WarrantyEndDate", DisplayName = "Hạn BH", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "ContractStatusName", DisplayName = "Tình trạng HD", IsDefault = true, IsDisplay = true, IsSortable = false},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> SERVICE_License_Display()
        {
            var list = new List<DisplayModel>
            {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên dự án", IsDefault = true, IsDisplay = true},
                 new DisplayModel { FieldName = "ProjectName", DisplayName = "Tên biểu phí", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "ExpireDate", DisplayName = "Ngày hết hạn", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "IsExpire", DisplayName = "Trạng thái", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = true, IsDisplay = true},
               
            };

            return list;
        }

        public static List<DisplayModel> SERVICE_KeySecurity_Display()
        {
            var list = new List<DisplayModel>
            {
                new DisplayModel { FieldName = "Id", DisplayName = "Id", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Code", DisplayName = "Mã", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Name", DisplayName = "Tên dự án", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = true, IsDisplay = true},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Ngày cập nhật", IsDefault = false, IsDisplay = false},
            };

            return list;
        }

        public static List<DisplayModel> RequestType_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "RequestTypeID", DisplayName = "RequestTypeID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "SchemeCode", DisplayName = "Mã quy trình", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Template", DisplayName = "Mẫu biểu (form)", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Condition", DisplayName = "Condition", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "RequestTypeName", DisplayName = "Tên quy trình", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Mô tả quy trình", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "CreatedBy", DisplayName = "Tạo bởi", IsDefault = false, IsDisplay = true},

            };

            return list;
        }

        public static List<DisplayModel> Request_Display()
        {
            var list = new List<DisplayModel> {
                new DisplayModel { FieldName = "RequestID", DisplayName = "RequestTypeID", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "RequestTypeName", DisplayName = "Đề xuất", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Title", DisplayName = "Tiêu đề", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Description", DisplayName = "Miêu tả", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "Number", DisplayName = "Số", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "AuthorName", DisplayName = "Người tạo", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "ManagerName", DisplayName = "Người quản lý", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "StateName", DisplayName = "Trạng thái", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "Sum", DisplayName = "Giá trị", IsDefault = false, IsDisplay = true},
                new DisplayModel { FieldName = "DateCreated", DisplayName = "Ngày tạo", IsDefault = false, IsDisplay = false},
                new DisplayModel { FieldName = "DateUpdated", DisplayName = "Cập nhật", IsDefault = false, IsDisplay = true},

            };

            return list;
        }




    }
}

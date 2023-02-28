using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eazy_library.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
using OfficeOpenXml.Core.ExcelPackage;
using OfficeOpenXml.Style;

namespace eazy_library.Helpers
{
    public class ExcelHelper
    {
        public static void Excel_V1(string filename, List<DisplayModel> displays, DataTable data, HttpContext context)
        {
            var arrDisplay = displays.Where(n => n.IsDisplay).ToList();
            var count = 0;
            var countDisplay = arrDisplay.Count;
            var countData = data.Rows.Count;

            try
            {
                byte[] dataContent = null;
                var stream = new MemoryStream();

                using (var package = new OfficeOpenXml.ExcelPackage(stream))
                {
                    var workSheet = package.Workbook.Worksheets.Add("Sheet1");

                    //Column header
                    foreach (var item in arrDisplay)
                    {
                        count++;

                        workSheet.Cells[1, count].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        workSheet.Cells[1, count].Style.Font.Name = "Times New Roman";
                        workSheet.Cells[1, count].Style.Font.Size = 14;
                        workSheet.Cells[1, count].Value = item.DisplayName;
                        workSheet.Cells[1, count].Style.Font.Bold = true;
                        workSheet.Cells[1, count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        //workSheet.Cells[1, count].AutoFitColumns();
                    }

                    workSheet.Cells.AutoFitColumns();

                    //Data
                    workSheet.Cells[2, 1, countData, countDisplay].Style.Font.Name = "Times New Roman";
                    workSheet.Cells[2, 1, countData, countDisplay].Style.Font.Size = 12;

                    workSheet.Cells[2, 1].LoadFromDataTable(data, false);

                    dataContent = package.GetAsByteArray();
                }

                Excel_Execute(context, dataContent, filename);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static void Excel_V2(string filename, List<DisplayModel> displays, DataTable data, HttpContext context)
        {
            var arrDisplay = displays.Where(n => n.IsDisplay).ToList();
            var count = 1;
            var countDisplay = arrDisplay.Count;
            var countData = data.Rows.Count;

            try
            {
                using (var ms = new MemoryStream())
                {
                    IWorkbook workbook;
                    workbook = new XSSFWorkbook();
                    ISheet excelSheet = workbook.CreateSheet("Sheet1");

                    IRow row = excelSheet.CreateRow(0);

                    //Header
                    for (int i = 0; i < arrDisplay.Count; i++)
                    {
                        row.CreateCell(i).SetCellValue(arrDisplay[i].DisplayName);
                    }

                    //Body
                    foreach (DataRow item in data.Rows)
                    {
                        row = excelSheet.CreateRow(count);

                        for (int i = 0; i < arrDisplay.Count; i++)
                        {
                            row.CreateCell(i).SetCellValue(item[arrDisplay[i].FieldName].ToString());
                        }

                        count++;
                    }

                    workbook.Write(ms);

                    Excel_Execute(context, ms.ToArray(), filename);
                }







            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static void Excel_Account_V1(string filename, DataTable data, HttpContext context)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    IWorkbook workbook;
                    workbook = new XSSFWorkbook();
                    ISheet excelSheet = workbook.CreateSheet("Danh sách tài khoản");

                    //Header

                    /* #region  row 1 */
                    IRow row1 = excelSheet.CreateRow(0);

                    var cra0 = new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 3);
                    excelSheet.AddMergedRegion(cra0);
                    row1.CreateCell(0, CellType.String).SetCellValue("Tài khoản");

                    var cra1 = new NPOI.SS.Util.CellRangeAddress(0, 0, 4, 5);
                    excelSheet.AddMergedRegion(cra1);
                    row1.CreateCell(4, CellType.String).SetCellValue("Cấu hình chấm công");

                    var cra2 = new NPOI.SS.Util.CellRangeAddress(0, 0, 6, 12);
                    excelSheet.AddMergedRegion(cra2);
                    row1.CreateCell(6, CellType.String).SetCellValue("Cấu hình lương");
                    /* #endregion */

                    /* #region  row 2 */
                    IRow row2 = excelSheet.CreateRow(1);

                    row2.CreateCell(0, CellType.String).SetCellValue("Mã tài khoản");
                    row2.CreateCell(1, CellType.String).SetCellValue("Họ");
                    row2.CreateCell(2, CellType.String).SetCellValue("Tên");
                    row2.CreateCell(3, CellType.String).SetCellValue("Email");

                    row2.CreateCell(4, CellType.String).SetCellValue("Mã nhân viên");
                    row2.CreateCell(5, CellType.String).SetCellValue("Mã thẻ");

                    row2.CreateCell(6, CellType.String).SetCellValue("Lương hiện tại");
                    row2.CreateCell(7, CellType.String).SetCellValue("Phụ cấp");
                    row2.CreateCell(8, CellType.String).SetCellValue("Phụ cáp trách nhiệm");
                    row2.CreateCell(9, CellType.String).SetCellValue("Mức lương đóng bảo hiểm");
                    row2.CreateCell(10, CellType.String).SetCellValue("Tạm ứng");
                    row2.CreateCell(11, CellType.String).SetCellValue("Số ngày phép / năm");
                    row2.CreateCell(12, CellType.String).SetCellValue("Ngày bắt đầu làm");
                    /* #endregion */

                    /* #region  columns width */
                    excelSheet.SetColumnWidth(0, 10000);
                    excelSheet.SetColumnWidth(1, 5000);
                    excelSheet.SetColumnWidth(2, 5000);
                    excelSheet.SetColumnWidth(3, 10000);
                    excelSheet.SetColumnWidth(4, 5000);
                    excelSheet.SetColumnWidth(5, 5000);
                    excelSheet.SetColumnWidth(6, 5000);
                    excelSheet.SetColumnWidth(7, 5000);
                    excelSheet.SetColumnWidth(8, 5000);
                    excelSheet.SetColumnWidth(9, 5000);
                    excelSheet.SetColumnWidth(10, 5000);
                    excelSheet.SetColumnWidth(11, 5000);
                    excelSheet.SetColumnWidth(12, 5000);
                    /* #endregion */

                    //Body
                    var row = 2;

                    foreach (DataRow item in data.Rows)
                    {
                        var rowData = excelSheet.CreateRow(row);

                        //Tài khoản
                        rowData.CreateCell(0, CellType.String).SetCellValue(item["EmployeeId"].ToString());
                        rowData.CreateCell(1, CellType.String).SetCellValue(item["LastName"].ToString());
                        rowData.CreateCell(2, CellType.String).SetCellValue(item["FirstName"].ToString());
                        rowData.CreateCell(3, CellType.String).SetCellValue(item["Email"].ToString());

                        //Cấu hình chấm công
                        rowData.CreateCell(4, CellType.String).SetCellValue("");
                        rowData.CreateCell(5, CellType.String).SetCellValue("");

                        //Cấu hình lương
                        rowData.CreateCell(6, CellType.Numeric).SetCellValue(0);
                        rowData.CreateCell(7, CellType.Numeric).SetCellValue(0);
                        rowData.CreateCell(8, CellType.Numeric).SetCellValue(0);
                        rowData.CreateCell(9, CellType.Numeric).SetCellValue(0);
                        rowData.CreateCell(10, CellType.Numeric).SetCellValue(0);
                        rowData.CreateCell(11, CellType.Numeric).SetCellValue(12);
                        rowData.CreateCell(12, CellType.String).SetCellValue("");

                        row++;
                    }

                    workbook.Write(ms);

                    Excel_Execute(context, ms.ToArray(), filename);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        //Excel báo cáo công việc
        public static void Excel_Work_task_report(string filename, DataTable data, HttpContext context, string employeeName, string date)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    IWorkbook workbook;
                    workbook = new XSSFWorkbook();
                    ISheet excelSheet = workbook.CreateSheet("Báo cáo công việc");

                    //Header

                    /* #region  row 1 */
                    IRow row1 = excelSheet.CreateRow(0);
                    row1.CreateCell(0, CellType.String).SetCellValue("BÁO CÁO CÔNG VIỆC");
                    IRow row2 = excelSheet.CreateRow(1);
                    row2.CreateCell(0, CellType.String).SetCellValue("Họ tên: " + employeeName);
                    IRow row3 = excelSheet.CreateRow(2);
                    row3.CreateCell(0, CellType.String).SetCellValue("Thời gian: " + date);

                    /* #region  row 2 */
                    IRow row4 = excelSheet.CreateRow(4);

                    row4.CreateCell(0, CellType.String).SetCellValue("TÊN NHIỆM VỤ");
                    row4.CreateCell(1, CellType.String).SetCellValue("MIÊU TẢ");
                    row4.CreateCell(2, CellType.String).SetCellValue("NGÀY BẮT ĐẦU");
                    row4.CreateCell(3, CellType.String).SetCellValue("KẾT THÚC");
                    row4.CreateCell(4, CellType.String).SetCellValue("TRẠNG THÁI");
                    row4.CreateCell(5, CellType.String).SetCellValue("NGƯỜI TẠO");


                    /* #region  columns width */
                    excelSheet.SetColumnWidth(0, 10000);
                    excelSheet.SetColumnWidth(1, 7000);
                    excelSheet.SetColumnWidth(2, 6000);
                    excelSheet.SetColumnWidth(3, 6000);
                    excelSheet.SetColumnWidth(4, 5000);
                    excelSheet.SetColumnWidth(5, 10000);

                    /* #endregion */

                    //Body
                    var row = 5;

                    foreach (DataRow item in data.Rows)
                    {
                        var rowData = excelSheet.CreateRow(row);

                        //Tài khoản
                        rowData.CreateCell(0, CellType.String).SetCellValue(item["Title"].ToString());
                        rowData.CreateCell(1, CellType.String).SetCellValue(item["Description"].ToString());
                        rowData.CreateCell(2, CellType.String).SetCellValue(item["DateStart"].ToString());
                        rowData.CreateCell(3, CellType.String).SetCellValue(item["DateEnd"].ToString());
                        rowData.CreateCell(4, CellType.String).SetCellValue(item["Work_Status"].ToString());
                        rowData.CreateCell(5, CellType.String).SetCellValue(item["CreatedBy"].ToString());

                        row++;
                    }

                    workbook.Write(ms);

                    Excel_Execute(context, ms.ToArray(), filename);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        //excel báo giá v1
        public static byte[] Excel_Invoice_V1(string filename, List<DisplayModel> displays, DataTable data, HttpContext context)
        {
            var arrDisplay = displays.Where(n => n.IsDisplay).ToList();
            var count = 1;
            var countDisplay = arrDisplay.Count;
            var countData = data.Rows.Count;

            try
            {
                using (var ms = new MemoryStream())
                {
                    IWorkbook workbook;
                    workbook = new XSSFWorkbook();
                    ISheet excelSheet = workbook.CreateSheet("Sheet1");

                    #region Set style cho cell

                    #region row 2
                    //tạo style
                    var row2 = workbook.CreateCellStyle();
                    //row2.CloneStyleFrom(cellStyleBorder);
                    //row2.FillPattern = FillPattern.SolidForeground;

                    //tạo font cho row
                    var font2 = workbook.CreateFont();
                    font2.FontName = "Times New Roman";
                    font2.IsItalic = true; //chữ nghiêng
                    row2.SetFont(font2);
                    #endregion

                    #region row 3
                    var row3 = workbook.CreateCellStyle();
                    var font3 = workbook.CreateFont();
                    font3.IsBold = true;//chữ in đậm
                    font3.FontName = "Times New Roman";
                    font3.FontHeightInPoints = 14;  //font size                
                    row3.SetFont(font3);
                    row3.Alignment = HorizontalAlignment.Center;   //căn giữa
                    row3.VerticalAlignment = VerticalAlignment.Center;  //căn giữa
                    #endregion

                    #region row 4,5,6
                    var row4 = workbook.CreateCellStyle();
                    var font4 = workbook.CreateFont();
                    font4.IsBold = true;
                    font4.FontName = "Times New Roman";
                    font4.FontHeightInPoints = 11;
                    row4.SetFont(font4);
                    #endregion

                    #region row 8
                    //style cell 1
                    var row8_1 = workbook.CreateCellStyle();
                    var font8_1 = workbook.CreateFont();
                    font8_1.IsBold = true;
                    font8_1.Underline = FontUnderlineType.Single;
                    font8_1.FontName = "Times New Roman";
                    font8_1.FontHeightInPoints = 11;
                    row8_1.SetFont(font8_1);
                    row8_1.Alignment = HorizontalAlignment.Left;
                    row8_1.VerticalAlignment = VerticalAlignment.Center;
                    //style cell 2
                    var row8_2 = workbook.CreateCellStyle();
                    var font8_2 = workbook.CreateFont();
                    font8_2.IsBold = true;
                    font8_2.FontName = "Times New Roman";
                    font8_2.FontHeightInPoints = 11;
                    row8_2.SetFont(font8_2);
                    row8_2.Alignment = HorizontalAlignment.Left;
                    row8_2.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row 9 -> 13
                    var row9 = workbook.CreateCellStyle();
                    var font9 = workbook.CreateFont();
                    font9.FontName = "Times New Roman";
                    font9.FontHeightInPoints = 11;
                    row9.SetFont(font9);
                    row9.Alignment = HorizontalAlignment.Left;
                    row9.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row 15,16
                    var row15 = workbook.CreateCellStyle();
                    var font15 = workbook.CreateFont();
                    font15.FontName = "Times New Roman";
                    font15.FontHeightInPoints = 11;
                    font15.IsBold = true;
                    row15.SetFont(font15);
                    row15.Alignment = HorizontalAlignment.Center;
                    row15.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row cuối
                    var lastrow = workbook.CreateCellStyle();
                    var lfont = workbook.CreateFont();
                    lfont.FontName = "Times New Roman";
                    lfont.FontHeightInPoints = 11;
                    lfont.IsBold = true;
                    lastrow.SetFont(lfont);
                    lastrow.Alignment = HorizontalAlignment.Center;
                    lastrow.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #endregion

                    #region dòng 1
                    //tạo row
                    var r1 = excelSheet.CreateRow(0);

                    //merge cell
                    var cra = new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 11); //merge dòng 0 từ cột 0 đến cột 11               
                    excelSheet.AddMergedRegion(cra);

                    //set height row
                    excelSheet.GetRow(0).Height = 2000;

                    //thêm ảnh vào cell
                    var path = Path.Combine("wwwroot", "files", "image001.png");
                    byte[] daata = File.ReadAllBytes(path);
                    int pictureIndex = workbook.AddPicture(daata, PictureType.PNG);
                    ICreationHelper helper = workbook.GetCreationHelper();
                    IDrawing drawing = excelSheet.CreateDrawingPatriarch();
                    IClientAnchor anchor = helper.CreateClientAnchor();
                    anchor.Col1 = 0;//0 index based column
                    anchor.Row1 = 0;//0 index based row
                    IPicture picture = drawing.CreatePicture(anchor, pictureIndex);
                    picture.Resize(10.05, 0.86);
                    #endregion

                    #region dòng 2
                    var r2 = excelSheet.CreateRow(1);
                    var cra2 = new NPOI.SS.Util.CellRangeAddress(1, 1, 9, 11);
                    excelSheet.AddMergedRegion(cra2);
                    r2.CreateCell(1, CellType.String).SetCellValue("Số:      /Futech-2020");
                    r2.Cells[0].CellStyle = row2; //add style vào cell

                    r2.CreateCell(9, CellType.String).SetCellValue("Hà Nội, Ngày 02 tháng 06 năm 2020");
                    r2.Cells[1].CellStyle = row2;
                    #endregion

                    #region dòng 3
                    var r3 = excelSheet.CreateRow(2);
                    var cra3 = new NPOI.SS.Util.CellRangeAddress(2, 2, 0, 11);
                    excelSheet.AddMergedRegion(cra3);
                    r3.CreateCell(0, CellType.String).SetCellValue("BẢNG BÁO GIÁ CHI TIẾT");
                    r3.Cells[0].CellStyle = row3;
                    #endregion

                    #region dòng 4
                    var r4 = excelSheet.CreateRow(3);
                    var cra4 = new NPOI.SS.Util.CellRangeAddress(3, 3, 0, 11);
                    excelSheet.AddMergedRegion(cra4);
                    r4.CreateCell(0, CellType.String).SetCellValue("HẠNG MỤC: HỆ THỐNG KIỂM SOÁT XE");
                    r4.Cells[0].CellStyle = row4;
                    #endregion

                    #region dòng 5
                    var r5 = excelSheet.CreateRow(4);
                    var cra5 = new NPOI.SS.Util.CellRangeAddress(4, 4, 0, 11);
                    excelSheet.AddMergedRegion(cra5);
                    r5.CreateCell(0, CellType.String).SetCellValue("DỰ ÁN:");
                    r5.Cells[0].CellStyle = row4;
                    #endregion

                    #region dòng 6
                    var r6 = excelSheet.CreateRow(5);
                    var cra6 = new NPOI.SS.Util.CellRangeAddress(5, 5, 0, 11);
                    excelSheet.AddMergedRegion(cra6);
                    r6.CreateCell(0, CellType.String).SetCellValue("ĐỊA ĐIỂM:");
                    r6.Cells[0].CellStyle = row4;
                    #endregion

                    #region dòng 8
                    var r8 = excelSheet.CreateRow(7);

                    //merge cell 1
                    var cra8_1 = new NPOI.SS.Util.CellRangeAddress(7, 7, 0, 6);
                    excelSheet.AddMergedRegion(cra8_1);

                    //merge cell 2
                    var cra8_2 = new NPOI.SS.Util.CellRangeAddress(7, 7, 7, 11);
                    excelSheet.AddMergedRegion(cra8_2);

                    r8.CreateCell(0, CellType.String).SetCellValue("Kính gửi: ");
                    r8.Cells[0].CellStyle = row8_1;
                    r8.Cells[0].CellStyle.WrapText = true; //xuống dòng nếu dữ liệu quá dài

                    r8.CreateCell(7, CellType.String).SetCellValue("Liên hệ: Vũ Viết Tới");
                    r8.Cells[1].CellStyle = row8_2;

                    //set border
                    SetBorder(cra8_1, excelSheet, workbook);
                    SetBorder(cra8_2, excelSheet, workbook);

                    #endregion

                    #region dòng 9
                    var r9 = excelSheet.CreateRow(8);

                    excelSheet.GetRow(8).Height = 700;
                    //merge cell 1
                    var cra9_1 = new NPOI.SS.Util.CellRangeAddress(8, 8, 0, 6);
                    excelSheet.AddMergedRegion(cra9_1);

                    //merge cell 2
                    var cra9_2 = new NPOI.SS.Util.CellRangeAddress(8, 8, 7, 11);
                    excelSheet.AddMergedRegion(cra9_2);

                    r9.CreateCell(0, CellType.String).SetCellValue("");
                    r9.Cells[0].CellStyle = row9;

                    r9.CreateCell(7, CellType.String).SetCellValue("Địa chỉ: Tầng 3, tòa nhà CT2, KĐT Dream Town, P. Tây Mỗ, Q. Nam Từ Liêm, Hà Nội ");
                    r9.Cells[1].CellStyle = row9;
                    r9.Cells[1].CellStyle.WrapText = true;

                    //set border
                    SetBorder(cra9_1, excelSheet, workbook);
                    SetBorder(cra9_2, excelSheet, workbook);
                    #endregion

                    #region dòng 10
                    var r10 = excelSheet.CreateRow(9);

                    //merge cell 1
                    var cra10_1 = new NPOI.SS.Util.CellRangeAddress(9, 9, 0, 6);
                    excelSheet.AddMergedRegion(cra10_1);

                    //merge cell 2
                    var cra10_2 = new NPOI.SS.Util.CellRangeAddress(9, 9, 7, 11);
                    excelSheet.AddMergedRegion(cra10_2);

                    r10.CreateCell(0, CellType.String).SetCellValue("Địa chỉ:");
                    r10.Cells[0].CellStyle = row9;

                    r10.CreateCell(7, CellType.String).SetCellValue("Tel / Fax: 04 355 27 205");
                    r10.Cells[1].CellStyle = row9;
                    r10.Cells[1].CellStyle.WrapText = true;

                    //set border
                    SetBorder(cra10_1, excelSheet, workbook);
                    SetBorder(cra10_2, excelSheet, workbook);
                    #endregion

                    #region dòng 11
                    var r11 = excelSheet.CreateRow(10);

                    //merge cell 1
                    var cra11_1 = new NPOI.SS.Util.CellRangeAddress(10, 10, 0, 6);
                    excelSheet.AddMergedRegion(cra11_1);

                    //merge cell 2
                    var cra11_2 = new NPOI.SS.Util.CellRangeAddress(10, 10, 7, 11);
                    excelSheet.AddMergedRegion(cra11_2);

                    r11.CreateCell(0, CellType.String).SetCellValue("Tel / Fax::");
                    r11.Cells[0].CellStyle = row9;

                    r11.CreateCell(7, CellType.String).SetCellValue("Mobile: 0987 815 646");
                    r11.Cells[1].CellStyle = row9;
                    r11.Cells[1].CellStyle.WrapText = true;

                    //set border
                    SetBorder(cra11_1, excelSheet, workbook);
                    SetBorder(cra11_2, excelSheet, workbook);
                    #endregion

                    #region dòng 12
                    var r12 = excelSheet.CreateRow(11);

                    //merge cell 1
                    var cra12_1 = new NPOI.SS.Util.CellRangeAddress(11, 11, 0, 6);
                    excelSheet.AddMergedRegion(cra12_1);

                    //merge cell 2
                    var cra12_2 = new NPOI.SS.Util.CellRangeAddress(11, 11, 7, 11);
                    excelSheet.AddMergedRegion(cra12_2);

                    r12.CreateCell(0, CellType.String).SetCellValue("Mobile:");
                    r12.Cells[0].CellStyle = row9;

                    r12.CreateCell(7, CellType.String).SetCellValue("Email: viettoi.vu@futech.com.vn");
                    r12.Cells[1].CellStyle = row9;
                    r12.Cells[1].CellStyle.WrapText = true;

                    //set border
                    SetBorder(cra12_1, excelSheet, workbook);
                    SetBorder(cra12_2, excelSheet, workbook);
                    #endregion

                    #region dòng 13
                    var r13 = excelSheet.CreateRow(12);

                    //merge cell 1
                    var cra13_1 = new NPOI.SS.Util.CellRangeAddress(12, 12, 0, 6);
                    excelSheet.AddMergedRegion(cra13_1);

                    //merge cell 2
                    var cra13_2 = new NPOI.SS.Util.CellRangeAddress(12, 12, 7, 11);
                    excelSheet.AddMergedRegion(cra13_2);

                    r13.CreateCell(0, CellType.String).SetCellValue("Email:");
                    r13.Cells[0].CellStyle = row9;

                    r13.CreateCell(7, CellType.String).SetCellValue("Tài khoản: 08088989101 -NH Tiên Phong Bank - CN Thăng Long,Hà Nội");
                    r13.Cells[1].CellStyle = row9;
                    r13.Cells[1].CellStyle.WrapText = true;

                    //set border
                    SetBorder(cra13_1, excelSheet, workbook);
                    SetBorder(cra13_2, excelSheet, workbook);
                    #endregion

                    #region dòng 15, 16
                    var r15 = excelSheet.CreateRow(14);
                    var r16 = excelSheet.CreateRow(15);

                    #region merge cell

                    //merge cell 0
                    var cra15_0 = new NPOI.SS.Util.CellRangeAddress(14, 15, 0, 0);
                    excelSheet.AddMergedRegion(cra15_0);

                    //merge cell 1
                    var cra15_1 = new NPOI.SS.Util.CellRangeAddress(14, 15, 1, 1);
                    excelSheet.AddMergedRegion(cra15_1);

                    //merge cell 2
                    var cra15_2 = new NPOI.SS.Util.CellRangeAddress(14, 15, 2, 2);
                    excelSheet.AddMergedRegion(cra15_2);

                    //merge cell 3
                    var cra15_3 = new NPOI.SS.Util.CellRangeAddress(14, 15, 3, 3);
                    excelSheet.AddMergedRegion(cra15_3);

                    //merge cell 4
                    var cra15_4 = new NPOI.SS.Util.CellRangeAddress(14, 15, 4, 4);
                    excelSheet.AddMergedRegion(cra15_4);

                    //merge cell 5
                    var cra15_5 = new NPOI.SS.Util.CellRangeAddress(14, 15, 5, 5);
                    excelSheet.AddMergedRegion(cra15_5);

                    //merge cell 6
                    var cra15_6 = new NPOI.SS.Util.CellRangeAddress(14, 15, 6, 6);
                    excelSheet.AddMergedRegion(cra15_6);

                    //merge cell 7, 8
                    var cra15_7 = new NPOI.SS.Util.CellRangeAddress(14, 14, 7, 8);
                    excelSheet.AddMergedRegion(cra15_7);

                    //merge cell 9, 10
                    var cra15_9 = new NPOI.SS.Util.CellRangeAddress(14, 14, 9, 10);
                    excelSheet.AddMergedRegion(cra15_9);

                    //merge cell 11
                    var cra15_11 = new NPOI.SS.Util.CellRangeAddress(14, 15, 11, 11);
                    excelSheet.AddMergedRegion(cra15_11);

                    //tạo range row 16 để add border
                    var cra16_0 = new NPOI.SS.Util.CellRangeAddress(15, 15, 7, 7);
                    var cra16_1 = new NPOI.SS.Util.CellRangeAddress(15, 15, 8, 8);
                    var cra16_2 = new NPOI.SS.Util.CellRangeAddress(15, 15, 9, 9);
                    var cra16_3 = new NPOI.SS.Util.CellRangeAddress(15, 15, 10, 10);

                    #endregion

                    #region autosizecolumn
                    excelSheet.SetColumnWidth(0, 1200);
                    excelSheet.SetColumnWidth(1, 15000);
                    excelSheet.SetColumnWidth(2, 3200);
                    excelSheet.SetColumnWidth(3, 2800);
                    excelSheet.SetColumnWidth(4, 2600);
                    excelSheet.SetColumnWidth(5, 2100);
                    excelSheet.SetColumnWidth(6, 2000);
                    excelSheet.SetColumnWidth(7, 3300);
                    excelSheet.SetColumnWidth(8, 3300);
                    excelSheet.SetColumnWidth(9, 3300);
                    excelSheet.SetColumnWidth(10, 3300);
                    excelSheet.SetColumnWidth(11, 3600);
                    #endregion

                    #region Thêm dữ liệu
                    r15.CreateCell(0, CellType.String).SetCellValue("STT");
                    r15.Cells[0].CellStyle = row15;
                    r15.Cells[0].CellStyle.WrapText = true;

                    r15.CreateCell(1, CellType.String).SetCellValue("Nội dung công việc");
                    r15.Cells[1].CellStyle = row15;
                    r15.Cells[1].CellStyle.WrapText = true;

                    r15.CreateCell(2, CellType.String).SetCellValue("Mã hiệu");
                    r15.Cells[2].CellStyle = row15;
                    r15.Cells[2].CellStyle.WrapText = true;

                    r15.CreateCell(3, CellType.String).SetCellValue("Hãng sản xuất");
                    r15.Cells[3].CellStyle = row15;
                    r15.Cells[3].CellStyle.WrapText = true;

                    r15.CreateCell(4, CellType.String).SetCellValue("Xuất xứ");
                    r15.Cells[4].CellStyle = row15;
                    r15.Cells[4].CellStyle.WrapText = true;

                    r15.CreateCell(5, CellType.String).SetCellValue("Đơn vị");
                    r15.Cells[5].CellStyle = row15;
                    r15.Cells[5].CellStyle.WrapText = true;

                    r15.CreateCell(6, CellType.String).SetCellValue("Khối lượng");
                    r15.Cells[6].CellStyle = row15;
                    r15.Cells[6].CellStyle.WrapText = true;

                    r15.CreateCell(7, CellType.String).SetCellValue("Đơn giá (VNĐ)");
                    r15.Cells[7].CellStyle = row15;

                    r15.CreateCell(9, CellType.String).SetCellValue("Thành tiền (VNĐ)");
                    r15.Cells[8].CellStyle = row15;

                    r15.CreateCell(11, CellType.String).SetCellValue("Tổng cộng (VNĐ)");
                    r15.Cells[9].CellStyle = row15;
                    r15.Cells[9].CellStyle.WrapText = true;

                    r16.CreateCell(7, CellType.String).SetCellValue("Vật liệu");
                    r16.Cells[0].CellStyle = row15;

                    r16.CreateCell(8, CellType.String).SetCellValue("Nhân công");
                    r16.Cells[1].CellStyle = row15;

                    r16.CreateCell(9, CellType.String).SetCellValue("Vật liệu");
                    r16.Cells[2].CellStyle = row15;

                    r16.CreateCell(10, CellType.String).SetCellValue("Nhân công");
                    r16.Cells[3].CellStyle = row15;

                    #endregion

                    #region set border
                    SetBorder(cra15_0, excelSheet, workbook);
                    SetBorder(cra15_1, excelSheet, workbook);
                    SetBorder(cra15_2, excelSheet, workbook);
                    SetBorder(cra15_3, excelSheet, workbook);
                    SetBorder(cra15_4, excelSheet, workbook);
                    SetBorder(cra15_5, excelSheet, workbook);
                    SetBorder(cra15_6, excelSheet, workbook);
                    SetBorder(cra15_7, excelSheet, workbook);
                    SetBorder(cra15_9, excelSheet, workbook);
                    SetBorder(cra15_11, excelSheet, workbook);
                    SetBorder(cra16_0, excelSheet, workbook);
                    SetBorder(cra16_1, excelSheet, workbook);
                    SetBorder(cra16_2, excelSheet, workbook);
                    SetBorder(cra16_3, excelSheet, workbook);
                    #endregion



                    #endregion

                    #region dữ liệu chính
                    #endregion

                    #region phần cuối
                    int countdata = 5 + 16 + data.Rows.Count;

                    //dòng 1
                    var lr1 = excelSheet.CreateRow(countdata);
                    var lcra1 = new CellRangeAddress(countdata, countdata, 1, 2);
                    excelSheet.AddMergedRegion(lcra1);
                    lr1.CreateCell(1, CellType.String).SetCellValue("Điều khoản thương mại chung");
                    lr1.Cells[0].CellStyle = row8_1;

                    //dòng 2
                    var lr2 = excelSheet.CreateRow(countdata + 1);
                    var lcra2 = new CellRangeAddress(countdata + 1, countdata + 1, 1, 2);
                    excelSheet.AddMergedRegion(lcra2);
                    lr2.CreateCell(1, CellType.String).SetCellValue("Báo giá có giá trị trong thời gian 30 ngày");
                    lr2.Cells[0].CellStyle = row9;

                    //dòng 3
                    var lr3 = excelSheet.CreateRow(countdata + 2);
                    var lcra3 = new CellRangeAddress(countdata + 2, countdata + 2, 1, 2);
                    excelSheet.AddMergedRegion(lcra3);
                    lr3.CreateCell(1, CellType.String).SetCellValue("Báo giá đã bao gồm VAT 10%");
                    lr3.Cells[0].CellStyle = row9;

                    //dòng 4
                    var lr4 = excelSheet.CreateRow(countdata + 3);
                    var lcra4 = new CellRangeAddress(countdata + 3, countdata + 3, 1, 2);
                    excelSheet.AddMergedRegion(lcra4);
                    lr4.CreateCell(1, CellType.String).SetCellValue("1.Bảo hành");
                    lr4.Cells[0].CellStyle = row8_1;

                    //dòng 5
                    var lr5 = excelSheet.CreateRow(countdata + 4);
                    var lcra5 = new CellRangeAddress(countdata + 4, countdata + 4, 1, 2);
                    excelSheet.AddMergedRegion(lcra5);
                    lr5.CreateCell(1, CellType.String).SetCellValue("Thiết bị mới 100% và được bảo hành 12 tháng ");
                    lr5.Cells[0].CellStyle = row9;

                    //dòng 6
                    var lr6 = excelSheet.CreateRow(countdata + 5);
                    var lcra6 = new CellRangeAddress(countdata + 5, countdata + 5, 1, 2);
                    excelSheet.AddMergedRegion(lcra6);
                    lr6.CreateCell(1, CellType.String).SetCellValue("2. Thanh toán");
                    lr6.Cells[0].CellStyle = row8_1;

                    //dòng 7
                    var lr7 = excelSheet.CreateRow(countdata + 6);
                    var lcra7 = new CellRangeAddress(countdata + 6, countdata + 6, 1, 11);
                    excelSheet.AddMergedRegion(lcra7);
                    lr7.CreateCell(1, CellType.String).SetCellValue("Thanh toán 50% sau khi ký hợp đồng 50% còn lại thanh toán sau khi hai bên ký biên bản bàn giao thiết bị");
                    lr7.Cells[0].CellStyle = row9;

                    //dòng 8
                    var lr8 = excelSheet.CreateRow(countdata + 7);
                    var lcra8 = new CellRangeAddress(countdata + 7, countdata + 7, 1, 11);
                    excelSheet.AddMergedRegion(lcra8);
                    lr8.CreateCell(1, CellType.String).SetCellValue("Thanh toán bằng tiền mặt hoặc chuyển khoản");
                    lr8.Cells[0].CellStyle = row9;

                    //dòng 9
                    var lr9 = excelSheet.CreateRow(countdata + 8);
                    var lcra9 = new CellRangeAddress(countdata + 8, countdata + 8, 1, 11);
                    excelSheet.AddMergedRegion(lcra9);
                    lr9.CreateCell(1, CellType.String).SetCellValue("Giá trị thanh toán được tính dựa trên thực tế thiết bị vật tư được hai bên xác nhận trong biên bản bàn giao, nghiệm thu");
                    lr9.Cells[0].CellStyle = row9;

                    //dòng 10
                    var lr10 = excelSheet.CreateRow(countdata + 10);

                    var lcra10_1 = new CellRangeAddress(countdata + 10, countdata + 10, 1, 3);
                    excelSheet.AddMergedRegion(lcra10_1);

                    var lcra10_2 = new CellRangeAddress(countdata + 10, countdata + 10, 7, 10);
                    excelSheet.AddMergedRegion(lcra10_2);

                    lr10.CreateCell(1, CellType.String).SetCellValue("XÁC NHẬN CỦA KHÁCH HÀNG");
                    lr10.Cells[0].CellStyle = lastrow;

                    lr10.CreateCell(7, CellType.String).SetCellValue("T/M CÔNG TY CỔ PHẦN CÔNG NGHỆ FUTECH");
                    lr10.Cells[1].CellStyle = lastrow;
                    #endregion

                    workbook.Write(ms);

                    Excel_Execute(context, ms.ToArray(), filename);

                    return ms.ToArray();
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }


        }

        public static byte[] Excel_InvoiceFormat(string format, string filename, InvoiceExcelPrintModel data, HttpContext context)
        {
            switch (format)
            {
                case "1":
                    return Excel_Invoice_V1(filename, data, context);

                case "2":
                    return Excel_Invoice_V2(filename, data, context);

                default:
                    return Excel_Invoice_V1(filename, data, context);
            }
        }

        /// <summary>
        /// mẫu có nhân công
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static byte[] Excel_Invoice_V1(string filename, InvoiceExcelPrintModel data, HttpContext context)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    IWorkbook workbook;
                    workbook = new XSSFWorkbook();
                    ISheet excelSheet = workbook.CreateSheet("Sheet1");

                    #region Set style cho cell

                    #region row 2
                    //tạo style
                    var row2 = workbook.CreateCellStyle();
                    //row2.CloneStyleFrom(cellStyleBorder);
                    //row2.FillPattern = FillPattern.SolidForeground;

                    //tạo font cho row
                    var font2 = workbook.CreateFont();
                    font2.FontName = "Times New Roman";
                    font2.IsItalic = true; //chữ nghiêng
                    row2.SetFont(font2);
                    #endregion

                    #region row 3
                    var row3 = workbook.CreateCellStyle();
                    var font3 = workbook.CreateFont();
                    font3.IsBold = true;//chữ in đậm
                    font3.FontName = "Times New Roman";
                    font3.FontHeightInPoints = 14;  //font size                
                    row3.SetFont(font3);
                    row3.Alignment = HorizontalAlignment.Center;   //căn giữa
                    row3.VerticalAlignment = VerticalAlignment.Center;  //căn giữa
                    #endregion

                    #region row 4,5,6
                    var row4 = workbook.CreateCellStyle();
                    var font4 = workbook.CreateFont();
                    font4.IsBold = true;
                    font4.FontName = "Times New Roman";
                    font4.FontHeightInPoints = 11;
                    row4.SetFont(font4);
                    #endregion

                    #region row 8
                    //style cell 1
                    var row8_1 = workbook.CreateCellStyle();
                    var font8_1 = workbook.CreateFont();
                    font8_1.IsBold = true;
                    font8_1.Underline = FontUnderlineType.Single;
                    font8_1.FontName = "Times New Roman";
                    font8_1.FontHeightInPoints = 11;
                    row8_1.SetFont(font8_1);
                    row8_1.Alignment = HorizontalAlignment.Left;
                    row8_1.VerticalAlignment = VerticalAlignment.Center;

                    //style cell 2
                    var row8_2 = workbook.CreateCellStyle();
                    var font8_2 = workbook.CreateFont();
                    font8_2.IsBold = true;
                    font8_2.FontName = "Times New Roman";
                    font8_2.FontHeightInPoints = 11;
                    row8_2.SetFont(font8_2);
                    row8_2.Alignment = HorizontalAlignment.Left;
                    row8_2.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row 9 -> 13
                    var row9 = workbook.CreateCellStyle();
                    var font9 = workbook.CreateFont();
                    font9.FontName = "Times New Roman";
                    font9.FontHeightInPoints = 11;
                    row9.SetFont(font9);
                    row9.Alignment = HorizontalAlignment.Left;
                    row9.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row 15,16
                    var row15 = workbook.CreateCellStyle();
                    var font15 = workbook.CreateFont();
                    font15.FontName = "Times New Roman";
                    font15.FontHeightInPoints = 11;
                    font15.IsBold = true;
                    row15.SetFont(font15);
                    row15.Alignment = HorizontalAlignment.Center;
                    row15.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row cuối
                    var lastrow = workbook.CreateCellStyle();
                    var lfont = workbook.CreateFont();
                    lfont.FontName = "Times New Roman";
                    lfont.FontHeightInPoints = 11;
                    lfont.IsBold = true;
                    lastrow.SetFont(lfont);
                    lastrow.Alignment = HorizontalAlignment.Center;
                    lastrow.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row Summary
                    var rowSummary = workbook.CreateCellStyle();
                    var fontSummary = workbook.CreateFont();
                    fontSummary.IsBold = true;//chữ in đậm
                    fontSummary.FontName = "Times New Roman";
                    fontSummary.FontHeightInPoints = 12;  //font size                
                    rowSummary.SetFont(fontSummary);
                    rowSummary.Alignment = HorizontalAlignment.Center;   //căn giữa
                    rowSummary.VerticalAlignment = VerticalAlignment.Center;  //căn giữa
                    #endregion

                    #endregion

                    #region dữ liệu header

                    #region dòng 1
                    //tạo row
                    var r1 = excelSheet.CreateRow(0);

                    //merge cell
                    var cra = new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 11); //merge dòng 0 từ cột 0 đến cột 11               
                    excelSheet.AddMergedRegion(cra);

                    //set height row
                    excelSheet.GetRow(0).Height = 2000;

                    //thêm ảnh vào cell
                    var path = Path.Combine("wwwroot", "files", "image001.png");
                    byte[] daata = File.ReadAllBytes(path);
                    int pictureIndex = workbook.AddPicture(daata, PictureType.PNG);
                    ICreationHelper helper = workbook.GetCreationHelper();
                    IDrawing drawing = excelSheet.CreateDrawingPatriarch();
                    IClientAnchor anchor = helper.CreateClientAnchor();
                    anchor.Col1 = 0;//0 index based column
                    anchor.Row1 = 0;//0 index based row
                    IPicture picture = drawing.CreatePicture(anchor, pictureIndex);
                    picture.Resize(10.05, 0.86);
                    #endregion

                    #region dòng 2
                    var r2 = excelSheet.CreateRow(1);
                    var cra2 = new NPOI.SS.Util.CellRangeAddress(1, 1, 9, 11);
                    excelSheet.AddMergedRegion(cra2);
                    r2.CreateCell(1, CellType.String).SetCellValue(string.Format("Số:      /Futech-{0}", data.DateNow.ToString("yyyy")));
                    r2.Cells[0].CellStyle = row2; //add style vào cell

                    r2.CreateCell(9, CellType.String).SetCellValue(string.Format("Hà Nội, Ngày {0} tháng {1} năm {2}", data.DateNow.ToString("dd"), data.DateNow.ToString("MM"), data.DateNow.ToString("yyyy")));
                    r2.Cells[1].CellStyle = row2;
                    #endregion

                    #region dòng 3
                    var r3 = excelSheet.CreateRow(2);
                    var cra3 = new NPOI.SS.Util.CellRangeAddress(2, 2, 0, 11);
                    excelSheet.AddMergedRegion(cra3);
                    r3.CreateCell(0, CellType.String).SetCellValue("BẢNG BÁO GIÁ CHI TIẾT");
                    r3.Cells[0].CellStyle = row3;
                    #endregion

                    #region dòng 4
                    var r4 = excelSheet.CreateRow(3);
                    var cra4 = new NPOI.SS.Util.CellRangeAddress(3, 3, 0, 11);
                    excelSheet.AddMergedRegion(cra4);
                    r4.CreateCell(0, CellType.String).SetCellValue(string.Format("HẠNG MỤC: {0}", data.ProjectTypeNames));
                    r4.Cells[0].CellStyle = row4;
                    #endregion

                    #region dòng 5
                    var r5 = excelSheet.CreateRow(4);
                    var cra5 = new NPOI.SS.Util.CellRangeAddress(4, 4, 0, 11);
                    excelSheet.AddMergedRegion(cra5);
                    r5.CreateCell(0, CellType.String).SetCellValue(string.Format("DỰ ÁN: {0}", data.Title));
                    r5.Cells[0].CellStyle = row4;
                    #endregion

                    #region dòng 6
                    var r6 = excelSheet.CreateRow(5);
                    var cra6 = new NPOI.SS.Util.CellRangeAddress(5, 5, 0, 11);
                    excelSheet.AddMergedRegion(cra6);
                    r6.CreateCell(0, CellType.String).SetCellValue(string.Format("ĐỊA ĐIỂM: {0}", data.ProjectAddress));
                    r6.Cells[0].CellStyle = row4;
                    #endregion

                    #region dòng 8
                    var r8 = excelSheet.CreateRow(7);

                    //merge cell 1
                    var cra8_1 = new NPOI.SS.Util.CellRangeAddress(7, 7, 0, 6);
                    excelSheet.AddMergedRegion(cra8_1);

                    //merge cell 2
                    var cra8_2 = new NPOI.SS.Util.CellRangeAddress(7, 7, 7, 11);
                    excelSheet.AddMergedRegion(cra8_2);

                    r8.CreateCell(0, CellType.String).SetCellValue(string.Format("Kính gửi: {0}", data.ContactName));
                    r8.Cells[0].CellStyle = row8_1;
                    r8.Cells[0].CellStyle.WrapText = true; //xuống dòng nếu dữ liệu quá dài

                    r8.CreateCell(7, CellType.String).SetCellValue(string.Format("Liên hệ: {0}", data.AccountName));
                    r8.Cells[1].CellStyle = row8_2;

                    //set border
                    SetBorder(cra8_1, excelSheet, workbook);
                    SetBorder(cra8_2, excelSheet, workbook);

                    #endregion

                    #region dòng 9
                    var r9 = excelSheet.CreateRow(8);

                    excelSheet.GetRow(8).Height = 700;
                    //merge cell 1
                    var cra9_1 = new NPOI.SS.Util.CellRangeAddress(8, 8, 0, 6);
                    excelSheet.AddMergedRegion(cra9_1);

                    //merge cell 2
                    var cra9_2 = new NPOI.SS.Util.CellRangeAddress(8, 8, 7, 11);
                    excelSheet.AddMergedRegion(cra9_2);

                    r9.CreateCell(0, CellType.String).SetCellValue("");
                    r9.Cells[0].CellStyle = row9;

                    r9.CreateCell(7, CellType.String).SetCellValue(string.Format("Địa chỉ: {0}", data.LocationName));
                    r9.Cells[1].CellStyle = row9;
                    r9.Cells[1].CellStyle.WrapText = true;

                    //set border
                    SetBorder(cra9_1, excelSheet, workbook);
                    SetBorder(cra9_2, excelSheet, workbook);
                    #endregion

                    #region dòng 10
                    var r10 = excelSheet.CreateRow(9);

                    //merge cell 1
                    var cra10_1 = new NPOI.SS.Util.CellRangeAddress(9, 9, 0, 6);
                    excelSheet.AddMergedRegion(cra10_1);

                    //merge cell 2
                    var cra10_2 = new NPOI.SS.Util.CellRangeAddress(9, 9, 7, 11);
                    excelSheet.AddMergedRegion(cra10_2);

                    r10.CreateCell(0, CellType.String).SetCellValue(string.Format("Địa chỉ: {0}", data.ContactAddress));
                    r10.Cells[0].CellStyle = row9;

                    r10.CreateCell(7, CellType.String).SetCellValue(string.Format("Tel / Fax: {0}", data.AccountFax));
                    r10.Cells[1].CellStyle = row9;
                    r10.Cells[1].CellStyle.WrapText = true;

                    //set border
                    SetBorder(cra10_1, excelSheet, workbook);
                    SetBorder(cra10_2, excelSheet, workbook);
                    #endregion

                    #region dòng 11
                    var r11 = excelSheet.CreateRow(10);

                    //merge cell 1
                    var cra11_1 = new NPOI.SS.Util.CellRangeAddress(10, 10, 0, 6);
                    excelSheet.AddMergedRegion(cra11_1);

                    //merge cell 2
                    var cra11_2 = new NPOI.SS.Util.CellRangeAddress(10, 10, 7, 11);
                    excelSheet.AddMergedRegion(cra11_2);

                    r11.CreateCell(0, CellType.String).SetCellValue(string.Format("Tel / Fax: {0}", data.ContactFax));
                    r11.Cells[0].CellStyle = row9;

                    r11.CreateCell(7, CellType.String).SetCellValue(string.Format("Mobile: {0}", data.AccountPhone));
                    r11.Cells[1].CellStyle = row9;
                    r11.Cells[1].CellStyle.WrapText = true;

                    //set border
                    SetBorder(cra11_1, excelSheet, workbook);
                    SetBorder(cra11_2, excelSheet, workbook);
                    #endregion

                    #region dòng 12
                    var r12 = excelSheet.CreateRow(11);

                    //merge cell 1
                    var cra12_1 = new NPOI.SS.Util.CellRangeAddress(11, 11, 0, 6);
                    excelSheet.AddMergedRegion(cra12_1);

                    //merge cell 2
                    var cra12_2 = new NPOI.SS.Util.CellRangeAddress(11, 11, 7, 11);
                    excelSheet.AddMergedRegion(cra12_2);

                    r12.CreateCell(0, CellType.String).SetCellValue(string.Format("Mobile: {0}", data.ContactPhone));
                    r12.Cells[0].CellStyle = row9;

                    r12.CreateCell(7, CellType.String).SetCellValue(string.Format("Email: {0}", data.AccountEmail));
                    r12.Cells[1].CellStyle = row9;
                    r12.Cells[1].CellStyle.WrapText = true;

                    //set border
                    SetBorder(cra12_1, excelSheet, workbook);
                    SetBorder(cra12_2, excelSheet, workbook);
                    #endregion

                    #region dòng 13
                    var r13 = excelSheet.CreateRow(12);

                    //merge cell 1
                    var cra13_1 = new NPOI.SS.Util.CellRangeAddress(12, 12, 0, 6);
                    excelSheet.AddMergedRegion(cra13_1);

                    //merge cell 2
                    var cra13_2 = new NPOI.SS.Util.CellRangeAddress(12, 12, 7, 11);
                    excelSheet.AddMergedRegion(cra13_2);

                    r13.CreateCell(0, CellType.String).SetCellValue(string.Format("Email: {0}", data.ContactEmail));
                    r13.Cells[0].CellStyle = row9;

                    r13.CreateCell(7, CellType.String).SetCellValue(string.Format("Tài khoản: {0}", data.BankAccount));
                    r13.Cells[1].CellStyle = row9;
                    r13.Cells[1].CellStyle.WrapText = true;

                    //set border
                    SetBorder(cra13_1, excelSheet, workbook);
                    SetBorder(cra13_2, excelSheet, workbook);
                    #endregion

                    #region dòng 15, 16
                    var r15 = excelSheet.CreateRow(14);
                    var r16 = excelSheet.CreateRow(15);

                    #region merge cell

                    //merge cell 0
                    var cra15_0 = new NPOI.SS.Util.CellRangeAddress(14, 15, 0, 0);
                    excelSheet.AddMergedRegion(cra15_0);

                    //merge cell 1
                    var cra15_1 = new NPOI.SS.Util.CellRangeAddress(14, 15, 1, 1);
                    excelSheet.AddMergedRegion(cra15_1);

                    //merge cell 2
                    var cra15_2 = new NPOI.SS.Util.CellRangeAddress(14, 15, 2, 2);
                    excelSheet.AddMergedRegion(cra15_2);

                    //merge cell 3
                    var cra15_3 = new NPOI.SS.Util.CellRangeAddress(14, 15, 3, 3);
                    excelSheet.AddMergedRegion(cra15_3);

                    //merge cell 4
                    var cra15_4 = new NPOI.SS.Util.CellRangeAddress(14, 15, 4, 4);
                    excelSheet.AddMergedRegion(cra15_4);

                    //merge cell 5
                    var cra15_5 = new NPOI.SS.Util.CellRangeAddress(14, 15, 5, 5);
                    excelSheet.AddMergedRegion(cra15_5);

                    //merge cell 6
                    var cra15_6 = new NPOI.SS.Util.CellRangeAddress(14, 15, 6, 6);
                    excelSheet.AddMergedRegion(cra15_6);

                    //merge cell 7, 8
                    var cra15_7 = new NPOI.SS.Util.CellRangeAddress(14, 14, 7, 8);
                    excelSheet.AddMergedRegion(cra15_7);

                    //merge cell 9, 10
                    var cra15_9 = new NPOI.SS.Util.CellRangeAddress(14, 14, 9, 10);
                    excelSheet.AddMergedRegion(cra15_9);

                    //merge cell 11
                    var cra15_11 = new NPOI.SS.Util.CellRangeAddress(14, 15, 11, 11);
                    excelSheet.AddMergedRegion(cra15_11);

                    //tạo range row 16 để add border
                    var cra16_0 = new NPOI.SS.Util.CellRangeAddress(15, 15, 7, 7);
                    var cra16_1 = new NPOI.SS.Util.CellRangeAddress(15, 15, 8, 8);
                    var cra16_2 = new NPOI.SS.Util.CellRangeAddress(15, 15, 9, 9);
                    var cra16_3 = new NPOI.SS.Util.CellRangeAddress(15, 15, 10, 10);

                    #endregion

                    #region autosizecolumn
                    excelSheet.SetColumnWidth(0, 1200);
                    excelSheet.SetColumnWidth(1, 15000);
                    excelSheet.SetColumnWidth(2, 3200);
                    excelSheet.SetColumnWidth(3, 2800);
                    excelSheet.SetColumnWidth(4, 2600);
                    excelSheet.SetColumnWidth(5, 2100);
                    excelSheet.SetColumnWidth(6, 2000);
                    excelSheet.SetColumnWidth(7, 3300);
                    excelSheet.SetColumnWidth(8, 3300);
                    excelSheet.SetColumnWidth(9, 3300);
                    excelSheet.SetColumnWidth(10, 3300);
                    excelSheet.SetColumnWidth(11, 3600);
                    #endregion

                    #region Thêm dữ liệu
                    r15.CreateCell(0, CellType.String).SetCellValue("STT");
                    r15.Cells[0].CellStyle = row15;
                    r15.Cells[0].CellStyle.WrapText = true;

                    r15.CreateCell(1, CellType.String).SetCellValue("Nội dung công việc");
                    r15.Cells[1].CellStyle = row15;
                    r15.Cells[1].CellStyle.WrapText = true;

                    r15.CreateCell(2, CellType.String).SetCellValue("Mã hiệu");
                    r15.Cells[2].CellStyle = row15;
                    r15.Cells[2].CellStyle.WrapText = true;

                    r15.CreateCell(3, CellType.String).SetCellValue("Hãng sản xuất");
                    r15.Cells[3].CellStyle = row15;
                    r15.Cells[3].CellStyle.WrapText = true;

                    r15.CreateCell(4, CellType.String).SetCellValue("Xuất xứ");
                    r15.Cells[4].CellStyle = row15;
                    r15.Cells[4].CellStyle.WrapText = true;

                    r15.CreateCell(5, CellType.String).SetCellValue("Đơn vị");
                    r15.Cells[5].CellStyle = row15;
                    r15.Cells[5].CellStyle.WrapText = true;

                    r15.CreateCell(6, CellType.String).SetCellValue("Khối lượng");
                    r15.Cells[6].CellStyle = row15;
                    r15.Cells[6].CellStyle.WrapText = true;

                    r15.CreateCell(7, CellType.String).SetCellValue("Đơn giá (VNĐ)");
                    r15.Cells[7].CellStyle = row15;

                    r15.CreateCell(9, CellType.String).SetCellValue("Thành tiền (VNĐ)");
                    r15.Cells[8].CellStyle = row15;

                    r15.CreateCell(11, CellType.String).SetCellValue("Tổng cộng (VNĐ)");
                    r15.Cells[9].CellStyle = row15;
                    r15.Cells[9].CellStyle.WrapText = true;

                    r16.CreateCell(7, CellType.String).SetCellValue("Vật liệu");
                    r16.Cells[0].CellStyle = row15;

                    r16.CreateCell(8, CellType.String).SetCellValue("Nhân công");
                    r16.Cells[1].CellStyle = row15;

                    r16.CreateCell(9, CellType.String).SetCellValue("Vật liệu");
                    r16.Cells[2].CellStyle = row15;

                    r16.CreateCell(10, CellType.String).SetCellValue("Nhân công");
                    r16.Cells[3].CellStyle = row15;

                    #endregion

                    #region set border
                    SetBorder(cra15_0, excelSheet, workbook);
                    SetBorder(cra15_1, excelSheet, workbook);
                    SetBorder(cra15_2, excelSheet, workbook);
                    SetBorder(cra15_3, excelSheet, workbook);
                    SetBorder(cra15_4, excelSheet, workbook);
                    SetBorder(cra15_5, excelSheet, workbook);
                    SetBorder(cra15_6, excelSheet, workbook);
                    SetBorder(cra15_7, excelSheet, workbook);
                    SetBorder(cra15_9, excelSheet, workbook);
                    SetBorder(cra15_11, excelSheet, workbook);
                    SetBorder(cra16_0, excelSheet, workbook);
                    SetBorder(cra16_1, excelSheet, workbook);
                    SetBorder(cra16_2, excelSheet, workbook);
                    SetBorder(cra16_3, excelSheet, workbook);
                    #endregion



                    #endregion#region MyRegion

                    #endregion

                    #region dữ liệu chính
                    int countdata = 16; //Dữ liệu bắt đầu từ

                    #region Data chính

                    if (data.Groups.Any())
                    {
                        var grs = data.Groups.OrderBy(n => n.SortOrder).ToList();

                        foreach (var item in grs)
                        {
                            var products = data.Details.Where(n => n.GroupId == item.Id).ToList();

                            //Tạo dòng cho groups
                            var lrMain = excelSheet.CreateRow(countdata);
                            lrMain.CreateCell(0).SetCellValue(FunctionHelper.ToRomanNumeral(item.SortOrder));

                            SetBorderRange(countdata, 0, 11, excelSheet, workbook);

                            var cra_G = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 1, 11);
                            excelSheet.AddMergedRegion(cra_G);

                            lrMain.CreateCell(1).SetCellValue(item.Title);

                            countdata++;
                            var count = 1;

                            foreach (var itemP in products)
                            {
                                RenderProductList_V1(countdata, excelSheet, workbook, itemP, count);

                                countdata++;
                                count++;
                            }
                        }
                    }
                    else
                    {
                        var count = 1;
                        foreach (var item in data.Details)
                        {
                            RenderProductList_V1(countdata, excelSheet, workbook, item, count);

                            countdata++;
                            count++;
                        }
                    }

                    #endregion

                    #region Phần tổng kết
                    var sumProduct = data.Details.Sum(n => n.Price * n.Quantity);
                    var sumLaborProduct = data.Details.Sum(n => n.LaborPrice * n.Quantity);

                    //Phần tổng kết
                    var lrSummary1 = excelSheet.CreateRow(countdata);

                    lrSummary1.CreateCell(0).SetCellValue("");

                    var craSummary1 = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 1, 8);
                    excelSheet.AddMergedRegion(craSummary1);

                    lrSummary1.CreateCell(1).SetCellValue("TỔNG CỘNG TRƯỚC THUẾ");
                    lrSummary1.CreateCell(9).SetCellValue(sumProduct.ToString("###,###.##"));
                    lrSummary1.CreateCell(10).SetCellValue(sumLaborProduct.ToString("###,###.##"));
                    lrSummary1.CreateCell(11).SetCellValue(data.Details.Sum(n => n.Total).ToString("###,###.##"));

                    lrSummary1.GetCell(1).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 11, excelSheet, workbook);

                    //
                    countdata = countdata + 1;

                    var lrSummaryDis = excelSheet.CreateRow(countdata);

                    lrSummaryDis.CreateCell(0).SetCellValue("");

                    decimal discountmoney = 0;

                    if (data.DiscountType == "1")
                    {
                        discountmoney = data.Amount * (data.Discount / 100);
                    }
                    else
                    {
                        discountmoney = data.Discount;
                    }

                    var craSummaryDis = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 1, 8);
                    excelSheet.AddMergedRegion(craSummaryDis);

                    lrSummaryDis.CreateCell(1).SetCellValue(string.Format("Giảm giá {1} {0}", data.DiscountType == "1" ? "%" : "VND", data.DiscountType == "1" ? data.Discount.ToString("0.#") : ""));
                    lrSummaryDis.CreateCell(9).SetCellValue("");
                    lrSummaryDis.CreateCell(10).SetCellValue("");
                    lrSummaryDis.CreateCell(11).SetCellValue(discountmoney.ToString("###,###.##"));

                    lrSummaryDis.GetCell(1).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 11, excelSheet, workbook);

                    //
                    countdata = countdata + 1;

                    var lrSummaryAmount = excelSheet.CreateRow(countdata);

                    lrSummaryAmount.CreateCell(0).SetCellValue("");

                    var craSummaryAmount = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 1, 8);
                    excelSheet.AddMergedRegion(craSummaryAmount);

                    lrSummaryAmount.CreateCell(1).SetCellValue("TỔNG GIÁ");
                    lrSummaryAmount.CreateCell(9).SetCellValue("");
                    lrSummaryAmount.CreateCell(10).SetCellValue("");
                    lrSummaryAmount.CreateCell(11).SetCellValue(data.Amount.ToString("###,###.##"));

                    lrSummaryAmount.GetCell(1).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 11, excelSheet, workbook);

                    //
                    countdata = countdata + 1;

                    var VATProduct = data.Details.Where(n => n.IsSoftware == false).Sum(n => n.Price * n.Quantity) * Convert.ToDecimal(data.TaxRate / 100);
                    var VATLaborProduct = sumLaborProduct * Convert.ToDecimal(data.TaxRate / 100);

                    var lrSummary2 = excelSheet.CreateRow(countdata);

                    lrSummary2.CreateCell(0).SetCellValue("");

                    var craSummary2 = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 1, 8);
                    excelSheet.AddMergedRegion(craSummary2);

                    lrSummary2.CreateCell(1).SetCellValue(string.Format("VAT {0}% (Phần mềm VAT 0%)", data.TaxRate));
                    lrSummary2.CreateCell(9).SetCellValue(VATProduct.ToString("###,###.##"));
                    lrSummary2.CreateCell(10).SetCellValue(VATLaborProduct.ToString("###,###.##"));
                    lrSummary2.CreateCell(11).SetCellValue(data.Tax.ToString("###,###.##"));

                    lrSummary2.GetCell(1).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 11, excelSheet, workbook);

                    //
                    countdata = countdata + 1;

                    var totalProduct = VATProduct + data.Details.Where(n => n.IsSoftware == false).Sum(n => n.Price * n.Quantity);
                    var totalLaborProduct = VATLaborProduct + sumLaborProduct;

                    var lrSummary3 = excelSheet.CreateRow(countdata);

                    lrSummary3.CreateCell(0).SetCellValue("");

                    var craSummary3 = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 1, 8);
                    excelSheet.AddMergedRegion(craSummary3);

                    lrSummary3.CreateCell(1).SetCellValue("TỔNG SAU THUẾ");
                    lrSummary3.CreateCell(9).SetCellValue(totalProduct.ToString("###,###.##"));
                    lrSummary3.CreateCell(10).SetCellValue(totalLaborProduct.ToString("###,###.##"));
                    lrSummary3.CreateCell(11).SetCellValue(data.Total.ToString("###,###.##"));

                    SetBorderRange(countdata, 0, 11, excelSheet, workbook);

                    lrSummary3.GetCell(1).CellStyle = rowSummary;

                    //
                    countdata = countdata + 1;

                    var lrSummary4 = excelSheet.CreateRow(countdata);

                    lrSummary4.CreateCell(0).SetCellValue("");

                    var craSummary4 = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 1, 11);
                    excelSheet.AddMergedRegion(craSummary4);

                    lrSummary4.CreateCell(1).SetCellValue(string.Format("Bằng chữ: {0}", FunctionHelper.DocTienBangChu(Convert.ToInt64(data.Total), " đồng")));

                    lrSummary4.GetCell(1).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 11, excelSheet, workbook);

                    #endregion

                    #endregion

                    #region phần cuối
                    countdata = countdata + 1;

                    EditFooterExcelByHtml(countdata, workbook, excelSheet, data.Condition);

                    //dòng 10
                    var lr10 = excelSheet.CreateRow(countdata + 10);

                    var lcra10_1 = new CellRangeAddress(countdata + 10, countdata + 10, 1, 3);
                    excelSheet.AddMergedRegion(lcra10_1);

                    var lcra10_2 = new CellRangeAddress(countdata + 10, countdata + 10, 7, 10);
                    excelSheet.AddMergedRegion(lcra10_2);

                    lr10.CreateCell(1, CellType.String).SetCellValue("XÁC NHẬN CỦA KHÁCH HÀNG");
                    lr10.Cells[0].CellStyle = lastrow;

                    lr10.CreateCell(7, CellType.String).SetCellValue("T/M CÔNG TY CỔ PHẦN CÔNG NGHỆ FUTECH");
                    lr10.Cells[1].CellStyle = lastrow;
                    #endregion

                    workbook.Write(ms);

                    //Excel_Execute(context, ms.ToArray(), filename);

                    return ms.ToArray();
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }


        }

        /// <summary>
        /// mẫu không có nhân công
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static byte[] Excel_Invoice_V2(string filename, InvoiceExcelPrintModel data, HttpContext context)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    IWorkbook workbook;
                    workbook = new XSSFWorkbook();
                    ISheet excelSheet = workbook.CreateSheet("Sheet1");

                    #region Set style cho cell

                    #region row 3
                    //tạo style
                    var row3 = workbook.CreateCellStyle();

                    //tạo font cho row
                    var font3 = workbook.CreateFont();
                    font3.FontName = "Times New Roman";
                    font3.IsItalic = true; //chữ nghiêng
                    font3.FontHeightInPoints = 12;
                    row3.Alignment = HorizontalAlignment.Right;   //căn phải
                    row3.VerticalAlignment = VerticalAlignment.Center;  //căn giữa
                    row3.SetFont(font3);
                    #endregion

                    #region row 4
                    //style cell 1
                    var row4_1 = workbook.CreateCellStyle();
                    var font4_1 = workbook.CreateFont();
                    font4_1.IsBold = true;
                    font4_1.Underline = FontUnderlineType.Single;
                    font4_1.FontName = "Times New Roman";
                    font4_1.FontHeightInPoints = 12;
                    row4_1.SetFont(font4_1);
                    row4_1.Alignment = HorizontalAlignment.Left;
                    row4_1.VerticalAlignment = VerticalAlignment.Center;
                    //style cell 2
                    var row4_2 = workbook.CreateCellStyle();
                    var font4_2 = workbook.CreateFont();
                    font4_2.IsBold = true;
                    font4_2.FontName = "Times New Roman";
                    font4_2.FontHeightInPoints = 12;
                    row4_2.SetFont(font4_2);
                    row4_2.Alignment = HorizontalAlignment.Left;
                    row4_2.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row 5 -> 9
                    var row5 = workbook.CreateCellStyle();
                    var font5 = workbook.CreateFont();
                    font5.FontName = "Times New Roman";
                    font5.FontHeightInPoints = 12;
                    row5.SetFont(font5);
                    row5.Alignment = HorizontalAlignment.Left;
                    row5.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row 10
                    var row10 = workbook.CreateCellStyle();
                    var font10 = workbook.CreateFont();
                    font10.IsBold = true;//chữ in đậm
                    font10.FontName = "Times New Roman";
                    font10.FontHeightInPoints = 16;  //font size                
                    row10.SetFont(font10);
                    row10.Alignment = HorizontalAlignment.Center;   //căn giữa
                    row10.VerticalAlignment = VerticalAlignment.Center;  //căn giữa
                    #endregion

                    #region row 11
                    //tạo style
                    var row11 = workbook.CreateCellStyle();

                    //tạo font cho row
                    var font11 = workbook.CreateFont();
                    font11.FontName = "Times New Roman";
                    font11.IsItalic = true; //chữ nghiêng
                    font11.IsBold = true;
                    font11.FontHeightInPoints = 12;
                    row11.Alignment = HorizontalAlignment.Right;   //căn phải
                    row11.VerticalAlignment = VerticalAlignment.Center;  //căn giữa
                    row11.SetFont(font11);
                    #endregion

                    #region row 12
                    var row12 = workbook.CreateCellStyle();
                    var font12 = workbook.CreateFont();
                    font12.FontName = "Times New Roman";
                    font12.FontHeightInPoints = 12;
                    font12.IsBold = true;
                    row12.SetFont(font12);
                    row12.Alignment = HorizontalAlignment.Center;
                    row12.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row cuối
                    var lastrow = workbook.CreateCellStyle();
                    var lfont = workbook.CreateFont();
                    lfont.FontName = "Times New Roman";
                    lfont.FontHeightInPoints = 12;
                    lfont.IsBold = true;
                    lastrow.SetFont(lfont);
                    lastrow.Alignment = HorizontalAlignment.Center;
                    lastrow.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row Summary
                    var rowSummary = workbook.CreateCellStyle();
                    var fontSummary = workbook.CreateFont();
                    fontSummary.IsBold = true;//chữ in đậm
                    fontSummary.FontName = "Times New Roman";
                    fontSummary.FontHeightInPoints = 12;  //font size                
                    rowSummary.SetFont(fontSummary);
                    rowSummary.Alignment = HorizontalAlignment.Center;   //căn giữa
                    rowSummary.VerticalAlignment = VerticalAlignment.Center;  //căn giữa
                    #endregion

                    #endregion

                    #region Header
                    #region dòng 1
                    //tạo row
                    var r1 = excelSheet.CreateRow(0);

                    //merge cell
                    var cra = new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 6); //merge dòng 0 từ cột 0 đến cột 6               
                    excelSheet.AddMergedRegion(cra);

                    //set height row
                    excelSheet.GetRow(0).Height = 1200;

                    //thêm ảnh vào cell
                    var path = Path.Combine("wwwroot", "files", "image001.png");
                    byte[] daata = File.ReadAllBytes(path);
                    int pictureIndex = workbook.AddPicture(daata, PictureType.PNG);
                    ICreationHelper helper = workbook.GetCreationHelper();
                    IDrawing drawing = excelSheet.CreateDrawingPatriarch();
                    IClientAnchor anchor = helper.CreateClientAnchor();
                    anchor.Col1 = 0;//0 index based column
                    anchor.Row1 = 0;//0 index based row
                    IPicture picture = drawing.CreatePicture(anchor, pictureIndex);
                    picture.Resize(5.5, 0.8);
                    #endregion

                    #region dòng 3
                    var r3 = excelSheet.CreateRow(2);
                    var cra3 = new NPOI.SS.Util.CellRangeAddress(2, 2, 4, 6);
                    excelSheet.AddMergedRegion(cra3);
                    r3.CreateCell(4, CellType.String).SetCellValue(string.Format("Hà Nội, Ngày {0} tháng {1} năm {2}", data.DateNow.ToString("dd"), data.DateNow.ToString("MM"), data.DateNow.ToString("yyyy")));
                    r3.Cells[0].CellStyle = row3;
                    #endregion               

                    #region dòng 4
                    var r4 = excelSheet.CreateRow(3);

                    //merge cell 1
                    var cra4_1 = new NPOI.SS.Util.CellRangeAddress(3, 3, 0, 2);
                    excelSheet.AddMergedRegion(cra4_1);

                    //merge cell 2
                    var cra4_2 = new NPOI.SS.Util.CellRangeAddress(3, 3, 3, 6);
                    excelSheet.AddMergedRegion(cra4_2);

                    r4.CreateCell(0, CellType.String).SetCellValue(string.Format("Kính gửi: {0}", data.ContactName));
                    r4.Cells[0].CellStyle = row4_1;
                    r4.Cells[0].CellStyle.WrapText = true; //xuống dòng nếu dữ liệu quá dài

                    r4.CreateCell(3, CellType.String).SetCellValue(string.Format("Liên hệ: {0}", data.AccountName));
                    r4.Cells[1].CellStyle = row4_2;

                    //set border
                    SetBorder(cra4_1, excelSheet, workbook);
                    SetBorder(cra4_2, excelSheet, workbook);

                    #endregion

                    #region dòng 5
                    var r5 = excelSheet.CreateRow(4);

                    // excelSheet.GetRow(4).Height = 700;
                    //merge cell 1
                    var cra5_1 = new NPOI.SS.Util.CellRangeAddress(4, 4, 0, 2);
                    excelSheet.AddMergedRegion(cra5_1);

                    //merge cell 2
                    var cra5_2 = new NPOI.SS.Util.CellRangeAddress(4, 4, 3, 6);
                    excelSheet.AddMergedRegion(cra5_2);

                    r5.CreateCell(0, CellType.String).SetCellValue("");
                    r5.Cells[0].CellStyle = row5;

                    r5.CreateCell(3, CellType.String).SetCellValue(string.Format("Địa chỉ VP: {0}", data.LocationName));
                    r5.Cells[1].CellStyle = row5;
                    r5.Cells[1].CellStyle.WrapText = true;

                    //set border
                    SetBorder(cra5_1, excelSheet, workbook);
                    SetBorder(cra5_2, excelSheet, workbook);
                    #endregion

                    #region dòng 6
                    var r6 = excelSheet.CreateRow(5);

                    //merge cell 1
                    var cra6_1 = new CellRangeAddress(5, 5, 0, 2);
                    excelSheet.AddMergedRegion(cra6_1);

                    //merge cell 2
                    var cra6_2 = new CellRangeAddress(5, 5, 3, 6);
                    excelSheet.AddMergedRegion(cra6_2);

                    r6.CreateCell(0, CellType.String).SetCellValue(string.Format("Địa chỉ:", data.ContactAddress));
                    r6.Cells[0].CellStyle = row5;

                    r6.CreateCell(3, CellType.String).SetCellValue(string.Format("Tel / Fax: {0}", data.AccountFax));
                    r6.Cells[1].CellStyle = row5;
                    r6.Cells[1].CellStyle.WrapText = true;

                    //set border
                    SetBorder(cra6_1, excelSheet, workbook);
                    SetBorder(cra6_2, excelSheet, workbook);
                    #endregion

                    #region dòng 7
                    var r7 = excelSheet.CreateRow(6);

                    //merge cell 1
                    var cra7_1 = new NPOI.SS.Util.CellRangeAddress(6, 6, 0, 2);
                    excelSheet.AddMergedRegion(cra7_1);

                    //merge cell 2
                    var cra7_2 = new NPOI.SS.Util.CellRangeAddress(6, 6, 3, 6);
                    excelSheet.AddMergedRegion(cra7_2);

                    r7.CreateCell(0, CellType.String).SetCellValue(string.Format("Tel / Fax: {0}", data.ContactFax));
                    r7.Cells[0].CellStyle = row5;

                    r7.CreateCell(3, CellType.String).SetCellValue(string.Format("Mobile: {0}", data.AccountPhone));
                    r7.Cells[1].CellStyle = row5;
                    r7.Cells[1].CellStyle.WrapText = true;

                    //set border
                    SetBorder(cra7_1, excelSheet, workbook);
                    SetBorder(cra7_2, excelSheet, workbook);
                    #endregion

                    #region dòng 8
                    var r8 = excelSheet.CreateRow(7);

                    //merge cell 1
                    var cra8_1 = new NPOI.SS.Util.CellRangeAddress(7, 7, 0, 2);
                    excelSheet.AddMergedRegion(cra8_1);

                    //merge cell 2
                    var cra8_2 = new NPOI.SS.Util.CellRangeAddress(7, 7, 3, 6);
                    excelSheet.AddMergedRegion(cra8_2);

                    r8.CreateCell(0, CellType.String).SetCellValue(string.Format("Mobile: {0}", data.ContactPhone));
                    r8.Cells[0].CellStyle = row5;

                    r8.CreateCell(3, CellType.String).SetCellValue(string.Format("Email: {0}", data.AccountEmail));
                    r8.Cells[1].CellStyle = row5;
                    r8.Cells[1].CellStyle.WrapText = true;

                    //set border
                    SetBorder(cra8_1, excelSheet, workbook);
                    SetBorder(cra8_2, excelSheet, workbook);
                    #endregion

                    #region dòng 9
                    var r9 = excelSheet.CreateRow(8);

                    excelSheet.GetRow(8).Height = 700;
                    //merge cell 1
                    var cra9_1 = new NPOI.SS.Util.CellRangeAddress(8, 8, 0, 2);
                    excelSheet.AddMergedRegion(cra9_1);

                    //merge cell 2
                    var cra9_2 = new NPOI.SS.Util.CellRangeAddress(8, 8, 3, 6);
                    excelSheet.AddMergedRegion(cra9_2);

                    r9.CreateCell(0, CellType.String).SetCellValue(string.Format("Email: {0}", data.ContactEmail));
                    r9.Cells[0].CellStyle = row5;

                    r9.CreateCell(3, CellType.String).SetCellValue(string.Format("TK: {0}", data.BankAccount));
                    r9.Cells[1].CellStyle = row5;
                    r9.Cells[1].CellStyle.WrapText = true;

                    //set border
                    SetBorder(cra9_1, excelSheet, workbook);
                    SetBorder(cra9_2, excelSheet, workbook);
                    #endregion

                    #region dòng 10
                    var r10 = excelSheet.CreateRow(9);
                    excelSheet.GetRow(9).Height = 800;
                    var cra10 = new NPOI.SS.Util.CellRangeAddress(9, 9, 0, 6);
                    excelSheet.AddMergedRegion(cra10);
                    r10.CreateCell(0, CellType.String).SetCellValue("BẢNG BÁO GIÁ");
                    r10.Cells[0].CellStyle = row10;
                    #endregion

                    #region dòng 11
                    var r11 = excelSheet.CreateRow(10);
                    var cra11 = new NPOI.SS.Util.CellRangeAddress(10, 10, 0, 6);
                    excelSheet.AddMergedRegion(cra11);
                    r11.CreateCell(0, CellType.String).SetCellValue("ĐVT: VNĐ");
                    r11.Cells[0].CellStyle = row11;
                    #endregion

                    #region dòng 12
                    var r12 = excelSheet.CreateRow(11);
                    excelSheet.GetRow(11).Height = 700;
                    #region autosizecolumn
                    excelSheet.SetColumnWidth(0, 2100);
                    excelSheet.SetColumnWidth(1, 8000);
                    excelSheet.SetColumnWidth(2, 3400);
                    excelSheet.SetColumnWidth(3, 3400);
                    excelSheet.SetColumnWidth(4, 3400);
                    excelSheet.SetColumnWidth(5, 3400);
                    excelSheet.SetColumnWidth(6, 4000);
                    #endregion

                    #region Thêm dữ liệu
                    r12.CreateCell(0, CellType.String).SetCellValue("STT");
                    r12.Cells[0].CellStyle = row12;
                    r12.Cells[0].CellStyle.WrapText = true;

                    r12.CreateCell(1, CellType.String).SetCellValue("Tên thiết bị - Thông số");
                    r12.Cells[1].CellStyle = row12;
                    r12.Cells[1].CellStyle.WrapText = true;

                    r12.CreateCell(2, CellType.String).SetCellValue("Xuất xứ");
                    r12.Cells[2].CellStyle = row12;
                    r12.Cells[2].CellStyle.WrapText = true;

                    r12.CreateCell(3, CellType.String).SetCellValue("Đơn vị");
                    r12.Cells[3].CellStyle = row12;
                    r12.Cells[3].CellStyle.WrapText = true;

                    r12.CreateCell(4, CellType.String).SetCellValue("Số lượng");
                    r12.Cells[4].CellStyle = row12;
                    r12.Cells[4].CellStyle.WrapText = true;

                    r12.CreateCell(5, CellType.String).SetCellValue("Đơn giá");
                    r12.Cells[5].CellStyle = row12;
                    r12.Cells[5].CellStyle.WrapText = true;

                    r12.CreateCell(6, CellType.String).SetCellValue("Thành tiền");
                    r12.Cells[6].CellStyle = row12;
                    r12.Cells[6].CellStyle.WrapText = true;

                    #endregion

                    #region set border
                    SetBorderRange(11, 0, 6, excelSheet, workbook);
                    #endregion

                    #endregion#region MyRegion

                    #endregion

                    #region dữ liệu chính
                    int countdata = 12;

                    #region Data chính

                    if (data.Groups.Any())
                    {
                        var grs = data.Groups.OrderBy(n => n.SortOrder).ToList();

                        foreach (var item in grs)
                        {
                            var products = data.Details.Where(n => n.GroupId == item.Id).ToList();

                            //Tạo dòng cho groups
                            var lrMain = excelSheet.CreateRow(countdata);
                            lrMain.CreateCell(0).SetCellValue(FunctionHelper.ToRomanNumeral(item.SortOrder));

                            SetBorderRange(countdata, 0, 11, excelSheet, workbook);

                            var cra_G = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 1, 11);
                            excelSheet.AddMergedRegion(cra_G);

                            lrMain.CreateCell(1).SetCellValue(item.Title);

                            countdata++;
                            var count = 1;

                            foreach (var itemP in products)
                            {
                                RenderProductList_V2(countdata, excelSheet, workbook, itemP, count);

                                countdata++;
                                count++;
                            }
                        }
                    }
                    else
                    {
                        var count = 1;
                        foreach (var item in data.Details)
                        {
                            RenderProductList_V2(countdata, excelSheet, workbook, item, count);

                            countdata++;
                            count++;
                        }
                    }

                    #endregion

                    #region Phần tổng kết
                    var sumProduct = data.Details.Sum(n => n.Price * n.Quantity);

                    //Phần tổng kết
                    var lrSummary1 = excelSheet.CreateRow(countdata);

                    var craSummary1 = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 0, 5);
                    excelSheet.AddMergedRegion(craSummary1);

                    lrSummary1.CreateCell(0).SetCellValue("TỔNG CỘNG TRƯỚC THUẾ");
                    lrSummary1.CreateCell(6).SetCellValue(sumProduct.ToString("###,###.##"));

                    lrSummary1.GetCell(0).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 6, excelSheet, workbook);

                    //
                    countdata = countdata + 1;

                    var lrSummaryDis = excelSheet.CreateRow(countdata);

                    decimal discountmoney = 0;

                    if (data.DiscountType == "1")
                    {
                        discountmoney = data.Amount * (data.Discount / 100);
                    }
                    else
                    {
                        discountmoney = data.Discount;
                    }

                    var craSummaryDis = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 0, 5);
                    excelSheet.AddMergedRegion(craSummaryDis);

                    lrSummaryDis.CreateCell(0).SetCellValue(string.Format("Giảm giá {1} {0}", data.DiscountType == "1" ? "%" : "VND", data.DiscountType == "1" ? data.Discount.ToString("0.#") : ""));
                    lrSummaryDis.CreateCell(6).SetCellValue(discountmoney.ToString("###,###.##"));

                    lrSummaryDis.GetCell(0).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 6, excelSheet, workbook);

                    //
                    countdata = countdata + 1;

                    var lrSummaryAmount = excelSheet.CreateRow(countdata);

                    var craSummaryAmount = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 0, 5);
                    excelSheet.AddMergedRegion(craSummaryAmount);

                    lrSummaryAmount.CreateCell(0).SetCellValue("TỔNG GIÁ");
                    lrSummaryAmount.CreateCell(6).SetCellValue(data.Amount.ToString("###,###.##"));

                    lrSummaryAmount.GetCell(0).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 6, excelSheet, workbook);

                    //
                    countdata = countdata + 1;

                    var VATProduct = data.Details.Where(n => n.IsSoftware == false).Sum(n => n.Price * n.Quantity) * Convert.ToDecimal(data.TaxRate / 100);

                    var lrSummary2 = excelSheet.CreateRow(countdata);

                    var craSummary2 = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 0, 5);
                    excelSheet.AddMergedRegion(craSummary2);

                    lrSummary2.CreateCell(0).SetCellValue(string.Format("VAT {0}% (Phần mềm VAT 0%)", data.TaxRate));
                    lrSummary2.CreateCell(6).SetCellValue(VATProduct.ToString("###,###.##"));

                    lrSummary2.GetCell(0).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 6, excelSheet, workbook);

                    //
                    countdata = countdata + 1;

                    var totalProduct = VATProduct + data.Details.Where(n => n.IsSoftware == false).Sum(n => n.Price * n.Quantity);

                    var lrSummary3 = excelSheet.CreateRow(countdata);

                    var craSummary3 = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 0, 5);
                    excelSheet.AddMergedRegion(craSummary3);

                    lrSummary3.CreateCell(0).SetCellValue("TỔNG SAU THUẾ");
                    lrSummary3.CreateCell(6).SetCellValue(totalProduct.ToString("###,###.##"));

                    SetBorderRange(countdata, 0, 6, excelSheet, workbook);

                    lrSummary3.GetCell(0).CellStyle = rowSummary;

                    //
                    countdata = countdata + 1;

                    var lrSummary4 = excelSheet.CreateRow(countdata);

                    var craSummary4 = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 0, 6);
                    excelSheet.AddMergedRegion(craSummary4);

                    lrSummary4.CreateCell(0).SetCellValue(string.Format("Bằng chữ: {0}", FunctionHelper.DocTienBangChu(Convert.ToInt64(data.Total), " đồng")));

                    lrSummary4.GetCell(0).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 6, excelSheet, workbook);

                    #endregion

                    #endregion

                    #region phần cuối
                    countdata = countdata + 1;

                    EditFooterExcelByHtml(countdata, workbook, excelSheet, data.Condition);

                    //dòng 6
                    var lr6 = excelSheet.CreateRow(countdata + 6);

                    var lcra6_1 = new CellRangeAddress(countdata + 6, countdata + 6, 0, 1);
                    excelSheet.AddMergedRegion(lcra6_1);

                    var lcra6_2 = new CellRangeAddress(countdata + 6, countdata + 6, 4, 6);
                    excelSheet.AddMergedRegion(lcra6_2);

                    lr6.CreateCell(0, CellType.String).SetCellValue("XÁC NHẬN KHÁCH HÀNG");
                    lr6.Cells[0].CellStyle = lastrow;

                    lr6.CreateCell(4, CellType.String).SetCellValue("T/M CTCP CN FUTECH");
                    lr6.Cells[1].CellStyle = lastrow;
                    #endregion

                    workbook.Write(ms);

                    //Excel_Execute(context, ms.ToArray(), filename);

                    return ms.ToArray();
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private static void RenderProductList_V1(int countdata, ISheet excelSheet, IWorkbook workbook, InvoiceExcelPrintModel_Detail item, int count)
        {
            var ProductAmount = item.Quantity * item.Price;
            var LaborAmount = item.Quantity * item.LaborPrice;

            var lrMain = excelSheet.CreateRow(countdata);

            lrMain.CreateCell(0).SetCellValue(count); //STT
            lrMain.CreateCell(1).SetCellValue(item.ProductName); //Tên sản phẩm
            lrMain.CreateCell(2).SetCellValue(item.ProductCode); //Mã sản phẩm
            lrMain.CreateCell(3).SetCellValue(item.Supplier); //Hãng sản xuất
            lrMain.CreateCell(4).SetCellValue(item.CountryName); //Xuất xứ
            lrMain.CreateCell(5).SetCellValue(item.UnitName); //Đơn vị
            lrMain.CreateCell(6).SetCellValue(item.Quantity); //Khối lượng
            lrMain.CreateCell(7).SetCellValue(item.Price.ToString("###,###.##")); //Đơn giá/Vật liệu
            lrMain.CreateCell(8).SetCellValue(item.LaborPrice.ToString("###,###.##")); //Đơn giá/Nhân công
            lrMain.CreateCell(9).SetCellValue(ProductAmount.ToString("###,###.##")); //Thành tiền/Vật liệu
            lrMain.CreateCell(10).SetCellValue(LaborAmount.ToString("###,###.##")); //Thành tiền/Nhân công
            lrMain.CreateCell(11).SetCellValue(item.Total.ToString("###,###.##")); //Tổng cộng

            //
            SetBorderRange(countdata, 0, 11, excelSheet, workbook);
        }

        private static void RenderProductList_V2(int countdata, ISheet excelSheet, IWorkbook workbook, InvoiceExcelPrintModel_Detail item, int count)
        {
            var ProductAmount = item.Quantity * item.Price;
            var LaborAmount = item.Quantity * item.LaborPrice;

            var lrMain = excelSheet.CreateRow(countdata);

            lrMain.CreateCell(0).SetCellValue(count); //STT
            lrMain.CreateCell(1).SetCellValue(string.Format("{0} ({1})", item.ProductName, item.ProductCode)); //Tên sản phẩm
            lrMain.CreateCell(2).SetCellValue(item.CountryName); //Xuất xứ
            lrMain.CreateCell(3).SetCellValue(item.UnitName); //Đơn vị
            lrMain.CreateCell(4).SetCellValue(item.Quantity); //Khối lượng
            lrMain.CreateCell(5).SetCellValue(item.Price.ToString("###,###.##")); //Đơn giá
            lrMain.CreateCell(6).SetCellValue(item.Total.ToString("###,###.##")); //Tổng cộng

            //
            SetBorderRange(countdata, 0, 6, excelSheet, workbook);
        }

        /// <summary>
        /// set border cho row
        /// </summary>
        /// <param name="row"></param>
        /// <param name="style"></param>
        static void SetBorderRange(int currentrow, int fromcol, int tocol, ISheet sheet, IWorkbook workbook)
        {
            for (int i = fromcol; i <= tocol; i++)
            {
                var borders = new NPOI.SS.Util.CellRangeAddress(currentrow, currentrow, i, i);
                SetBorder(borders, sheet, workbook);
            }
        }

        static void SetBorderRange(int fromrow, int torow, int fromcol, int tocol, ISheet sheet, IWorkbook workbook)
        {
            var borderedCellStyle = workbook.CreateCellStyle();
            borderedCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            borderedCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            borderedCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            borderedCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;

            for (int i = fromrow; i <= torow; i++)
            {
                var tempRow = sheet.GetRow(i);
                if (tempRow != null)
                {
                    foreach (var item in tempRow.Cells)
                    {
                        item.CellStyle = borderedCellStyle;
                    }
                }
            }
        }

        /// <summary>
        /// set border cho row
        /// </summary>
        /// <param name="row"></param>
        /// <param name="style"></param>
        static void SetBorder(CellRangeAddress range, ISheet sheet, IWorkbook workbook)
        {
            RegionUtil.SetBorderBottom(1, range, sheet, workbook);
            RegionUtil.SetBorderLeft(1, range, sheet, workbook);
            RegionUtil.SetBorderRight(1, range, sheet, workbook);
            RegionUtil.SetBorderTop(1, range, sheet, workbook);
        }

        private static void Excel_Execute(HttpContext context, byte[] data, string filename)
        {
            try
            {
                //package.Workbook.Properties.Title = "Attempts";
                context.Response.OnStarting(state =>
                {
                    var httpContext = (HttpContext)state;

                    httpContext.Response.Headers.Add(
                         "content-disposition",
                          string.Format("attachment; filename={0}.xlsx", filename)
                    );

                    httpContext.Response.ContentLength = data.Length;
                    httpContext.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    httpContext.Response.Body.WriteAsync(data).AsTask();

                    return Task.FromResult(0);
                }, context);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static byte[] TemplateImportCustomer_V3()
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    //
                    IWorkbook workbook;
                    workbook = new XSSFWorkbook();

                    #region Tab - sản phẩm
                    //Sản phẩm
                    ISheet excelSheet_TAB1 = workbook.CreateSheet("Đối tác");

                    //
                    var headerProduct = excelSheet_TAB1.CreateRow(0);
                    headerProduct.CreateCell(0).SetCellValue("Mã số thuế (0)");
                    headerProduct.CreateCell(1).SetCellValue("Tên đối tác (1)");
                    headerProduct.CreateCell(2).SetCellValue("Địa chỉ (2)");

                    //border
                    SetBorderRange(0, 2, 0, 2, excelSheet_TAB1, workbook);

                    //Phần nhập sản phẩm
                    for (int i = 0; i <= 2; i++)
                    {
                        var merProduct = new NPOI.SS.Util.CellRangeAddress(0, 1, i, i);
                        excelSheet_TAB1.AddMergedRegion(merProduct);
                    }

                    //Chỉ độ rộng
                    for (int i = 0; i <= 2; i++)
                    {
                        excelSheet_TAB1.SetColumnWidth(i, 5000);
                    }

                    #endregion

                    //
                    workbook.Write(ms);

                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static byte[] TemplateImportProduct_V3()
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    //
                    IWorkbook workbook;
                    workbook = new XSSFWorkbook();

                    #region Tab - sản phẩm
                    //Sản phẩm
                    ISheet excelSheet_TAB1 = workbook.CreateSheet("Sản phẩm");

                    //
                    var headerProduct = excelSheet_TAB1.CreateRow(0);
                    headerProduct.CreateCell(0).SetCellValue("Mã sản phẩm (0)");
                    headerProduct.CreateCell(1).SetCellValue("Tên sản phẩm (1)");
                    headerProduct.CreateCell(2).SetCellValue("Xuất xứ (2)");
                    headerProduct.CreateCell(3).SetCellValue("Giá bán đại lý (3)");
                    headerProduct.CreateCell(4).SetCellValue("Giá bán lẻ (4)");

                    //border
                    SetBorderRange(0, 1, 0, 4, excelSheet_TAB1, workbook);

                    //Phần nhập sản phẩm
                    for (int i = 0; i <= 4; i++)
                    {
                        var merProduct = new NPOI.SS.Util.CellRangeAddress(0, 1, i, i);
                        excelSheet_TAB1.AddMergedRegion(merProduct);
                    }

                    //Chỉ độ rộng
                    for (int i = 0; i <= 4; i++)
                    {
                        excelSheet_TAB1.SetColumnWidth(i, 5000);
                    }

                    #endregion

                    //
                    workbook.Write(ms);

                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static byte[] TemplateImportProduct_V3(List<SelectListModel> ProductTypes, List<SelectListModel> Suppliers, List<SelectListModel> Units)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    //
                    IWorkbook workbook;
                    workbook = new XSSFWorkbook();

                    #region Tab - sản phẩm
                    //Sản phẩm
                    ISheet excelSheet_TAB1 = workbook.CreateSheet("Sản phẩm");

                    //
                    var headerProduct = excelSheet_TAB1.CreateRow(0);
                    headerProduct.CreateCell(0).SetCellValue("Mã sản phẩm (0)");
                    headerProduct.CreateCell(1).SetCellValue("Tên sản phẩm (1)");
                    headerProduct.CreateCell(2).SetCellValue("Mô tả (2)");
                    headerProduct.CreateCell(3).SetCellValue("Đơn vị (3)");
                    headerProduct.CreateCell(4).SetCellValue("Nơi sản xuất (4)");
                    headerProduct.CreateCell(5).SetCellValue("Quốc gia (5)");
                    headerProduct.CreateCell(6).SetCellValue("Nhà cung cấp (6)");
                    headerProduct.CreateCell(7).SetCellValue("Loại sản phẩm (7)");
                    headerProduct.CreateCell(8).SetCellValue("Trạng thái sản phẩm (8)");
                    headerProduct.CreateCell(9).SetCellValue("Giá vật tư");
                    headerProduct.CreateCell(10).SetCellValue("");
                    headerProduct.CreateCell(11).SetCellValue("");
                    headerProduct.CreateCell(12).SetCellValue("");
                    headerProduct.CreateCell(13).SetCellValue("");
                    headerProduct.CreateCell(14).SetCellValue("");
                    headerProduct.CreateCell(15).SetCellValue("");
                    headerProduct.CreateCell(16).SetCellValue("");

                    //
                    var headerPrice = excelSheet_TAB1.CreateRow(1);
                    headerPrice.CreateCell(0).SetCellValue("");
                    headerPrice.CreateCell(1).SetCellValue("");
                    headerPrice.CreateCell(2).SetCellValue("");
                    headerPrice.CreateCell(3).SetCellValue("");
                    headerPrice.CreateCell(4).SetCellValue("");
                    headerPrice.CreateCell(5).SetCellValue("");
                    headerPrice.CreateCell(6).SetCellValue("");
                    headerPrice.CreateCell(7).SetCellValue("");
                    headerPrice.CreateCell(8).SetCellValue("");
                    headerPrice.CreateCell(9).SetCellValue("Giá USD (9)");
                    headerPrice.CreateCell(10).SetCellValue("Giá VND (10)");
                    headerPrice.CreateCell(11).SetCellValue("Chi phí VND (11)");
                    headerPrice.CreateCell(12).SetCellValue("Giá tại kho VND (12)");
                    headerPrice.CreateCell(13).SetCellValue("Giá bán ra 1 VND (13)");
                    headerPrice.CreateCell(14).SetCellValue("Giá bán ra 2 VND (14)");
                    headerPrice.CreateCell(15).SetCellValue("Giá bán ra 3 VND (15)");
                    headerPrice.CreateCell(16).SetCellValue("Giá bán ra 4 VND (16)");

                    //border
                    SetBorderRange(0, 1, 0, 16, excelSheet_TAB1, workbook);

                    //Phần nhập sản phẩm
                    for (int i = 0; i <= 8; i++)
                    {
                        var merProduct = new NPOI.SS.Util.CellRangeAddress(0, 1, i, i);
                        excelSheet_TAB1.AddMergedRegion(merProduct);
                    }

                    //Chỉ độ rộng
                    for (int i = 0; i <= 16; i++)
                    {
                        excelSheet_TAB1.SetColumnWidth(i, 5000);
                    }

                    //Phần header phần giá vật tư
                    var merProductPrice = new NPOI.SS.Util.CellRangeAddress(0, 0, 9, 16);
                    excelSheet_TAB1.AddMergedRegion(merProductPrice);
                    #endregion

                    #region Tab - Đơn vị

                    ISheet excelSheet_TAB7 = workbook.CreateSheet("Đơn vị");
                    excelSheet_TAB7.SetColumnWidth(0, 8000);

                    var headerTab7 = excelSheet_TAB7.CreateRow(0);
                    headerTab7.CreateCell(0).SetCellValue("Tên đơn vị");
                    headerTab7.CreateCell(1).SetCellValue("Chỉ chọn một cái duy nhất cho từng sản phẩm");

                    SetBorderRange(0, 0, 0, excelSheet_TAB7, workbook);

                    //Dữ liệu nơi sản xuất
                    var currentrowTab7 = 1;
                    foreach (var item in Units)
                    {
                        var rowTab7 = excelSheet_TAB7.CreateRow(currentrowTab7);
                        rowTab7.CreateCell(0).SetCellValue(item.ItemText);

                        currentrowTab7++;
                    }
                    #endregion

                    #region Tab - Nơi sản xuất

                    ISheet excelSheet_TAB4 = workbook.CreateSheet("Nơi sản xuất");
                    excelSheet_TAB4.SetColumnWidth(0, 8000);

                    var headerTab4 = excelSheet_TAB4.CreateRow(0);
                    headerTab4.CreateCell(0).SetCellValue("Tên nơi sản xuất");
                    headerTab4.CreateCell(1).SetCellValue("Chỉ chọn một cái duy nhất cho từng sản phẩm");

                    SetBorderRange(0, 0, 0, excelSheet_TAB4, workbook);

                    //Dữ liệu nơi sản xuất
                    var dataOrigins = StaticList.ProductOrigin();
                    var currentrowTab4 = 1;
                    foreach (var item in dataOrigins)
                    {
                        var rowTab4 = excelSheet_TAB4.CreateRow(currentrowTab4);
                        rowTab4.CreateCell(0).SetCellValue(item.ItemText);

                        currentrowTab4++;
                    }
                    #endregion

                    #region Tab - Mã quốc gia
                    //Mã quốc gia
                    ISheet excelSheet_TAB2 = workbook.CreateSheet("Mã quốc gia");
                    excelSheet_TAB2.SetColumnWidth(0, 2000);
                    excelSheet_TAB2.SetColumnWidth(1, 4000);

                    var headerTab2 = excelSheet_TAB2.CreateRow(0);
                    headerTab2.CreateCell(0).SetCellValue("Code");
                    headerTab2.CreateCell(1).SetCellValue("Country");
                    headerTab2.CreateCell(2).SetCellValue("Có thể nhập nhiều Mã quốc gia trên cùng một sản phẩm. Cách nhau dấu ','");

                    SetBorderRange(0, 0, 1, excelSheet_TAB2, workbook);

                    //Thêm dữ liệu phần mã quốc gia
                    var dataCountries = FunctionHelper.GetCountries().Result;
                    var currentrowTab2 = 1;
                    foreach (var item in dataCountries)
                    {
                        var rowTab2 = excelSheet_TAB2.CreateRow(currentrowTab2);
                        rowTab2.CreateCell(0).SetCellValue(item.ItemValue);
                        rowTab2.CreateCell(1).SetCellValue(item.ItemText);

                        currentrowTab2++;
                    }

                    #endregion

                    #region Tab - Nhà cung cấp

                    ISheet excelSheet_TAB6 = workbook.CreateSheet("Nhà cung cấp");
                    excelSheet_TAB6.SetColumnWidth(0, 8000);

                    var headerTab6 = excelSheet_TAB6.CreateRow(0);
                    headerTab6.CreateCell(0).SetCellValue("Tên nhà cung cấp");
                    headerTab6.CreateCell(1).SetCellValue("Chỉ chọn một cái duy nhất cho từng sản phẩm");

                    SetBorderRange(0, 0, 0, excelSheet_TAB6, workbook);

                    //Dữ liệu nơi sản xuất
                    var currentrowTab6 = 1;
                    foreach (var item in Suppliers)
                    {
                        var rowTab6 = excelSheet_TAB6.CreateRow(currentrowTab6);
                        rowTab6.CreateCell(0).SetCellValue(item.ItemText);

                        currentrowTab6++;
                    }
                    #endregion

                    #region Tab - Loại sản phẩm
                    //Loại sản phẩm
                    ISheet excelSheet_TAB3 = workbook.CreateSheet("Loại sản phẩm");
                    excelSheet_TAB3.SetColumnWidth(0, 8000);

                    var headerTab3 = excelSheet_TAB3.CreateRow(0);
                    headerTab3.CreateCell(0).SetCellValue("Tên loại sản phẩm");
                    headerTab3.CreateCell(1).SetCellValue("Có thể nhập nhiều tên trên cùng một sản phẩm. Cách nhau dấu ','");

                    SetBorderRange(0, 0, 0, excelSheet_TAB3, workbook);

                    //Dữ liệu loại sản phẩm
                    var currentrowTab3 = 1;
                    foreach (var item in ProductTypes)
                    {
                        var rowTab3 = excelSheet_TAB3.CreateRow(currentrowTab3);
                        rowTab3.CreateCell(0).SetCellValue(item.ItemText);

                        currentrowTab3++;
                    }

                    #endregion

                    #region Tab - Trạng thái sản phẩm

                    ISheet excelSheet_TAB5 = workbook.CreateSheet("Trạng thái sản phẩm");
                    excelSheet_TAB5.SetColumnWidth(0, 8000);

                    var headerTab5 = excelSheet_TAB5.CreateRow(0);
                    headerTab5.CreateCell(0).SetCellValue("Tên trạng thái");
                    headerTab5.CreateCell(1).SetCellValue("Chỉ chọn một cái tên duy nhất cho từng sản phẩm");

                    SetBorderRange(0, 0, 0, excelSheet_TAB5, workbook);

                    //Dữ liệu nơi sản xuất
                    var dataStatues = StaticList.ProductStatus();
                    dataStatues.RemoveAt(0);

                    var currentrowTab5 = 1;
                    foreach (var item in dataStatues)
                    {
                        var rowTab5 = excelSheet_TAB5.CreateRow(currentrowTab5);
                        rowTab5.CreateCell(0).SetCellValue(item.ItemText);

                        currentrowTab5++;
                    }
                    #endregion

                    //
                    workbook.Write(ms);

                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void EditFooterExcelByHtml(int countdata, IWorkbook workbook, ISheet excelSheet, string html)
        {
            if (!string.IsNullOrWhiteSpace(html))
            {
                //style cell 1
                var row8_1 = workbook.CreateCellStyle();
                var font8_1 = workbook.CreateFont();
                font8_1.IsBold = true;
                //font8_1.Underline = FontUnderlineType.Single;
                font8_1.FontName = "Times New Roman";
                font8_1.FontHeightInPoints = 11;
                row8_1.SetFont(font8_1);
                row8_1.Alignment = HorizontalAlignment.Left;
                row8_1.VerticalAlignment = VerticalAlignment.Center;

                var row9 = workbook.CreateCellStyle();
                var font9 = workbook.CreateFont();
                font9.FontName = "Times New Roman";
                font9.FontHeightInPoints = 11;
                row9.SetFont(font9);
                row9.Alignment = HorizontalAlignment.Left;
                row9.VerticalAlignment = VerticalAlignment.Center;

                //Xử lý dữ liệu
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);

                var myNodes = doc.DocumentNode.SelectNodes("//div");

                foreach (var item in myNodes)
                {
                    if (!string.IsNullOrWhiteSpace(item.InnerText))
                    {
                        var bold = item.Descendants("b").Any();

                        //
                        var lrR = excelSheet.CreateRow(countdata);
                        var lcraR = new CellRangeAddress(countdata, countdata, 1, 11);
                        excelSheet.AddMergedRegion(lcraR);
                        lrR.CreateCell(1, CellType.String).SetCellValue(item.InnerText);
                        lrR.Cells[0].CellStyle = bold ? row8_1 : row9;

                        //
                        countdata = countdata + 1;
                    }

                }

                // //dòng 1
                // var lr1 = excelSheet.CreateRow(countdata);
                // var lcra1 = new CellRangeAddress(countdata, countdata, 1, 2);
                // excelSheet.AddMergedRegion(lcra1);
                // lr1.CreateCell(1, CellType.String).SetCellValue("Điều khoản thương mại chung");
                // lr1.Cells[0].CellStyle = row8_1;

                // //dòng 2
                // var lr2 = excelSheet.CreateRow(countdata + 1);
                // var lcra2 = new CellRangeAddress(countdata + 1, countdata + 1, 1, 2);
                // excelSheet.AddMergedRegion(lcra2);
                // lr2.CreateCell(1, CellType.String).SetCellValue("Báo giá có giá trị trong thời gian 30 ngày");
                // lr2.Cells[0].CellStyle = row9;

                // //dòng 3
                // var lr3 = excelSheet.CreateRow(countdata + 2);
                // var lcra3 = new CellRangeAddress(countdata + 2, countdata + 2, 1, 2);
                // excelSheet.AddMergedRegion(lcra3);
                // lr3.CreateCell(1, CellType.String).SetCellValue("Báo giá đã bao gồm VAT 10%");
                // lr3.Cells[0].CellStyle = row9;

                // //dòng 4
                // var lr4 = excelSheet.CreateRow(countdata + 3);
                // var lcra4 = new CellRangeAddress(countdata + 3, countdata + 3, 1, 2);
                // excelSheet.AddMergedRegion(lcra4);
                // lr4.CreateCell(1, CellType.String).SetCellValue("1.Bảo hành");
                // lr4.Cells[0].CellStyle = row8_1;

                // //dòng 5
                // var lr5 = excelSheet.CreateRow(countdata + 4);
                // var lcra5 = new CellRangeAddress(countdata + 4, countdata + 4, 1, 2);
                // excelSheet.AddMergedRegion(lcra5);
                // lr5.CreateCell(1, CellType.String).SetCellValue("Thiết bị mới 100% và được bảo hành 12 tháng ");
                // lr5.Cells[0].CellStyle = row9;

                // //dòng 6
                // var lr6 = excelSheet.CreateRow(countdata + 5);
                // var lcra6 = new CellRangeAddress(countdata + 5, countdata + 5, 1, 2);
                // excelSheet.AddMergedRegion(lcra6);
                // lr6.CreateCell(1, CellType.String).SetCellValue("2. Thanh toán");
                // lr6.Cells[0].CellStyle = row8_1;

                // //dòng 7
                // var lr7 = excelSheet.CreateRow(countdata + 6);
                // var lcra7 = new CellRangeAddress(countdata + 6, countdata + 6, 1, 11);
                // excelSheet.AddMergedRegion(lcra7);
                // lr7.CreateCell(1, CellType.String).SetCellValue("Thanh toán 50% sau khi ký hợp đồng 50% còn lại thanh toán sau khi hai bên ký biên bản bàn giao thiết bị");
                // lr7.Cells[0].CellStyle = row9;

                // //dòng 8
                // var lr8 = excelSheet.CreateRow(countdata + 7);
                // var lcra8 = new CellRangeAddress(countdata + 7, countdata + 7, 1, 11);
                // excelSheet.AddMergedRegion(lcra8);
                // lr8.CreateCell(1, CellType.String).SetCellValue("Thanh toán bằng tiền mặt hoặc chuyển khoản");
                // lr8.Cells[0].CellStyle = row9;

                // //dòng 9
                // var lr9 = excelSheet.CreateRow(countdata + 8);
                // var lcra9 = new CellRangeAddress(countdata + 8, countdata + 8, 1, 11);
                // excelSheet.AddMergedRegion(lcra9);
                // lr9.CreateCell(1, CellType.String).SetCellValue("Giá trị thanh toán được tính dựa trên thực tế thiết bị vật tư được hai bên xác nhận trong biên bản bàn giao, nghiệm thu");
                // lr9.Cells[0].CellStyle = row9;
            }
        }

        public static byte[] Excel_SALES_Weekly_V1(List<ReportModel_Sales_Department> data, string fromdate, string todate)
        {
            //
            using (var ms = new MemoryStream())
            {
                //
                IWorkbook workbook;
                workbook = new XSSFWorkbook();

                ISheet excelSheet_TAB1 = workbook.CreateSheet("Hoạt động");

                excelSheet_TAB1.CreateFreezePane(0, 3);

                //
                //
                var titleStyle = workbook.CreateCellStyle();
                titleStyle.Alignment = HorizontalAlignment.Center;
                titleStyle.VerticalAlignment = VerticalAlignment.Center;

                var fontTitle = workbook.CreateFont();
                fontTitle.FontHeightInPoints = 18;
                fontTitle.IsBold = true;

                titleStyle.SetFont(fontTitle);

                //
                var headerStyle = workbook.CreateCellStyle();

                var fontHeader = workbook.CreateFont();
                fontHeader.FontHeightInPoints = 14;
                fontHeader.IsBold = true;

                headerStyle.SetFont(fontHeader);

                //
                var accountStyle = workbook.CreateCellStyle();
                accountStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.LightGreen.Index;
                accountStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LightGreen.Index;
                accountStyle.FillPattern = FillPattern.SolidForeground;
                accountStyle.Alignment = HorizontalAlignment.Center;
                accountStyle.VerticalAlignment = VerticalAlignment.Center;

                var fontAccount = workbook.CreateFont();
                fontAccount.FontHeightInPoints = 14;
                fontAccount.IsBold = true;

                accountStyle.SetFont(fontAccount);

                //
                var merTitle = new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 10);
                excelSheet_TAB1.AddMergedRegion(merTitle);
                //
                var merDate = new NPOI.SS.Util.CellRangeAddress(1, 1, 0, 10);
                excelSheet_TAB1.AddMergedRegion(merDate);

                //
                var titleReport = excelSheet_TAB1.CreateRow(0);

                var titleRow = titleReport.CreateCell(0);
                titleRow.SetCellValue("TỔNG HỢP CÁC DỰ ÁN ĐANG THEO DÕI VÀ TRIỂN KHAI");
                titleRow.CellStyle = titleStyle;

                //
                var dateReport = excelSheet_TAB1.CreateRow(1);

                var dateRow = dateReport.CreateCell(0);
                dateRow.SetCellValue(string.Format("TỪ {0} ĐẾN {1}", fromdate, todate));
                dateRow.CellStyle = titleStyle;

                //
                var headerList = new List<string>();
                headerList.Add("Ngày tiếp nhận");
                headerList.Add("Deadline");
                headerList.Add("Dự án");
                headerList.Add("Tên công ty");
                headerList.Add("Người liên hệ");
                headerList.Add("Nội dung th");
                headerList.Add("Trạng thái cv");
                headerList.Add("Giá trị");
                headerList.Add("Lý do thắng/bại");
                headerList.Add("Chi phí % KH");
                headerList.Add("Ghi chú");

                var headerReport = excelSheet_TAB1.CreateRow(2);

                for (int i = 0; i <= 10; i++)
                {
                    var headerReport_R = headerReport.CreateCell(i);
                    headerReport_R.SetCellValue(headerList[i]);
                    headerReport_R.CellStyle = headerStyle;
                }

                //border
                SetBorderRange(2, 0, 10, excelSheet_TAB1, workbook);

                //Chỉ độ rộng
                for (int i = 0; i <= 10; i++)
                {
                    excelSheet_TAB1.SetColumnWidth(i, 5000);
                }

                // for (int i = 2; i <= 10; i++)
                // {
                //     excelSheet_TAB1.SetColumnWidth(i, 10000);
                // }

                var row = 3;

                //Dữ liệu chính
                foreach (var item in data)
                {
                    //dữ liệu người dùng
                    var rowAccount = excelSheet_TAB1.CreateRow(row);

                    //SetBorderRange(row, 2, 10, excelSheet_TAB1, workbook);

                    var cellAccount = rowAccount.CreateCell(0);
                    cellAccount.SetCellValue(item.AccountName);
                    cellAccount.CellStyle = accountStyle;

                    for (int i = 1; i <= 10; i++)
                    {
                        rowAccount.CreateCell(i).SetCellValue("");
                    }

                    SetBorderRange(row, 0, 10, excelSheet_TAB1, workbook);



                    var merAccount = new NPOI.SS.Util.CellRangeAddress(row, row, 0, 1);
                    excelSheet_TAB1.AddMergedRegion(merAccount);

                    //dữ liệu project
                    row++;

                    foreach (var itemP in item.Details)
                    {
                        var rowProject = excelSheet_TAB1.CreateRow(row);
                        rowProject.CreateCell(0).SetCellValue(itemP.DateCreated.ToString("dd/MM/yyyy HH:mm"));
                        rowProject.CreateCell(1).SetCellValue(itemP.DateEnd.ToString("dd/MM/yyyy HH:mm"));

                        var titleCell = rowProject.CreateCell(2);
                        titleCell.SetCellValue(itemP.Title);
                        titleCell.CellStyle.WrapText = true;

                        rowProject.CreateCell(3).SetCellValue(itemP.SALES_EnterpriseName);
                        rowProject.CreateCell(4).SetCellValue(itemP.SALES_ContactName);

                        //
                        var k = itemP.SALES_ProjectTypeNames.Where(n => n.AccountId == item.AccountId).Select(n => n.Title);
                        var g = string.Join(',', k);
                        rowProject.CreateCell(5).SetCellValue(g);

                        rowProject.CreateCell(6).SetCellValue(itemP.SALES_ProjectStatusName);
                        rowProject.CreateCell(7).SetCellValue(itemP.SALES_EstimateValue.ToString("###,###"));
                        rowProject.CreateCell(8).SetCellValue(itemP.Reason);
                        rowProject.CreateCell(9).SetCellValue(itemP.SALES_CustomerPercentBack.ToString("###,###"));
                        rowProject.CreateCell(10).SetCellValue(itemP.Note);

                        SetBorderRange(row, 0, 10, excelSheet_TAB1, workbook);

                        row++;
                    }
                }

                //
                workbook.Write(ms);

                return ms.ToArray();
            }
        }

        public static byte[] Excel_WORK_Weekly_V1(List<ReportModel_WORK_Project_Detail> data, string fromdate, string todate)
        {
            //
            using (var ms = new MemoryStream())
            {
                //
                IWorkbook workbook;
                workbook = new XSSFWorkbook();

                ISheet excelSheet_TAB1 = workbook.CreateSheet("Hoạt động");

                excelSheet_TAB1.CreateFreezePane(0, 3);

                //
                var titleStyle = workbook.CreateCellStyle();
                titleStyle.Alignment = HorizontalAlignment.Center;
                titleStyle.VerticalAlignment = VerticalAlignment.Center;

                var fontTitle = workbook.CreateFont();
                fontTitle.FontHeightInPoints = 18;
                fontTitle.IsBold = true;

                titleStyle.SetFont(fontTitle);

                //
                var headerStyle = workbook.CreateCellStyle();

                var fontHeader = workbook.CreateFont();
                fontHeader.FontHeightInPoints = 14;
                fontHeader.IsBold = true;

                headerStyle.SetFont(fontHeader);

                //
                var accountStyle = workbook.CreateCellStyle();
                accountStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.LightGreen.Index;
                accountStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LightGreen.Index;
                accountStyle.FillPattern = FillPattern.SolidForeground;
                accountStyle.Alignment = HorizontalAlignment.Center;
                accountStyle.VerticalAlignment = VerticalAlignment.Center;

                //
                var taskStyle = workbook.CreateCellStyle();
                taskStyle.WrapText = true;

                var fontAccount = workbook.CreateFont();
                fontAccount.FontHeightInPoints = 14;
                fontAccount.IsBold = true;

                accountStyle.SetFont(fontAccount);

                //
                var merTitle = new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 5);
                excelSheet_TAB1.AddMergedRegion(merTitle);
                //
                var merDate = new NPOI.SS.Util.CellRangeAddress(1, 1, 0, 5);
                excelSheet_TAB1.AddMergedRegion(merDate);

                //
                var titleReport = excelSheet_TAB1.CreateRow(0);

                var titleRow = titleReport.CreateCell(0);
                titleRow.SetCellValue("BÁO CÁO TUẦN");
                titleRow.CellStyle = titleStyle;

                //
                var dateReport = excelSheet_TAB1.CreateRow(1);

                var dateRow = dateReport.CreateCell(0);
                dateRow.SetCellValue(string.Format("TỪ {0} ĐẾN {1}", fromdate, todate));
                dateRow.CellStyle = titleStyle;

                //
                var headerList = new List<string>();
                headerList.Add("Ngày tạo");
                headerList.Add("Hạn");
                //headerList.Add("Việc cần làm");
                headerList.Add("Việc đang làm");
                headerList.Add("Việc hoàn thành");
                headerList.Add("Việc hủy bỏ");

                var headerReport = excelSheet_TAB1.CreateRow(2);

                for (int i = 0; i <= 5; i++)
                {
                    var headerReport_R = headerReport.CreateCell(i);
                    headerReport_R.SetCellValue(headerList[i]);
                    headerReport_R.CellStyle = headerStyle;
                }

                //border
                SetBorderRange(2, 0, 5, excelSheet_TAB1, workbook);

                //Chỉ độ rộng
                for (int i = 0; i <= 5; i++)
                {
                    excelSheet_TAB1.SetColumnWidth(i, 5000);
                }

                // for (int i = 2; i <= 10; i++)
                // {
                //     excelSheet_TAB1.SetColumnWidth(i, 10000);
                // }

                var row = 3;

                //Dữ liệu chính
                foreach (var item in data)
                {
                    //dữ liệu người dùng
                    var rowAccount = excelSheet_TAB1.CreateRow(row);

                    //SetBorderRange(row, 2, 10, excelSheet_TAB1, workbook);

                    var cellAccount = rowAccount.CreateCell(0);
                    cellAccount.SetCellValue("Dự án: " + item.Title);
                    cellAccount.CellStyle = accountStyle;

                    for (int i = 1; i <= 5; i++)
                    {
                        rowAccount.CreateCell(i).SetCellValue("");
                    }

                    SetBorderRange(row, 0, 5, excelSheet_TAB1, workbook);

                    var merAccount = new NPOI.SS.Util.CellRangeAddress(row, row, 0, 1);
                    excelSheet_TAB1.AddMergedRegion(merAccount);

                    //dữ liệu project
                    row++;

                    var rowProject = excelSheet_TAB1.CreateRow(row);

                    rowProject.CreateCell(0).SetCellValue(item.DateStart.ToString("dd/MM/yyyy HH:mm"));
                    rowProject.CreateCell(1).SetCellValue(item.DateEnd.ToString("dd/MM/yyyy HH:mm"));

                    var il = 2;
                    foreach (var itemS in item.Stages)
                    {
                        var cellTask = rowProject.CreateCell(il);
                        cellTask.SetCellValue(string.Join(", ", itemS.Tasks.Select(n => n.Title)));
                        cellTask.CellStyle = taskStyle;
                        il++;
                    }

                    SetBorderRange(row, 0, 5, excelSheet_TAB1, workbook);

                    row++;
                }

                //
                workbook.Write(ms);

                return ms.ToArray();
            }
        }

        public static byte[] Excel_CommonData(TableModel model, string title = "")
        {
            //
            using (var ms = new MemoryStream())
            {
                //
                var displays = model.Displays.Where(n => n.IsDisplay).ToList();

                //
                IWorkbook workbook;
                workbook = new XSSFWorkbook();

                ISheet excelSheet_TAB1 = workbook.CreateSheet("Hoạt động");

                excelSheet_TAB1.CreateFreezePane(0, 3);

                //
                var titleStyle = workbook.CreateCellStyle();
                titleStyle.Alignment = HorizontalAlignment.Center;
                titleStyle.VerticalAlignment = VerticalAlignment.Center;

                var fontTitle = workbook.CreateFont();
                fontTitle.FontHeightInPoints = 18;
                fontTitle.IsBold = true;

                titleStyle.SetFont(fontTitle);

                //
                var headerStyle = workbook.CreateCellStyle();

                var fontHeader = workbook.CreateFont();
                fontHeader.FontHeightInPoints = 14;
                fontHeader.IsBold = true;

                headerStyle.SetFont(fontHeader);

                //
                var accountStyle = workbook.CreateCellStyle();
                accountStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.LightGreen.Index;
                accountStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LightGreen.Index;
                accountStyle.FillPattern = FillPattern.SolidForeground;
                accountStyle.Alignment = HorizontalAlignment.Center;
                accountStyle.VerticalAlignment = VerticalAlignment.Center;

                var fontAccount = workbook.CreateFont();
                fontAccount.FontHeightInPoints = 14;
                fontAccount.IsBold = true;

                accountStyle.SetFont(fontAccount);

                //
                var merTitle = new NPOI.SS.Util.CellRangeAddress(0, 0, 0, displays.Count);
                excelSheet_TAB1.AddMergedRegion(merTitle);

                //
                var titleReport = excelSheet_TAB1.CreateRow(0);

                var titleRow = titleReport.CreateCell(0);
                titleRow.SetCellValue(title);
                titleRow.CellStyle = titleStyle;

                ICellStyle cellDateStyle = workbook.CreateCellStyle();
                cellDateStyle.DataFormat = workbook.CreateDataFormat().GetFormat("#,###");

                ////
                //var dateReport = excelSheet_TAB1.CreateRow(1);

                //var dateRow = dateReport.CreateCell(0);
                //dateRow.SetCellValue(string.Format("TỪ {0} ĐẾN {1}", fromdate, todate));
                //dateRow.CellStyle = titleStyle;

                var headerList = new List<string>();
                foreach (var item in displays)
                {
                    headerList.Add(item.DisplayName);
                }

                var headerReport = excelSheet_TAB1.CreateRow(1);

                for (int i = 0; i < headerList.Count; i++)
                {
                    var headerReport_R = headerReport.CreateCell(i);
                    headerReport_R.SetCellValue(headerList[i]);
                    headerReport_R.CellStyle = headerStyle;
                }

                //border
                SetBorderRange(1, 0, headerList.Count, excelSheet_TAB1, workbook);

                //Chỉ độ rộng
                for (int i = 0; i < headerList.Count; i++)
                {
                    excelSheet_TAB1.SetColumnWidth(i, 5000);
                }

                // for (int i = 2; i <= 10; i++)
                // {
                //     excelSheet_TAB1.SetColumnWidth(i, 10000);
                // }

                var row = 2;

                //Dữ liệu chính
                foreach (DataRow item in model.Content.Rows)
                {
                    //dữ liệu người dùng
                    var rowContract = excelSheet_TAB1.CreateRow(row);

                    for (int i = 0; i < displays.Count(); i++)
                    {
                        var columnValue = item.Table.Columns[displays[i].FieldName];

                        if (Type.GetTypeCode(columnValue.DataType) == TypeCode.Decimal)
                        {
                            var cell = rowContract.CreateCell(i, CellType.Numeric);
                            cell.SetCellValue(Convert.ToDouble(item[displays[i].FieldName].ToString()));
                            cell.CellStyle = cellDateStyle;
                        }
                        else
                        {
                            rowContract.CreateCell(i, CellType.String).SetCellValue(item[displays[i].FieldName].ToString());
                        }

                    }

                    row++;
                }

                //
                workbook.Write(ms);

                return ms.ToArray();
            }
        }


        public static byte[] Excel_ContractFormat(string format, string filename, InvoiceExcelPrintModel data, HttpContext context)
        {
            switch (format)
            {
                case "1":
                    return Excel_Contract_V1(filename, data, context);

                case "2":
                    return Excel_Contract_V2(filename, data, context);

                default:
                    return Excel_Contract_V1(filename, data, context);
            }
        }

        /// <summary>
        /// mẫu có nhân công
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static byte[] Excel_Contract_V1(string filename, InvoiceExcelPrintModel data, HttpContext context)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    IWorkbook workbook;
                    workbook = new XSSFWorkbook();
                    ISheet excelSheet = workbook.CreateSheet("Sheet1");

                    #region Set style cho cell

                    #region row 2
                    //tạo style
                    var row2 = workbook.CreateCellStyle();
                    //row2.CloneStyleFrom(cellStyleBorder);
                    //row2.FillPattern = FillPattern.SolidForeground;

                    //tạo font cho row
                    var font2 = workbook.CreateFont();
                    font2.FontName = "Times New Roman";
                    font2.IsItalic = true; //chữ nghiêng
                    row2.SetFont(font2);
                    #endregion

                    #region row 3
                    var row3 = workbook.CreateCellStyle();
                    var font3 = workbook.CreateFont();
                    font3.IsBold = true;//chữ in đậm
                    font3.FontName = "Times New Roman";
                    font3.FontHeightInPoints = 14;  //font size                
                    row3.SetFont(font3);
                    row3.Alignment = HorizontalAlignment.Center;   //căn giữa
                    row3.VerticalAlignment = VerticalAlignment.Center;  //căn giữa
                    #endregion

                    #region row 4,5,6
                    var row4 = workbook.CreateCellStyle();
                    var font4 = workbook.CreateFont();
                    font4.IsBold = true;
                    font4.FontName = "Times New Roman";
                    font4.FontHeightInPoints = 11;
                    row4.SetFont(font4);
                    #endregion

                    #region row 8
                    //style cell 1
                    var row8_1 = workbook.CreateCellStyle();
                    var font8_1 = workbook.CreateFont();
                    font8_1.IsBold = true;
                    font8_1.Underline = FontUnderlineType.Single;
                    font8_1.FontName = "Times New Roman";
                    font8_1.FontHeightInPoints = 11;
                    row8_1.SetFont(font8_1);
                    row8_1.Alignment = HorizontalAlignment.Left;
                    row8_1.VerticalAlignment = VerticalAlignment.Center;

                    //style cell 2
                    var row8_2 = workbook.CreateCellStyle();
                    var font8_2 = workbook.CreateFont();
                    font8_2.IsBold = true;
                    font8_2.FontName = "Times New Roman";
                    font8_2.FontHeightInPoints = 11;
                    row8_2.SetFont(font8_2);
                    row8_2.Alignment = HorizontalAlignment.Left;
                    row8_2.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row 9 -> 13
                    var row9 = workbook.CreateCellStyle();
                    var font9 = workbook.CreateFont();
                    font9.FontName = "Times New Roman";
                    font9.FontHeightInPoints = 11;
                    row9.SetFont(font9);
                    row9.Alignment = HorizontalAlignment.Left;
                    row9.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row 15,16
                    var row15 = workbook.CreateCellStyle();
                    var font15 = workbook.CreateFont();
                    font15.FontName = "Times New Roman";
                    font15.FontHeightInPoints = 11;
                    font15.IsBold = true;
                    row15.SetFont(font15);
                    row15.Alignment = HorizontalAlignment.Center;
                    row15.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row cuối
                    var lastrow = workbook.CreateCellStyle();
                    var lfont = workbook.CreateFont();
                    lfont.FontName = "Times New Roman";
                    lfont.FontHeightInPoints = 11;
                    lfont.IsBold = true;
                    lastrow.SetFont(lfont);
                    lastrow.Alignment = HorizontalAlignment.Center;
                    lastrow.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row Summary
                    var rowSummary = workbook.CreateCellStyle();
                    var fontSummary = workbook.CreateFont();
                    fontSummary.IsBold = true;//chữ in đậm
                    fontSummary.FontName = "Times New Roman";
                    fontSummary.FontHeightInPoints = 12;  //font size                
                    rowSummary.SetFont(fontSummary);
                    rowSummary.Alignment = HorizontalAlignment.Center;   //căn giữa
                    rowSummary.VerticalAlignment = VerticalAlignment.Center;  //căn giữa
                    #endregion

                    #endregion

                    #region dữ liệu header

                    #region dòng 1
                    //tạo row
                    var r1 = excelSheet.CreateRow(0);

                    //merge cell
                    var cra = new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 11);
                    excelSheet.AddMergedRegion(cra);
                    r1.CreateCell(0).SetCellValue("BẢNG KHỐI LƯỢNG VÀ GIÁ TRỊ BỔ SUNG");
                    r1.GetCell(0).CellStyle = rowSummary;

                    #endregion

                    #region dòng 2
                    var r2 = excelSheet.CreateRow(1);
                    var cra2 = new NPOI.SS.Util.CellRangeAddress(1, 1, 0, 11);
                    excelSheet.AddMergedRegion(cra2);
                    var time = DateTime.Now;
                    r2.CreateCell(0).SetCellValue(string.Format("Đính kèm Phụ lục hợp đồng số {0} ngày {1} tháng {2} năm {3}.", data.Code, time.Day, time.Month, time.Year));
                    r2.GetCell(0).CellStyle = rowSummary;
                    #endregion

                    #region dòng 15, 16
                    var r15 = excelSheet.CreateRow(2);
                    var r16 = excelSheet.CreateRow(3);

                    #region merge cell

                    //merge cell 0
                    var cra15_0 = new NPOI.SS.Util.CellRangeAddress(2, 3, 0, 0);
                    excelSheet.AddMergedRegion(cra15_0);

                    //merge cell 1
                    var cra15_1 = new NPOI.SS.Util.CellRangeAddress(2, 3, 1, 1);
                    excelSheet.AddMergedRegion(cra15_1);

                    //merge cell 2
                    var cra15_2 = new NPOI.SS.Util.CellRangeAddress(2, 3, 2, 2);
                    excelSheet.AddMergedRegion(cra15_2);

                    //merge cell 3
                    var cra15_3 = new NPOI.SS.Util.CellRangeAddress(2, 3, 3, 3);
                    excelSheet.AddMergedRegion(cra15_3);

                    //merge cell 4
                    var cra15_4 = new NPOI.SS.Util.CellRangeAddress(2, 3, 4, 4);
                    excelSheet.AddMergedRegion(cra15_4);

                    //merge cell 5
                    var cra15_5 = new NPOI.SS.Util.CellRangeAddress(2, 3, 5, 5);
                    excelSheet.AddMergedRegion(cra15_5);

                    //merge cell 6
                    var cra15_6 = new NPOI.SS.Util.CellRangeAddress(2, 3, 6, 6);
                    excelSheet.AddMergedRegion(cra15_6);

                    //merge cell 7, 8
                    var cra15_7 = new NPOI.SS.Util.CellRangeAddress(2, 3, 7, 8);
                    excelSheet.AddMergedRegion(cra15_7);

                    //merge cell 9, 10
                    var cra15_9 = new NPOI.SS.Util.CellRangeAddress(2, 3, 9, 10);
                    excelSheet.AddMergedRegion(cra15_9);

                    //merge cell 11
                    var cra15_11 = new NPOI.SS.Util.CellRangeAddress(2, 3, 11, 11);
                    excelSheet.AddMergedRegion(cra15_11);

                    //tạo range row 16 để add border
                    var cra16_0 = new NPOI.SS.Util.CellRangeAddress(2, 2, 7, 7);
                    var cra16_1 = new NPOI.SS.Util.CellRangeAddress(2, 2, 8, 8);
                    var cra16_2 = new NPOI.SS.Util.CellRangeAddress(2, 2, 9, 9);
                    var cra16_3 = new NPOI.SS.Util.CellRangeAddress(2, 2, 10, 10);

                    #endregion

                    #region autosizecolumn
                    excelSheet.SetColumnWidth(0, 1200);
                    excelSheet.SetColumnWidth(1, 15000);
                    excelSheet.SetColumnWidth(2, 3200);
                    excelSheet.SetColumnWidth(3, 2800);
                    excelSheet.SetColumnWidth(4, 2600);
                    excelSheet.SetColumnWidth(5, 2100);
                    excelSheet.SetColumnWidth(6, 2000);
                    excelSheet.SetColumnWidth(7, 3300);
                    excelSheet.SetColumnWidth(8, 3300);
                    excelSheet.SetColumnWidth(9, 3300);
                    excelSheet.SetColumnWidth(10, 3300);
                    excelSheet.SetColumnWidth(11, 3600);
                    #endregion

                    #region Thêm dữ liệu
                    r15.CreateCell(0, CellType.String).SetCellValue("STT");
                    r15.Cells[0].CellStyle = row15;
                    r15.Cells[0].CellStyle.WrapText = true;

                    r15.CreateCell(1, CellType.String).SetCellValue("Nội dung công việc");
                    r15.Cells[1].CellStyle = row15;
                    r15.Cells[1].CellStyle.WrapText = true;

                    r15.CreateCell(2, CellType.String).SetCellValue("Mã hiệu");
                    r15.Cells[2].CellStyle = row15;
                    r15.Cells[2].CellStyle.WrapText = true;

                    r15.CreateCell(3, CellType.String).SetCellValue("Hãng sản xuất");
                    r15.Cells[3].CellStyle = row15;
                    r15.Cells[3].CellStyle.WrapText = true;

                    r15.CreateCell(4, CellType.String).SetCellValue("Xuất xứ");
                    r15.Cells[4].CellStyle = row15;
                    r15.Cells[4].CellStyle.WrapText = true;

                    r15.CreateCell(5, CellType.String).SetCellValue("Đơn vị");
                    r15.Cells[5].CellStyle = row15;
                    r15.Cells[5].CellStyle.WrapText = true;

                    r15.CreateCell(6, CellType.String).SetCellValue("Khối lượng");
                    r15.Cells[6].CellStyle = row15;
                    r15.Cells[6].CellStyle.WrapText = true;

                    r15.CreateCell(7, CellType.String).SetCellValue("Đơn giá (VNĐ)");
                    r15.Cells[7].CellStyle = row15;

                    r15.CreateCell(9, CellType.String).SetCellValue("Thành tiền (VNĐ)");
                    r15.Cells[8].CellStyle = row15;

                    r15.CreateCell(11, CellType.String).SetCellValue("Tổng cộng (VNĐ)");
                    r15.Cells[9].CellStyle = row15;
                    r15.Cells[9].CellStyle.WrapText = true;

                    r16.CreateCell(7, CellType.String).SetCellValue("Vật liệu");
                    r16.Cells[0].CellStyle = row15;

                    r16.CreateCell(8, CellType.String).SetCellValue("Nhân công");
                    r16.Cells[1].CellStyle = row15;

                    r16.CreateCell(9, CellType.String).SetCellValue("Vật liệu");
                    r16.Cells[2].CellStyle = row15;

                    r16.CreateCell(10, CellType.String).SetCellValue("Nhân công");
                    r16.Cells[3].CellStyle = row15;

                    #endregion

                    #region set border
                    SetBorder(cra15_0, excelSheet, workbook);
                    SetBorder(cra15_1, excelSheet, workbook);
                    SetBorder(cra15_2, excelSheet, workbook);
                    SetBorder(cra15_3, excelSheet, workbook);
                    SetBorder(cra15_4, excelSheet, workbook);
                    SetBorder(cra15_5, excelSheet, workbook);
                    SetBorder(cra15_6, excelSheet, workbook);
                    SetBorder(cra15_7, excelSheet, workbook);
                    SetBorder(cra15_9, excelSheet, workbook);
                    SetBorder(cra15_11, excelSheet, workbook);
                    SetBorder(cra16_0, excelSheet, workbook);
                    SetBorder(cra16_1, excelSheet, workbook);
                    SetBorder(cra16_2, excelSheet, workbook);
                    SetBorder(cra16_3, excelSheet, workbook);
                    #endregion



                    #endregion


                    #endregion

                    #region dữ liệu chính
                    int countdata = 4; //Dữ liệu bắt đầu từ

                    #region Data chính

                    if (data.Groups.Any())
                    {
                        var grs = data.Groups.OrderBy(n => n.SortOrder).ToList();

                        foreach (var item in grs)
                        {
                            var products = data.Details.Where(n => n.GroupId == item.Id).ToList();

                            //Tạo dòng cho groups
                            var lrMain = excelSheet.CreateRow(countdata);
                            lrMain.CreateCell(0).SetCellValue(FunctionHelper.ToRomanNumeral(item.SortOrder));

                            SetBorderRange(countdata, 0, 11, excelSheet, workbook);

                            var cra_G = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 1, 11);
                            excelSheet.AddMergedRegion(cra_G);

                            lrMain.CreateCell(1).SetCellValue(item.Title);

                            countdata++;
                            var count = 1;

                            foreach (var itemP in products)
                            {
                                RenderProductList_V1(countdata, excelSheet, workbook, itemP, count);

                                countdata++;
                                count++;
                            }
                        }
                    }
                    else
                    {
                        var count = 1;
                        foreach (var item in data.Details)
                        {
                            RenderProductList_V1(countdata, excelSheet, workbook, item, count);

                            countdata++;
                            count++;
                        }
                    }

                    #endregion

                    #region Phần tổng kết
                    var sumProduct = data.Details.Sum(n => n.Price * n.Quantity);
                    var sumLaborProduct = data.Details.Sum(n => n.LaborPrice * n.Quantity);

                    //Phần tổng kết
                    var lrSummary1 = excelSheet.CreateRow(countdata);

                    lrSummary1.CreateCell(0).SetCellValue("");

                    var craSummary1 = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 1, 8);
                    excelSheet.AddMergedRegion(craSummary1);

                    lrSummary1.CreateCell(1).SetCellValue("TỔNG CỘNG TRƯỚC THUẾ");
                    lrSummary1.CreateCell(9).SetCellValue(sumProduct.ToString("###,###.##"));
                    lrSummary1.CreateCell(10).SetCellValue(sumLaborProduct.ToString("###,###.##"));
                    lrSummary1.CreateCell(11).SetCellValue(data.Details.Sum(n => n.Total).ToString("###,###.##"));

                    lrSummary1.GetCell(1).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 11, excelSheet, workbook);

                    //
                    countdata = countdata + 1;

                    var lrSummaryAmount = excelSheet.CreateRow(countdata);

                    lrSummaryAmount.CreateCell(0).SetCellValue("");

                    var craSummaryAmount = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 1, 8);
                    excelSheet.AddMergedRegion(craSummaryAmount);

                    lrSummaryAmount.CreateCell(1).SetCellValue("TỔNG GIÁ");
                    lrSummaryAmount.CreateCell(9).SetCellValue("");
                    lrSummaryAmount.CreateCell(10).SetCellValue("");
                    lrSummaryAmount.CreateCell(11).SetCellValue(data.Amount.ToString("###,###.##"));

                    lrSummaryAmount.GetCell(1).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 11, excelSheet, workbook);

                    //
                    countdata = countdata + 1;

                    var VATProduct = data.Details.Where(n => n.IsSoftware == false).Sum(n => n.Price * n.Quantity) * Convert.ToDecimal(data.TaxRate / 100);
                    var VATLaborProduct = sumLaborProduct * Convert.ToDecimal(data.TaxRate / 100);

                    var lrSummary2 = excelSheet.CreateRow(countdata);

                    lrSummary2.CreateCell(0).SetCellValue("");

                    var craSummary2 = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 1, 8);
                    excelSheet.AddMergedRegion(craSummary2);

                    lrSummary2.CreateCell(1).SetCellValue(string.Format("VAT {0}% (Phần mềm VAT 0%)", data.TaxRate));
                    lrSummary2.CreateCell(9).SetCellValue(VATProduct.ToString("###,###.##"));
                    lrSummary2.CreateCell(10).SetCellValue(VATLaborProduct.ToString("###,###.##"));
                    lrSummary2.CreateCell(11).SetCellValue(data.Tax.ToString("###,###.##"));

                    lrSummary2.GetCell(1).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 11, excelSheet, workbook);

                    //
                    countdata = countdata + 1;

                    var totalProduct = VATProduct + data.Details.Where(n => n.IsSoftware == false).Sum(n => n.Price * n.Quantity);
                    var totalLaborProduct = VATLaborProduct + sumLaborProduct;

                    var lrSummary3 = excelSheet.CreateRow(countdata);

                    lrSummary3.CreateCell(0).SetCellValue("");

                    var craSummary3 = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 1, 8);
                    excelSheet.AddMergedRegion(craSummary3);

                    lrSummary3.CreateCell(1).SetCellValue("TỔNG SAU THUẾ");
                    lrSummary3.CreateCell(9).SetCellValue(totalProduct.ToString("###,###.##"));
                    lrSummary3.CreateCell(10).SetCellValue(totalLaborProduct.ToString("###,###.##"));
                    lrSummary3.CreateCell(11).SetCellValue(data.Total.ToString("###,###.##"));

                    SetBorderRange(countdata, 0, 11, excelSheet, workbook);

                    lrSummary3.GetCell(1).CellStyle = rowSummary;

                    //
                    countdata = countdata + 1;

                    var lrSummary4 = excelSheet.CreateRow(countdata);

                    lrSummary4.CreateCell(0).SetCellValue("");

                    var craSummary4 = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 1, 11);
                    excelSheet.AddMergedRegion(craSummary4);

                    lrSummary4.CreateCell(1).SetCellValue(string.Format("Bằng chữ: {0}", FunctionHelper.DocTienBangChu(Convert.ToInt64(data.Total), " đồng")));

                    lrSummary4.GetCell(1).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 11, excelSheet, workbook);

                    #endregion

                    #endregion

                    #region phần cuối
                    countdata = countdata + 1;

                    //dòng 10
                    var lr10 = excelSheet.CreateRow(countdata + 5);

                    var lcra10_1 = new CellRangeAddress(countdata + 10, countdata + 10, 1, 3);
                    excelSheet.AddMergedRegion(lcra10_1);

                    var lcra10_2 = new CellRangeAddress(countdata + 10, countdata + 10, 7, 10);
                    excelSheet.AddMergedRegion(lcra10_2);

                    lr10.CreateCell(1, CellType.String).SetCellValue("XÁC NHẬN CỦA KHÁCH HÀNG");
                    lr10.Cells[0].CellStyle = lastrow;

                    lr10.CreateCell(7, CellType.String).SetCellValue("T/M CÔNG TY CỔ PHẦN CÔNG NGHỆ FUTECH");
                    lr10.Cells[1].CellStyle = lastrow;
                    #endregion

                    workbook.Write(ms);

                    //Excel_Execute(context, ms.ToArray(), filename);

                    return ms.ToArray();
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }


        }

        /// <summary>
        /// mẫu không có nhân công
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static byte[] Excel_Contract_V2(string filename, InvoiceExcelPrintModel data, HttpContext context)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    IWorkbook workbook;
                    workbook = new XSSFWorkbook();
                    ISheet excelSheet = workbook.CreateSheet("Sheet1");

                    #region Set style cho cell

                    #region row 3
                    //tạo style
                    var row3 = workbook.CreateCellStyle();

                    //tạo font cho row
                    var font3 = workbook.CreateFont();
                    font3.FontName = "Times New Roman";
                    font3.IsItalic = true; //chữ nghiêng
                    font3.FontHeightInPoints = 12;
                    row3.Alignment = HorizontalAlignment.Right;   //căn phải
                    row3.VerticalAlignment = VerticalAlignment.Center;  //căn giữa
                    row3.SetFont(font3);
                    #endregion

                    #region row 4
                    //style cell 1
                    var row4_1 = workbook.CreateCellStyle();
                    var font4_1 = workbook.CreateFont();
                    font4_1.IsBold = true;
                    font4_1.Underline = FontUnderlineType.Single;
                    font4_1.FontName = "Times New Roman";
                    font4_1.FontHeightInPoints = 12;
                    row4_1.SetFont(font4_1);
                    row4_1.Alignment = HorizontalAlignment.Left;
                    row4_1.VerticalAlignment = VerticalAlignment.Center;
                    //style cell 2
                    var row4_2 = workbook.CreateCellStyle();
                    var font4_2 = workbook.CreateFont();
                    font4_2.IsBold = true;
                    font4_2.FontName = "Times New Roman";
                    font4_2.FontHeightInPoints = 12;
                    row4_2.SetFont(font4_2);
                    row4_2.Alignment = HorizontalAlignment.Left;
                    row4_2.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row 5 -> 9
                    var row5 = workbook.CreateCellStyle();
                    var font5 = workbook.CreateFont();
                    font5.FontName = "Times New Roman";
                    font5.FontHeightInPoints = 12;
                    row5.SetFont(font5);
                    row5.Alignment = HorizontalAlignment.Left;
                    row5.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row 10
                    var row10 = workbook.CreateCellStyle();
                    var font10 = workbook.CreateFont();
                    font10.IsBold = true;//chữ in đậm
                    font10.FontName = "Times New Roman";
                    font10.FontHeightInPoints = 16;  //font size                
                    row10.SetFont(font10);
                    row10.Alignment = HorizontalAlignment.Center;   //căn giữa
                    row10.VerticalAlignment = VerticalAlignment.Center;  //căn giữa
                    #endregion

                    #region row 11
                    //tạo style
                    var row11 = workbook.CreateCellStyle();

                    //tạo font cho row
                    var font11 = workbook.CreateFont();
                    font11.FontName = "Times New Roman";
                    font11.IsItalic = true; //chữ nghiêng
                    font11.IsBold = true;
                    font11.FontHeightInPoints = 12;
                    row11.Alignment = HorizontalAlignment.Right;   //căn phải
                    row11.VerticalAlignment = VerticalAlignment.Center;  //căn giữa
                    row11.SetFont(font11);
                    #endregion

                    #region row 12
                    var row12 = workbook.CreateCellStyle();
                    var font12 = workbook.CreateFont();
                    font12.FontName = "Times New Roman";
                    font12.FontHeightInPoints = 12;
                    font12.IsBold = true;
                    row12.SetFont(font12);
                    row12.Alignment = HorizontalAlignment.Center;
                    row12.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row 15,16
                    var row15 = workbook.CreateCellStyle();
                    var font15 = workbook.CreateFont();
                    font15.FontName = "Times New Roman";
                    font15.FontHeightInPoints = 11;
                    font15.IsBold = true;
                    row15.SetFont(font15);
                    row15.Alignment = HorizontalAlignment.Center;
                    row15.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row cuối
                    var lastrow = workbook.CreateCellStyle();
                    var lfont = workbook.CreateFont();
                    lfont.FontName = "Times New Roman";
                    lfont.FontHeightInPoints = 12;
                    lfont.IsBold = true;
                    lastrow.SetFont(lfont);
                    lastrow.Alignment = HorizontalAlignment.Center;
                    lastrow.VerticalAlignment = VerticalAlignment.Center;
                    #endregion

                    #region row Summary
                    var rowSummary = workbook.CreateCellStyle();
                    var fontSummary = workbook.CreateFont();
                    fontSummary.IsBold = true;//chữ in đậm
                    fontSummary.FontName = "Times New Roman";
                    fontSummary.FontHeightInPoints = 12;  //font size                
                    rowSummary.SetFont(fontSummary);
                    rowSummary.Alignment = HorizontalAlignment.Center;   //căn giữa
                    rowSummary.VerticalAlignment = VerticalAlignment.Center;  //căn giữa
                    #endregion

                    #endregion

                    #region dữ liệu header

                    #region dòng 1
                    //tạo row
                    var r1 = excelSheet.CreateRow(0);

                    //merge cell
                    var cra = new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 11);
                    excelSheet.AddMergedRegion(cra);
                    r1.CreateCell(0).SetCellValue("BẢNG KHỐI LƯỢNG VÀ GIÁ TRỊ BỔ SUNG");
                    r1.GetCell(0).CellStyle = rowSummary;

                    #endregion

                    #region dòng 2
                    var r2 = excelSheet.CreateRow(1);
                    var cra2 = new NPOI.SS.Util.CellRangeAddress(1, 1, 0, 11);
                    excelSheet.AddMergedRegion(cra2);
                    var time = DateTime.Now;
                    r2.CreateCell(0).SetCellValue(string.Format("Đính kèm Phụ lục hợp đồng số {0} ngày {1} tháng {2} năm {3}.", data.Code, time.Day, time.Month, time.Year));
                    r2.GetCell(0).CellStyle = rowSummary;
                    #endregion

                    #region dòng 15, 16
                    var r15 = excelSheet.CreateRow(2);
                    var r16 = excelSheet.CreateRow(3);

                    #region merge cell

                    //merge cell 0
                    var cra15_0 = new NPOI.SS.Util.CellRangeAddress(2, 3, 0, 0);
                    excelSheet.AddMergedRegion(cra15_0);

                    //merge cell 1
                    var cra15_1 = new NPOI.SS.Util.CellRangeAddress(2, 3, 1, 1);
                    excelSheet.AddMergedRegion(cra15_1);

                    //merge cell 2
                    var cra15_2 = new NPOI.SS.Util.CellRangeAddress(2, 3, 2, 2);
                    excelSheet.AddMergedRegion(cra15_2);

                    //merge cell 3
                    var cra15_3 = new NPOI.SS.Util.CellRangeAddress(2, 3, 3, 3);
                    excelSheet.AddMergedRegion(cra15_3);

                    //merge cell 4
                    var cra15_4 = new NPOI.SS.Util.CellRangeAddress(2, 3, 4, 4);
                    excelSheet.AddMergedRegion(cra15_4);

                    //merge cell 5
                    var cra15_5 = new NPOI.SS.Util.CellRangeAddress(2, 3, 5, 5);
                    excelSheet.AddMergedRegion(cra15_5);

                    //merge cell 6
                    var cra15_6 = new NPOI.SS.Util.CellRangeAddress(2, 3, 6, 6);
                    excelSheet.AddMergedRegion(cra15_6);

                    //merge cell 7, 8
                    var cra15_7 = new NPOI.SS.Util.CellRangeAddress(2, 3, 7, 8);
                    excelSheet.AddMergedRegion(cra15_7);

                    //merge cell 9, 10
                    var cra15_9 = new NPOI.SS.Util.CellRangeAddress(2, 3, 9, 10);
                    excelSheet.AddMergedRegion(cra15_9);

                    //merge cell 11
                    var cra15_11 = new NPOI.SS.Util.CellRangeAddress(2, 3, 11, 11);
                    excelSheet.AddMergedRegion(cra15_11);

                    //tạo range row 16 để add border
                    var cra16_0 = new NPOI.SS.Util.CellRangeAddress(2, 2, 7, 7);
                    var cra16_1 = new NPOI.SS.Util.CellRangeAddress(2, 2, 8, 8);
                    var cra16_2 = new NPOI.SS.Util.CellRangeAddress(2, 2, 9, 9);
                    var cra16_3 = new NPOI.SS.Util.CellRangeAddress(2, 2, 10, 10);

                    #endregion

                    #region autosizecolumn
                    excelSheet.SetColumnWidth(0, 1200);
                    excelSheet.SetColumnWidth(1, 15000);
                    excelSheet.SetColumnWidth(2, 3200);
                    excelSheet.SetColumnWidth(3, 2800);
                    excelSheet.SetColumnWidth(4, 2600);
                    excelSheet.SetColumnWidth(5, 2100);
                    excelSheet.SetColumnWidth(6, 2000);
                    excelSheet.SetColumnWidth(7, 3300);
                    excelSheet.SetColumnWidth(8, 3300);
                    excelSheet.SetColumnWidth(9, 3300);
                    excelSheet.SetColumnWidth(10, 3300);
                    excelSheet.SetColumnWidth(11, 3600);
                    #endregion

                    #region Thêm dữ liệu
                    r15.CreateCell(0, CellType.String).SetCellValue("STT");
                    r15.Cells[0].CellStyle = row15;
                    r15.Cells[0].CellStyle.WrapText = true;

                    r15.CreateCell(1, CellType.String).SetCellValue("Nội dung công việc");
                    r15.Cells[1].CellStyle = row15;
                    r15.Cells[1].CellStyle.WrapText = true;

                    r15.CreateCell(2, CellType.String).SetCellValue("Mã hiệu");
                    r15.Cells[2].CellStyle = row15;
                    r15.Cells[2].CellStyle.WrapText = true;

                    r15.CreateCell(3, CellType.String).SetCellValue("Hãng sản xuất");
                    r15.Cells[3].CellStyle = row15;
                    r15.Cells[3].CellStyle.WrapText = true;

                    r15.CreateCell(4, CellType.String).SetCellValue("Xuất xứ");
                    r15.Cells[4].CellStyle = row15;
                    r15.Cells[4].CellStyle.WrapText = true;

                    r15.CreateCell(5, CellType.String).SetCellValue("Đơn vị");
                    r15.Cells[5].CellStyle = row15;
                    r15.Cells[5].CellStyle.WrapText = true;

                    r15.CreateCell(6, CellType.String).SetCellValue("Khối lượng");
                    r15.Cells[6].CellStyle = row15;
                    r15.Cells[6].CellStyle.WrapText = true;

                    r15.CreateCell(7, CellType.String).SetCellValue("Đơn giá (VNĐ)");
                    r15.Cells[7].CellStyle = row15;

                    r15.CreateCell(9, CellType.String).SetCellValue("Thành tiền (VNĐ)");
                    r15.Cells[8].CellStyle = row15;

                    r15.CreateCell(11, CellType.String).SetCellValue("Tổng cộng (VNĐ)");
                    r15.Cells[9].CellStyle = row15;
                    r15.Cells[9].CellStyle.WrapText = true;

                    r16.CreateCell(7, CellType.String).SetCellValue("Vật liệu");
                    r16.Cells[0].CellStyle = row15;

                    r16.CreateCell(8, CellType.String).SetCellValue("Nhân công");
                    r16.Cells[1].CellStyle = row15;

                    r16.CreateCell(9, CellType.String).SetCellValue("Vật liệu");
                    r16.Cells[2].CellStyle = row15;

                    r16.CreateCell(10, CellType.String).SetCellValue("Nhân công");
                    r16.Cells[3].CellStyle = row15;

                    #endregion

                    #region set border
                    SetBorder(cra15_0, excelSheet, workbook);
                    SetBorder(cra15_1, excelSheet, workbook);
                    SetBorder(cra15_2, excelSheet, workbook);
                    SetBorder(cra15_3, excelSheet, workbook);
                    SetBorder(cra15_4, excelSheet, workbook);
                    SetBorder(cra15_5, excelSheet, workbook);
                    SetBorder(cra15_6, excelSheet, workbook);
                    SetBorder(cra15_7, excelSheet, workbook);
                    SetBorder(cra15_9, excelSheet, workbook);
                    SetBorder(cra15_11, excelSheet, workbook);
                    SetBorder(cra16_0, excelSheet, workbook);
                    SetBorder(cra16_1, excelSheet, workbook);
                    SetBorder(cra16_2, excelSheet, workbook);
                    SetBorder(cra16_3, excelSheet, workbook);
                    #endregion



                    #endregion


                    #endregion
                    #region dữ liệu chính
                    int countdata = 2;

                    #region Data chính

                    if (data.Groups.Any())
                    {
                        var grs = data.Groups.OrderBy(n => n.SortOrder).ToList();

                        foreach (var item in grs)
                        {
                            var products = data.Details.Where(n => n.GroupId == item.Id).ToList();

                            //Tạo dòng cho groups
                            var lrMain = excelSheet.CreateRow(countdata);
                            lrMain.CreateCell(0).SetCellValue(FunctionHelper.ToRomanNumeral(item.SortOrder));

                            SetBorderRange(countdata, 0, 11, excelSheet, workbook);

                            var cra_G = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 1, 11);
                            excelSheet.AddMergedRegion(cra_G);

                            lrMain.CreateCell(1).SetCellValue(item.Title);

                            countdata++;
                            var count = 1;

                            foreach (var itemP in products)
                            {
                                RenderProductList_V2(countdata, excelSheet, workbook, itemP, count);

                                countdata++;
                                count++;
                            }
                        }
                    }
                    else
                    {
                        var count = 1;
                        foreach (var item in data.Details)
                        {
                            RenderProductList_V2(countdata, excelSheet, workbook, item, count);

                            countdata++;
                            count++;
                        }
                    }

                    #endregion

                    #region Phần tổng kết
                    var sumProduct = data.Details.Sum(n => n.Price * n.Quantity);

                    //Phần tổng kết
                    var lrSummary1 = excelSheet.CreateRow(countdata);

                    var craSummary1 = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 0, 5);
                    excelSheet.AddMergedRegion(craSummary1);

                    lrSummary1.CreateCell(0).SetCellValue("TỔNG CỘNG TRƯỚC THUẾ");
                    lrSummary1.CreateCell(6).SetCellValue(sumProduct.ToString("###,###.##"));

                    lrSummary1.GetCell(0).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 6, excelSheet, workbook);

                    //
                    countdata = countdata + 1;

                    var lrSummaryDis = excelSheet.CreateRow(countdata);

                    decimal discountmoney = 0;

                    if (data.DiscountType == "1")
                    {
                        discountmoney = data.Amount * (data.Discount / 100);
                    }
                    else
                    {
                        discountmoney = data.Discount;
                    }

                    var craSummaryDis = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 0, 5);
                    excelSheet.AddMergedRegion(craSummaryDis);

                    lrSummaryDis.CreateCell(0).SetCellValue(string.Format("Giảm giá {1} {0}", data.DiscountType == "1" ? "%" : "VND", data.DiscountType == "1" ? data.Discount.ToString("0.#") : ""));
                    lrSummaryDis.CreateCell(6).SetCellValue(discountmoney.ToString("###,###.##"));

                    lrSummaryDis.GetCell(0).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 6, excelSheet, workbook);

                    //
                    countdata = countdata + 1;

                    var lrSummaryAmount = excelSheet.CreateRow(countdata);

                    var craSummaryAmount = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 0, 5);
                    excelSheet.AddMergedRegion(craSummaryAmount);

                    lrSummaryAmount.CreateCell(0).SetCellValue("TỔNG GIÁ");
                    lrSummaryAmount.CreateCell(6).SetCellValue(data.Amount.ToString("###,###.##"));

                    lrSummaryAmount.GetCell(0).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 6, excelSheet, workbook);

                    //
                    countdata = countdata + 1;

                    var VATProduct = data.Details.Where(n => n.IsSoftware == false).Sum(n => n.Price * n.Quantity) * Convert.ToDecimal(data.TaxRate / 100);

                    var lrSummary2 = excelSheet.CreateRow(countdata);

                    var craSummary2 = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 0, 5);
                    excelSheet.AddMergedRegion(craSummary2);

                    lrSummary2.CreateCell(0).SetCellValue(string.Format("VAT {0}% (Phần mềm VAT 0%)", data.TaxRate));
                    lrSummary2.CreateCell(6).SetCellValue(VATProduct.ToString("###,###.##"));

                    lrSummary2.GetCell(0).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 6, excelSheet, workbook);

                    //
                    countdata = countdata + 1;

                    var totalProduct = VATProduct + data.Details.Where(n => n.IsSoftware == false).Sum(n => n.Price * n.Quantity);

                    var lrSummary3 = excelSheet.CreateRow(countdata);

                    var craSummary3 = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 0, 5);
                    excelSheet.AddMergedRegion(craSummary3);

                    lrSummary3.CreateCell(0).SetCellValue("TỔNG SAU THUẾ");
                    lrSummary3.CreateCell(6).SetCellValue(totalProduct.ToString("###,###.##"));

                    SetBorderRange(countdata, 0, 6, excelSheet, workbook);

                    lrSummary3.GetCell(0).CellStyle = rowSummary;

                    //
                    countdata = countdata + 1;

                    var lrSummary4 = excelSheet.CreateRow(countdata);

                    var craSummary4 = new NPOI.SS.Util.CellRangeAddress(countdata, countdata, 0, 6);
                    excelSheet.AddMergedRegion(craSummary4);

                    lrSummary4.CreateCell(0).SetCellValue(string.Format("Bằng chữ: {0}", FunctionHelper.DocTienBangChu(Convert.ToInt64(data.Total), " đồng")));

                    lrSummary4.GetCell(0).CellStyle = rowSummary;

                    SetBorderRange(countdata, 0, 6, excelSheet, workbook);

                    #endregion

                    #endregion

                    #region phần cuối
                    countdata = countdata + 1;

                    //dòng 6
                    var lr6 = excelSheet.CreateRow(countdata + 5);

                    var lcra6_1 = new CellRangeAddress(countdata + 6, countdata + 6, 0, 1);
                    excelSheet.AddMergedRegion(lcra6_1);

                    var lcra6_2 = new CellRangeAddress(countdata + 6, countdata + 6, 4, 6);
                    excelSheet.AddMergedRegion(lcra6_2);

                    lr6.CreateCell(0, CellType.String).SetCellValue("XÁC NHẬN KHÁCH HÀNG");
                    lr6.Cells[0].CellStyle = lastrow;

                    lr6.CreateCell(4, CellType.String).SetCellValue("T/M CTCP CN FUTECH");
                    lr6.Cells[1].CellStyle = lastrow;
                    #endregion

                    workbook.Write(ms);

                    //Excel_Execute(context, ms.ToArray(), filename);

                    return ms.ToArray();
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}

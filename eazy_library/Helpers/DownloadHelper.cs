using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace eazy_library.Helpers
{
    public class DownloadHelper
    {
        public static byte[] Download_TemplateProduct(HttpContext context)
        {
            var path = string.Format("{0}{1}", Directory.GetCurrentDirectory(), "/wwwroot/files/Template_Import_Product_v2.xlsx");

            byte[] fileBytes = System.IO.File.ReadAllBytes(path);

            //Excel_Execute(context, fileBytes, "Template_Import_Product_v1");

            return fileBytes;
        }

        public static byte[] Download_TemplateInvoiceProduct(HttpContext context)
        {
            var path = string.Format("{0}{1}", Directory.GetCurrentDirectory(), "/wwwroot/files/Template_Product_Invoice_v1.xlsx");

            byte[] fileBytes = System.IO.File.ReadAllBytes(path);

            //Excel_Execute(context, fileBytes, "Template_Import_Product_v1");

            return fileBytes;
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
    }
}

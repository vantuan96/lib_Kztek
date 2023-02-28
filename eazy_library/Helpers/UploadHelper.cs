using System;
using System.IO;
using System.Threading.Tasks;
using eazy_library.Cores.Models;
using eazy_library.Extensions;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace eazy_library.Helpers
{
    public class UploadHelper
    {
        public static async Task<MessageReport> UploadFile(IFormFile file, string path)
        {
            var result = new MessageReport(false, "Có lỗi xảy ra");
            
            try
            {
                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName) ?? "";

                    var fileName = Path.GetFileName(string.Format("{0}{1}", StringUtilHelper.RemoveSpecialCharactersVn(file.FileName.Replace(extension, "")).GetNormalizeString(), extension));

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    using (var fileStream = new FileStream(path + "/" + fileName, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    result = new MessageReport(true, "Upload thành công");
                }
                else
                    return new MessageReport(false, "Không tồn tại file!");
            }
            catch (System.Exception ex)
            {
                result = new MessageReport(false, ex.Message);
            }

            return result;
        }

        public static async Task<string> SaveProduct(IFormFile file, string productid)
        {

            var productPath = file != null ? await GetFileNameNormalize(file, productid, "FileUpload:ProductFolder") : "";

            var path = string.Format("{0}{1}{2}", Directory.GetCurrentDirectory(), await AppSettingHelper.GetStringFromAppSetting("FileUpload:ProductFolder"), productid);

            await UploadFile(file, path);

            return productPath;
        }

        public static async Task<string> SaveTaskFile(IFormFile file, string taskid, string keyApp = "FileUpload:TaskFolder")
        {

            var taskPath = file != null ? await GetFileNameNormalize(file, taskid, keyApp) : "";

            var path = string.Format("{0}{1}{2}", Directory.GetCurrentDirectory(), await AppSettingHelper.GetStringFromAppSetting(keyApp), taskid);

            await UploadFile(file, path);

            return taskPath;
        }

        public static string GetIconByExtension(string path = "", string ext="")
        {
            if(path!="")
                ext = Path.GetExtension(path).ToLowerInvariant();

            var icons = new Dictionary<string, string>
            {
                {".doc", "fa-file-word"},
                {".dot", "fa-file-word" },

                {".docx", "fa-file-word"},
                {".dotx", "fa-file-word" },
                {".docm", "fa-file-word" },
                {".dotm", "fa-file-word" },

                {".xls", "fa-file-excel"},
                {".xlt", "fa-file-excel" },
                {".xla", "fa-file-excel" },

                {".xlsx", "fa-file-excel"},
                {".xltx", "fa-file-excel" },
                {".xlsm", "fa-file-excel" },
                {".xltm", "fa-file-excel" },
                {".xlam", "fa-file-excel" },
                {".xlsb", "fa-file-excel" },

                {".ppt", "fa-file-powerpoint"},
                {".pot", "fa-file-powerpoint"},
                {".pps", "fa-file-powerpoint"},
                {".ppa", "fa-file-powerpoint"},

                {".pptx", "fa-file-powerpoint"},
                {".potx", "fa-file-powerpoint"},
                {".ppsx", "fa-file-powerpoint"},
                {".ppam", "fa-file-powerpoint"},
                {".pptm", "fa-file-powerpoint" },
                {".potm", "fa-file-powerpoint"},
                {".ppsm", "fa-file-powerpoint"},

                {".mdb", "fa-file-alt" },

                {".png", "fa-file-image"},
                {".jpg", "fa-file-image"},
                {".jpeg", "fa-file-image"},
                {".gif", "fa-file-image"},
                {".bmp", "fa-file-image" },

                {".avi", "fa-file-video" },
                {".mp4", "fa-file-video" },
                {".mpeg", "fa-file-video" },

                {".txt", "fa-file-alt"},
                {".pdf", "fa-file-pdf"},
                {".csv", "fa-file-excel"}
            };

            if (icons.ContainsKey(ext))
                return icons[ext];
            else
                return "fa-file-alt";
        }


        public static async Task<string> GetFileNameNormalize(IFormFile file, string folderpath = "", string keyApp = "")
        {
            var extension = Path.GetExtension(file.FileName) ?? "";

            var fileName = Path.GetFileName(string.Format("{0}{1}", StringUtilHelper.RemoveSpecialCharactersVn(file.FileName.Replace(extension, "")).GetNormalizeString(), extension));

            var folder = await AppSettingHelper.GetStringFromAppSetting(keyApp);

            var path = string.Format("{0}{1}/{2}", folder, folderpath, fileName);

            return path;
        }

        public static async Task<string> ReadFile(string FileName)
        {
            try
            {
                using (StreamReader reader = File.OpenText(FileName))
                {
                    string fileContent = reader.ReadToEnd();
                    if (fileContent != null && fileContent != "")
                    {
                        return await Task.FromResult(fileContent);
                    }
                }
            }
            catch (Exception ex)
            {
                //Log
                throw ex;
            }
            
            return null;
        }

        public static async Task<MessageReport> Upload_UserAvatar(IFormFile file, string userid)
        {
            //filename
            var filename = GetFileNameNormalize(file);

            //Format path image
            var path = string.Format("{0}{1}{2}", Directory.GetCurrentDirectory(), await AppSettingHelper.GetStringFromAppSetting("uploads:user"), userid);

            //Thực hiện lưu
            var result = await UploadFile(file, path, filename);
            if (result.isSuccess)
            {
                result.Message = string.Format("{0}{1}/{2}", await AppSettingHelper.GetStringFromAppSetting("uploads:user"), userid, filename);
            }

            return result;
        }

        private static async Task<MessageReport> UploadFile(IFormFile file, string path, string filename)
        {
            var result = new MessageReport(false, "error");

            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using (var fileStream = new FileStream(path + "/" + filename, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                result = new MessageReport(true, "Uploaded");
            }
            catch (System.Exception ex)
            {
                result = new MessageReport(false, ex.Message);
            }

            return result;
        }

        private static string GetFileNameNormalize(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName) ?? "";

            var fileName = Path.GetFileName(string.Format("{0}{1}", StringUtilHelper.RemoveSpecialCharactersVn(file.FileName.Replace(extension, "")).GetNormalizeString(), extension));

            return fileName;
        }


        public static async Task<string> SaveFile(IFormFile fileUpload, string id)
        {
            var taskPath = fileUpload != null ? await GetFileNameNormalize(fileUpload, id, "FileUpload:AvatarFolder") : "";

            var path = string.Format("{0}{1}{2}", Directory.GetCurrentDirectory(), await AppSettingHelper.GetStringFromAppSetting("FileUpload:AvatarFolder"), id);

            await UploadFile(fileUpload, path);

            return taskPath;
        }
    }
}
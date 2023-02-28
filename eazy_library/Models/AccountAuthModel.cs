using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using eazy_library.Cores.Models;

namespace eazy_library.Models
{
    public class AccountAuthModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsRemember { get; set; }

        public string AppCode { get; set; } = ""; //Mã ứng dụng, mã hệ thống
    }

    public class AccountPermissionModel
    {
        public string AccountId { get; set; }

        public bool isAdmin { get; set; }

        public string AppCode { get; set; } = ""; //Mã ứng dụng, mã hệ thống
    }

    public class AccountInfoModel
    {
        public string Id { get; set; } = "";

        public string Name { get; set; } = "";

        public string FirstName { get; set; } = "";

        public string FullName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string Email { get; set; } = ""; // Email dùng để đăng nhập

        public string Email2 { get; set; } = ""; // Email cá nhân

        public string PersonEmail1 { get; set; } = ""; // Bỏ

        public string Mobile { get; set; } = "";

        public string Fax { get; set; } = "";

        public bool IsAdmin { get; set; } = false;
        public bool IsWorking { get; set; } = false;
        public string OrganizationId { get; set; } = "";

        public string LocationId { get; set; } = "";

        public string OldPassword { get; set; } = "";
        public string Avatar { get; set; }

        public string NewPassword { get; set; } = "";

        public string RePassword { get; set; } = "";

        public string ImagePath { get; set; } = "";

        public bool IsDisplayInHR { get; set; } = true;

        public bool IsTemp { get; set; }

        public string RawPassword { get; set; } = "";

        public bool IsManager { get; set; } = false;

    }

    public class AuthModel
    {
        [Required(ErrorMessage = "Nhập tài khoản")]
        public string Username { get; set; } = "";

        [Required(ErrorMessage = "Nhập mật khẩu")]
        public string Password { get; set; } = "";

        public bool isRemember { get; set; } = true;
    }

    public class AccountData
    {
        public MessageReport Report { get; set; } = new MessageReport(false, "error");

        public TokenModel Token { get; set; }

        public AccountInfoModel Info { get; set; }

        public List<MenuFunctionModel> Permissions { get; set; } = new List<MenuFunctionModel>();
    }

    public class AccountRoleUpdate
    {
        public List<string> ids { get; set; }

        public List<string> roles { get; set; }
    }

    public class AccountColumnModel
    {
        public string AppCode { get; set; }

        public string AccountId { get; set; }

        public string ControllerName { get; set; }

        public List<string> newconfigs { get; set; }
    }

    public class AccountEventLog
    {
        public string AccountId { get; set; }

        public string AppCode { get; set; }

        public string TableName { get; set; }

        public string RecordId { get; set; }

        public string Content { get; set; }

        public string ActionType { get; set; }

        public string Address { get; set; }

        public string UserAgent { get; set; }
    }

    public class LocationModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Mobile { get; set; }

        public bool Active { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
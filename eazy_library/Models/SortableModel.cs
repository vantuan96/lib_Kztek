using System;
using System.Collections.Generic;

namespace eazy_library.Models
{
    public class SortableModel
    {
        public string Data_Id { get; set; }

        public string Data_Title { get; set; }

        public int Data_Order { get; set; }

        public string Data_Type { get; set; }

        public string Data_Stage { get; set; }

        public string ParentId { get; set; }

        public string ParentName { get; set; }

        public List<string> ListOrder { get; set; }

        public string AppCode { get; set; }
    }

    public class Sortable_BoardModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string BoardClass { get; set; }

        public string ButtonClass { get; set; }

        public string Group { get; set; }

        public string BoardType { get; set; } //1- To Do, 2- In progress, 3- Done, 4- Cancel

        public string BoardColor { get; set; }

        public List<Sortable_ItemModel> Items { get; set; } = new List<Sortable_ItemModel>();
    }

    public class Sortable_ItemModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string htmlSubTitle { get; set; }

        public string Description { get; set; }

        public string Group { get; set; }

        public bool IsSubscribe { get; set; } // Theo dõi hoặc bỏ theo dõi các thông báo khi có thay đổi
    }

    public class Sortable_Project
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public decimal EstimateBudget { get; set; }

        public string DashboardStageId { get; set; }

        public int SortOrder { get; set; }

        public string FromAppCode { get; set; }
    }

    public class Sortable_Task
    {
        public string TaskTitle { get; set; }

        public string TaskDescription { get; set; }

        public SelectListModel_Chosen Select { get; set; }

        public bool IsPublish { get; set; } // == true => chia sẻ cho tất cả thuộc dự án

        public string boardid { get; set; }

        public string boardstage { get; set; }
    }

    public class Sortable_NewProject
    {
        public string ProjectTitle { get; set; }

        public string boardid { get; set; }

        public string boardstage { get; set; }
    }
}

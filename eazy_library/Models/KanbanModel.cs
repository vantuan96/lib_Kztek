using System;
using System.Collections.Generic;

namespace eazy_library.Models
{
    public class KanbanModel
    {
        public string id { get; set; }

        public string title { get; set; }

        public string classname { get; set; }

        public string summary { get; set; }

        public List<KanbanItemModel> item { get; set; }
    }

    public class KanbanItemModel
    {
        public string id { get; set; } //id dự án

        public string title { get; set; } //html code => dự án
    }

    public class KanbanNewBoardModel
    {
        public string boardid { get; set; }

        public string name { get; set; }
    }

    public class KanbanNewItemModel
    {
        public string boardid { get; set; }
        
        public string boardstage { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string projectid { get; set; } = "";

        public string appcode { get; set; } = "";

        public bool ispublish { get; set; } = false;

        public string rdoPublished { get; set; } = "";

        public List<string> accountGroupIds { get; set; }
    }

    public class KanbanDropEventModel
    {
        public string boardid { get; set; }

        public string itemid { get; set; }

        public string appcode { get; set; }

        public List<KanbanBoardOrderSaveChange> orders { get; set; }
    }

    public class KanbanBoardSaveChange
    {
        public string id { get; set; }

        public string title { get; set; }

        public string style { get; set; }
    }

    public class KanbanBoardOrderSaveChange
    {
        public string id { get; set; }

        public int order { get; set; }
    }

    public class KanbanBoardSummaryUpdate
    {
        public string OldBoardId { get; set; }

        public string OldBoard_Summary { get; set; }

        public string NewBoardId { get; set; }

        public string NewBoard_Summary { get; set; }
    }
}

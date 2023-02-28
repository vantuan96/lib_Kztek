using System;
namespace eazy_library.Models
{
    public class WorkTab
    {
        public string KanBan_ControllerName { get; set; }

        public string KanBan_ActionName { get; set; }

        public string List_ControllerName { get; set; }

        public string List_ActionName { get; set; }

        public int TabActice { get; set; } // 1 => tab 1, 2 => tab 2

        public string dataselect { get; set; } = "";

        public SelectListModel_Chosen ProjectSelect { get; set; }
    }
}

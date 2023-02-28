using System.Collections.Generic;

namespace eazy_library.Models
{
    public class ControllerTreeModel
    {
        public string Title { get; set; }

        public string LevelId { get; set; }

        public string OrganizationId { get; set; }

        public string LocationId { get; set; }

        public List<ControllerTreeDataModel> Data_All { get; set; }

        public List<ControllerTreeDataModel> Data_Child { get; set; }

        public List<SelectListModel> Data_Timezone { get; set; }
    }

    public class ControllerTreeDataModel
    {
        public string Id { get; set; }

        public string SecondId { get; set; }

        public string Name { get; set; }

        public string ParentId { get; set; }

        public bool IsSelected { get; set; }
    }
}
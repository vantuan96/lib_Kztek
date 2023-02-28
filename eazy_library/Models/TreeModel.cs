using System;
using System.Collections.Generic;

namespace eazy_library.Models
{
    public class TreeModel
    {
        public string Title { get; set; }

        public List<Tree_Data> Data_All { get; set; }

        public List<Tree_Data> Data_Child { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public AuthActionModel Auth { get; set; }
    }

    public class Tree_Data {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ParentId { get; set; }

        public int SortOrder { get; set; }

        public bool Active { get; set; }
    }
}

namespace eazy_library.Models
{
    public class OrganizationModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string ParentId { get; set; }

        public string Breadcrumb { get; set; }

        public int Dept { get; set; }

        public bool Active { get; set; }

        public int SortOrder { get; set; }
    }
}
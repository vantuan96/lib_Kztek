namespace eazy_library.Models
{
    public class ContractReceiptModel
    {
        public string Id { get; set; }

        public string ContractId { get; set; }

        public string Title { get; set; }

        public string RDate { get; set; }

        public string Money { get; set; }
    }

    public class ContractSummaryModel
    {
        public string Id { get; set; }

        public string ContractId { get; set; }

        public string Title { get; set; }

        public string Money { get; set; }
    }

    public class ContractNoteModel
    {
        public string Id { get; set; }

        public string ContractId { get; set; }

        public string Content { get; set; }
    }

    public class ContactModel
    {
        public string Id { get; set; }


         public string EnterpriseId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Fax { get; set; }

        public string Address { get; set; }
    }
}
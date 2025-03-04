namespace ModuleManagement.Web.Client.Models
{
    public class Company
    {
        public int IdCompany { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string WebsiteUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public int IdUserCreation { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int? IdUserModification { get; set; }
    }
}

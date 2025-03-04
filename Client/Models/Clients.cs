namespace ModuleManagement.Web.Client.Models
{
    public class Client
    {
        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string OfficialIdentification { get; set; }
        public int IdGender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string ExtNumber { get; set; }
        public string IntNumber { get; set; }
        public string Neighborhood { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
    }

    public class Gender
    {
        public int IdGender { get; set; }
        public string Name { get; set; }
    }
}

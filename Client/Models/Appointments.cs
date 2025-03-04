namespace ModuleManagement.Web.Client.Models
{
    public class Appointment
    {
        public int IdAppointment { get; set; }
        public int IdClient { get; set; }
        public int IdBranch { get; set; }
        public DateTime Date { get; set; }
        public DateTime? EndTime { get; set; }
        public int IdProfessional { get; set; }
        public int IdStatus { get; set; }
        public string CustomerNote { get; set; } = string.Empty;
        public string InternalNote { get; set; } = string.Empty;
        public string Subject => CustomerNote;
    }

    public class Status
    {
        public int IdStatus { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }

    public class AppointmentService
    {
        public int IdAppointmentService { get; set; }
        public int IdAppointment { get; set; }
        public int IdService { get; set; }
        public int IdAdittional { get; set; }
    }
}

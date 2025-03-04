namespace ModuleManagement.Web.Client.SchedulerModels
{
    public class ScheduleData
    {
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int OwnerId { get; set; }
    }

    public class Owner
    {
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerColor { get; set; }

        // Nuevos campos
        public string Designation { get; set; }  // p. ej. "Cardiólogo", "Neurología"
        public string ImageUrl { get; set; }     // URL o ruta de imagen (p. ej. "images/will-smith.png")
    }

}

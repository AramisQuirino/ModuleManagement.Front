namespace ModuleManagement.Web.Client.Models
{
    public class ColorScheme
    {
        public int IdColorScheme { get; set; }
        public int IdCompany { get; set; }
        public string PrimaryColor { get; set; } = "#1b6ec2";
        public string SecondaryColor { get; set; } = "#3a0647";
        public string TertiaryColor { get; set; } = "#ea7a57";
    }
}

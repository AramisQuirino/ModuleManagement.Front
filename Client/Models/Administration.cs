namespace ModuleManagement.Web.Client.Models
{
    public class Branch
    {
        public int IdBranch { get; set; }
        public int IdCompany { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string ExtNum { get; set; }
        public string IntNum { get; set; }
        public string Neighborhood { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class Whatsapp
    {
        public int IdWhatsapp { get; set; }
        public int IdBranch { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }

    public class Schedule
    {
        public int IdSchedule { get; set; }
        public int IdBranch { get; set; }
        public string Day { get; set; } = string.Empty;
        public bool Active { get; set; }
        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;
    }

    public class Receipts
    {
        public int IdReceipt { get; set; }
        public int IdBranch { get; set; }
        public string Receipt { get; set; }
        public string ServiceReceipt { get; set; }
        public string Invoice { get; set; }
        public string Other { get; set; }
    }

    public class Billing
    {
        public int IdBilling { get; set; }
        public int IdBranch { get; set; }
        public string LegalName { get; set; }
        public string BusinessActivity { get; set; }
        public string IdentityNumber { get; set; }
        public string FiscalAddress { get; set; }
        public string AdditionalInformation { get; set; }
    }

    public class Professionals
    {
        public int IdProfessional { get; set; }
        public int IdBranch { get; set; }
        public int IdRole { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

    public class Roles
    {
        public int IdRoles { get; set; }
        public string Name { get; set; }
    }

    public class Permission
    {
        public int IdPermission { get; set; }
        public int IdRole { get; set; }
        public int IdModule { get; set; }
        public bool CanView { get; set; }
        public bool CanModify { get; set; }
    }

    public class Module
    {
        public int IdModule { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
    }

    public class Additional
    {
        public int IdAdditional { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class AdditionalService
    {
        public int IdAdditionalService { get; set; }
        public int IdService { get; set; }
        public int IdAdditional { get; set; }
    }

    public class Category
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }
    }

    public class Class
    {
        public int IdClass { get; set; }
        public int IdBranch { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Duration { get; set; }
        public int IdCategory { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Commission { get; set; }
        public int Capacity { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class Package
    {
        public int IdPackage { get; set; }
        public int IdBranch { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Duration { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Commission { get; set; }
    }

    public class PackageService
    {
        public int IdPackageService { get; set; }
        public int IdPackage { get; set; }
        public int IdService { get; set; }
    }

    public class Plan
    {
        public int IdPlan { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Commission { get; set; }
        public bool WithExpiration { get; set; }
    }

    public class PlanService
    {
        public int IdPlanService { get; set; }
        public int IdPlan { get; set; }
        public int IdService { get; set; }
        public int SessionCount { get; set; }
        public int IdPeriodicity { get; set; }
    }

    public class Services
    {
        public int IdService { get; set; }
        public int IdBranch { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Duration { get; set; } = string.Empty;
        public int IdCategory { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Commission { get; set; }
        public int SessionCount { get; set; }
        public int IdPeriodicity { get; set; }
    }
}

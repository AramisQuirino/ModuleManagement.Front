namespace ModuleManagement.Web.Client.Models
{
    public class Products
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public int IdBrand { get; set; }
        public int IdCategory { get; set; }
        public int IdMeasure { get; set; }
        public decimal PurchaseCost { get; set; }
        public decimal InternalPrice { get; set; }
        public decimal PublicPrice { get; set; }
        public decimal Commission { get; set; }
        public decimal StockQuantity { get; set; }
        public string Description { get; set; }
        public decimal StockAlarm { get; set; }
        public string Emails { get; set; }
    }

    public class CostHistory
    {
        public int IdCostHistory { get; set; }
        public int IdProduct { get; set; }
        public decimal PreviousPurchaseCost { get; set; }
        public decimal CurrentPurchaseCost { get; set; }
        public decimal CurrentInternalPrice { get; set; }
        public decimal PreviousInternalPrice { get; set; }
        public decimal PreviousPublicPrice { get; set; }
        public decimal CurrentPublicPrice { get; set; }
        public DateTime Date { get; set; }
    }

    public class Inventory
    {
        public int IdInventory { get; set; }
        public int IdBranch { get; set; }
        public DateTime Date { get; set; }
        public int IdUser { get; set; }
    }

    public class InventoryDet
    {
        public int IdInventoryDet { get; set; }
        public int IdInventory { get; set; }
        public int IdProduct { get; set; }
        public decimal Count { get; set; }
    }

    public class MovementType
    {
        public int IdMovementType { get; set; }
        public string Name { get; set; }
    }

    public class MovementHistory
    {
        public int IdMovementHistory { get; set; }
        public int IdProduct { get; set; }
        public DateTime Date { get; set; }
        public decimal Movement { get; set; }
        public int IdProfessional { get; set; }
        public int IdMovementType { get; set; }
    }
}

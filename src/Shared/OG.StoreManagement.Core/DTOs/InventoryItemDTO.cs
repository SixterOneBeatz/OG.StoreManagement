namespace OG.StoreManagement.Core.DTOs
{
    public class InventoryItemDTO
    {
        public int InventoryItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
    }
}

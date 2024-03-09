namespace OG.StoreManagement.Core.Entities
{
    public class OrderItemEntity
    {
        public int OrderId { get; set; }
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

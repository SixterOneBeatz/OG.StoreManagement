namespace OG.StoreManagement.Core.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
    }
}

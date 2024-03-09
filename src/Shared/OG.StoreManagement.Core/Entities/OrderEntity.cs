using static OG.StoreManagement.Core.Consts.OrderConsts;

namespace OG.StoreManagement.Core.Entities
{
    public class OrderEntity
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
    }
}

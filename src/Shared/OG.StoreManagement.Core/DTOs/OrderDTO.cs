using static OG.StoreManagement.Core.Consts.OrderConsts;

namespace OG.StoreManagement.Core.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
    }
}

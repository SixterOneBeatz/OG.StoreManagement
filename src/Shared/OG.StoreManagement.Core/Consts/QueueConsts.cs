namespace OG.StoreManagement.Core.Consts
{
    public static class QueueConsts
    {
        public const string INVENTORY_QUEUE_NAME = "inventory-queue";
        public const string PRODUCT_QUEUE_NAME = "product-queue";
        public const string ORDER_QUEUE_NAME = "order-queue";

        public enum QueueEnum
        {
            Inventory,
            Product,
            Order
        }
    }
}

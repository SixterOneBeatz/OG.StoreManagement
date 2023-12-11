namespace OG.StoreManagement.Core.Consts
{
    public static class QueueConsts
    {
        public static class QueueNames
        {
            public const string INVENTORY_QUEUE = "inventory-queue";
            public const string PRODUCT_QUEUE = "product-queue";
            public const string ORDER_QUEUE = "order-queue";
        }

        public enum QueueEnum
        {
            Inventory,
            Product,
            Order
        }
    }
}

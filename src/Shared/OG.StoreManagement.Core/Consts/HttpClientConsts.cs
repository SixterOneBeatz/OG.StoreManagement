namespace OG.StoreManagement.Core.Consts
{
    public static class HttpClientConsts
    {
        public static class ProductEnpoints
        {
            public const string GET_PRODUCTS = "GetProducts";
        }

        public static class OrderEnpoints
        {
            public const string GET_ORDER = "GetOrder";
        }

        public static class InventoryEnpoints
        {

        }

        public enum MicroServices
        {
            Product,
            Order,
            Inventory
        }
    }
}

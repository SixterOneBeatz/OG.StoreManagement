using OG.StoreManagement.Core.Entities;

namespace OG.StoreManagement.Inventory.Application.Common.Interfaces
{
    public interface IInventoryRepository
    {
        Task Add(InventoryItemEntity inventoryItem);
    }
}

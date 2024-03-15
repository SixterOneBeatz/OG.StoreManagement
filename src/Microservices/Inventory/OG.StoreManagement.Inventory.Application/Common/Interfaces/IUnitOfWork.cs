using BaseUoW = OG.StoreManagement.Core.UnitOfWork;

namespace OG.StoreManagement.Inventory.Application.Common.Interfaces
{
    public interface IUnitOfWork : BaseUoW.IUnitOfWork
    {
        IInventoryRepository InventoryRepository { get; }
    }
}

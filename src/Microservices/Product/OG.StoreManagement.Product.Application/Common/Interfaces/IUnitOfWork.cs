using BaseUoW = OG.StoreManagement.Core.UnitOfWork;

namespace OG.StoreManagement.Product.Application.Common.Interfaces
{
    public interface IUnitOfWork : BaseUoW.IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
    }
}

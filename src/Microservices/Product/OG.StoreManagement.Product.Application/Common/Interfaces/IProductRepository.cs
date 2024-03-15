using OG.StoreManagement.Core.Entities;

namespace OG.StoreManagement.Product.Application.Common.Interfaces
{
    public interface IProductRepository
    {
        Task<int> Add(ProductEntity productEntity);
        Task Update(ProductEntity productEntity);
        Task Delete(int id);
    }
}

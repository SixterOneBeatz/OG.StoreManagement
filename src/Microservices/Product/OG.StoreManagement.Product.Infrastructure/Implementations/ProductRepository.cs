using Dapper;
using OG.StoreManagement.Core.Entities;
using OG.StoreManagement.Product.Application.Common.Interfaces;
using System.Data;

namespace OG.StoreManagement.Product.Infrastructure.Implementations
{
    internal class ProductRepository(IDbTransaction transaction) : IProductRepository
    {
        private protected readonly IDbTransaction _transaction = transaction;
        private protected readonly IDbConnection _connection = transaction!.Connection;

        public async Task<int> Add(ProductEntity productEntity)
            => await _connection.ExecuteScalarAsync<int>("INSERT INTO [dbo].[Product] ([Name],[Price]) OUTPUT [inserted].[ProductId] VALUES (@Name, @Price)", new
            {
                productEntity.Name,
                productEntity.Price
            }, transaction: _transaction);

        public async Task Delete(int id)
            => await _connection.ExecuteAsync("", new
            {

            }, transaction: _transaction);

        public Task Update(ProductEntity productEntity)
        {
            throw new NotImplementedException();
        }
    }
}

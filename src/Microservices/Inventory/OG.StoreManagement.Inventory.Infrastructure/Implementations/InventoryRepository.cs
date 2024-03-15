using Dapper;
using OG.StoreManagement.Core.Entities;
using OG.StoreManagement.Inventory.Application.Common.Interfaces;
using System.Data;

namespace OG.StoreManagement.Inventory.Infrastructure.Implementations
{
    internal class InventoryRepository(IDbTransaction transaction) : IInventoryRepository
    {
        private protected readonly IDbTransaction _transaction = transaction;
        private protected readonly IDbConnection _connection = transaction!.Connection;
        public async Task Add(InventoryItemEntity inventoryItem)
            => await _connection.ExecuteAsync("INSERT INTO [dbo].[InventoryItem] ([ProductId], [Quantity]) VALUES (@ProductId, @Quantity)", new
            {
                inventoryItem.ProductId,
                inventoryItem.Quantity
            }, transaction: _transaction);
    }
}

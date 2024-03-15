using OG.StoreManagement.Inventory.Application.Common.Interfaces;
using System.Data;

namespace OG.StoreManagement.Inventory.Infrastructure.Implementations
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;
        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
            _connection.Open();
            _transaction = _connection.BeginTransaction();

            InventoryRepository = new InventoryRepository(_transaction);
        }
        public IInventoryRepository InventoryRepository { get; }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception)
            {
                _transaction.Rollback();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction.Rollback();
            }
            catch (Exception)
            {
                _transaction.Dispose();
            }
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();

            GC.SuppressFinalize(this);
        }

        ~UnitOfWork() => Dispose();
    }
}
